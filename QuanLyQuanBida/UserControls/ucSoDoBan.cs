using QuanLyQuanBida.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucSoDoBan : UserControl
    {
        DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();
        public ucSoDoBan()
        {
            InitializeComponent();
            this.Load += UcSoDoBan_Load;
        }

        private void UcSoDoBan_Load(object sender, EventArgs e)
        {
            LoadBanBida();
            LoadLoaiDichVu();
            if (flpLoaiDichVu.Controls.Count > 0)
            {
                (flpLoaiDichVu.Controls[0] as Button).PerformClick();
            }
            SetupDataGridView();
        }

        // Load Bàn
        private void LoadBanBida()
        {
            flpBanBida.Controls.Clear();
            var tables = db.BanBida
                .Select(b => new { b.TenBan, b.TrangThai })
                .ToList()
                .Select(b => Tuple.Create(b.TenBan, b.TrangThai == "Trống" ? "Trống" : (b.TrangThai == "DangChoi" ? "Đang chơi" : "Bảo trì")))
                .ToList();

            foreach (var table in tables)
            {
                Button btn = new Button()
                {
                    Width = 120,
                    Height = 60,
                    Text = table.Item1,
                    Tag = table.Item2,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Margin = new Padding(10)
                };

                switch (table.Item2)
                {
                    case "Trống":
                        btn.BackColor = Color.SeaGreen;
                        btn.ForeColor = Color.White;
                        break;
                    case "Đang chơi":
                        btn.BackColor = Color.OrangeRed;
                        btn.ForeColor = Color.White;
                        break;
                    case "Bảo trì":
                        btn.BackColor = Color.Gray;
                        btn.ForeColor = Color.White;
                        break;
                }
                btn.Click += Ban_Click;
                flpBanBida.Controls.Add(btn);
            }
        }

        private void LoadLoaiDichVu()
        {
            flpLoaiDichVu.Controls.Clear();
            string[] categories = db.LoaiDichVu.ToList()
                .Select(ldv => ldv.TenLoaiDV)
                .ToArray();

            foreach (var cat in categories)
            {
                Button btn = new Button()
                {
                    Text = cat,
                    AutoSize = true,
                    BackColor = Color.DimGray,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10),
                    Margin = new Padding(5)
                };
                btn.Click += LoaiDichVu_Click;
                flpLoaiDichVu.Controls.Add(btn);
            }
        }

        private void LoadDichVu(string category)
        {
            flpDichVu.Controls.Clear();

            var services = db.DichVu
                .Where(dv => dv.LoaiDichVu.TenLoaiDV == category)
                .Select(dv => new { dv.TenDichVu, dv.Gia })
                .ToList()
                .Select(dv => Tuple.Create(dv.TenDichVu, dv.Gia))
                .ToList();

            foreach (var service in services)
            {
                Button btn = new Button()
                {
                    Width = 150,
                    Height = 80,
                    Text = $"{service.Item1}\n{service.Item2:N0}đ",
                    Tag = service,
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(63, 63, 70),
                    ForeColor = Color.White,
                    Margin = new Padding(8)
                };
                btn.Click += DichVu_Click;
                flpDichVu.Controls.Add(btn);
            }
        }

        // Cài đặt cho Bảng chi tiết hóa đơn
        private void SetupDataGridView()
        {
            dgvChiTietHoaDon.ColumnCount = 4;
            dgvChiTietHoaDon.Columns[0].Name = "Tên sản phẩm";
            dgvChiTietHoaDon.Columns[1].Name = "Số lượng";
            dgvChiTietHoaDon.Columns[2].Name = "Đơn giá";
            dgvChiTietHoaDon.Columns[3].Name = "Thành tiền";

            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHoaDon.Columns[1].Width = 80;
            dgvChiTietHoaDon.Columns[2].DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns[3].DefaultCellStyle.Format = "N0";
        }


        // Sự kiện khi nhấn vào 1 bàn
        private void Ban_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lblTenBan.Text = btn.Text;
            string trangThai = btn.Tag.ToString();
            lblTrangThai.Text = "Trạng thái: " + btn.Tag.ToString();

            if (trangThai == "Trống")
            {
                btnBatDauChoi.Visible = true;
                btnThanhToan.Visible = false;
                btnInHoaDon.Visible = false;
                dgvChiTietHoaDon.Rows.Clear();
                lblGioVao.Text = "Giờ vào: N/A";
            }
            else
            {
                btnBatDauChoi.Visible = false;
                btnThanhToan.Visible = (trangThai == "Đang chơi");
                btnInHoaDon.Visible = (trangThai == "Đang chơi");
                if (trangThai == "Đang chơi")
                {
                    lblGioVao.Text = "Giờ vào: " + DateTime.Now.AddHours(-1).ToString("HH:mm");
                    dgvChiTietHoaDon.Rows.Add("Tiền giờ", "1.0", 60000, 60000);
                    dgvChiTietHoaDon.Rows.Add("Coca Cola", "2", 15000, 30000);
                }
            }
            TinhTongTien();
        }

        // Sự kiện khi chọn loại dịch vụ
        private void LoaiDichVu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // Highlight nút được chọn
            foreach (Button b in flpLoaiDichVu.Controls)
            {
                b.BackColor = Color.DimGray;
            }
            btn.BackColor = Color.Goldenrod;
            LoadDichVu(btn.Text);
        }

        // Sự kiện khi nhấn vào 1 sản phẩm/dịch vụ để thêm vào hóa đơn
        private void DichVu_Click(object sender, EventArgs e)
        {
            if (lblTenBan.Text == "CHỌN BÀN")
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = sender as Button;
            var serviceInfo = (Tuple<string, double>)btn.Tag;
            string tenSP = serviceInfo.Item1;
            double donGia = serviceInfo.Item2;

            // Kiểm tra xem sản phẩm đã có trong hóa đơn chưa
            bool existed = false;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["Tên sản phẩm"].Value.ToString() == tenSP)
                {
                    int currentQty = Convert.ToInt32(row.Cells["Số lượng"].Value);
                    row.Cells["Số lượng"].Value = currentQty + 1;
                    row.Cells["Thành tiền"].Value = (currentQty + 1) * donGia;
                    existed = true;
                    break;
                }
            }

            if (!existed)
            {
                dgvChiTietHoaDon.Rows.Add(tenSP, 1, donGia, donGia);
            }
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["Thành tiền"].Value);
            }
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} đ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.Rows.Count > 0)
            {
                var result = MessageBox.Show($"Xác nhận thanh toán cho {lblTenBan.Text}?\nTổng tiền: {lblTongTien.Text.Split(':')[1].Trim()}",
                                             "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Code xử lý thanh toán, cập nhật CSDL ở đây
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset
                    dgvChiTietHoaDon.Rows.Clear();
                    lblTenBan.Text = "CHỌN BÀN";
                    lblTrangThai.Text = "Trạng thái: ";
                    lblGioVao.Text = "Giờ vào: N/A";
                    TinhTongTien();
                }
            }
        }
        private void btnBatDauChoi_Click(object sender, EventArgs e)
        {
            // Mở form xác nhận
            using (var form = new frmBatDauChoi(lblTenBan.Text))
            {
                // Nếu người dùng nhấn nút "Bắt Đầu" (OK)
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Lấy thông tin khách hàng từ form
                    int? maKH = form.MaKhachHangChon;
                    string tenKhach = form.TenKhachVangLai;

                    // --- PHẦN NGHIỆP VỤ CỦA BẠN ---
                    // 1. Tạo một hóa đơn mới trong CSDL với:
                    //    - Mã bàn (lấy từ lblTenBan.Text)
                    //    - Mã khách hàng (maKH) nếu có
                    //    - Tên khách vãng lai (tenKhach) nếu có
                    //    - Thời gian bắt đầu là DateTime.Now
                    //    - Trạng thái hóa đơn là "Chưa thanh toán"
                    //
                    // 2. Cập nhật trạng thái của bàn trong CSDL thành "Đang chơi".
                    //
                    // 3. Tải lại danh sách bàn để cập nhật màu sắc.
                    //    LoadBanBida();
                    //
                    // 4. Cập nhật giao diện bên phải để hiển thị hóa đơn mới.
                    //    (Ẩn nút Bắt đầu, hiện nút Thanh toán,...)

                    MessageBox.Show($"Bắt đầu chơi cho {lblTenBan.Text}.\nKH ID: {maKH?.ToString() ?? "N/A"}\nTên khách: {tenKhach}");

                    // Tải lại toàn bộ giao diện để cập nhật
                    LoadBanBida();
                    // Xóa thông tin bàn đang chọn để buộc người dùng chọn lại
                    lblTenBan.Text = "CHỌN BÀN";
                    lblTrangThai.Text = "Trạng thái:";
                    dgvChiTietHoaDon.Rows.Clear();
                    btnBatDauChoi.Visible = false;
                }
            }
        }
    }
}