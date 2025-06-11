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
        public ucSoDoBan()
        {
            InitializeComponent();
            // Tải dữ liệu mẫu khi control được load
            this.Load += UcSoDoBan_Load;
        }

        private void UcSoDoBan_Load(object sender, EventArgs e)
        {
            LoadBanBida();
            LoadLoaiDichVu();
            // Mặc định chọn loại dịch vụ đầu tiên
            if (flpLoaiDichVu.Controls.Count > 0)
            {
                (flpLoaiDichVu.Controls[0] as Button).PerformClick();
            }
            SetupDataGridView();
        }

        // Tải danh sách bàn (dữ liệu giả)
        private void LoadBanBida()
        {
            flpBanBida.Controls.Clear();
            var tables = new List<Tuple<string, string>>
            {
                Tuple.Create("VIP 1", "Đang chơi"), Tuple.Create("VIP 2", "Trống"),
                Tuple.Create("L-01", "Trống"), Tuple.Create("L-02", "Đang chơi"),
                Tuple.Create("L-03", "Bảo trì"), Tuple.Create("L-04", "Trống"),
                Tuple.Create("L-05", "Trống"), Tuple.Create("L-06", "Đang chơi"),
            };

            foreach (var table in tables)
            {
                Button btn = new Button()
                {
                    Width = 120,
                    Height = 60,
                    Text = table.Item1,
                    Tag = table.Item2, // Lưu trạng thái vào Tag
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

        // Tải danh mục dịch vụ (dữ liệu giả)
        private void LoadLoaiDichVu()
        {
            flpLoaiDichVu.Controls.Clear();
            string[] categories = { "Đồ uống", "Đồ ăn", "Bia", "Thuốc lá" };
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

        // Tải các sản phẩm/dịch vụ theo loại (dữ liệu giả)
        private void LoadDichVu(string category)
        {
            flpDichVu.Controls.Clear();
            // Đây là nơi bạn sẽ truy vấn CSDL
            var services = new List<Tuple<string, double>>();
            if (category == "Đồ uống")
            {
                services.Add(Tuple.Create("Coca Cola", 15000.0));
                services.Add(Tuple.Create("Sting", 15000.0));
                services.Add(Tuple.Create("Nước suối", 10000.0));
            }
            else if (category == "Đồ ăn")
            {
                services.Add(Tuple.Create("Mì xào trứng", 30000.0));
                services.Add(Tuple.Create("Khô gà", 35000.0));
            }

            foreach (var service in services)
            {
                Button btn = new Button()
                {
                    Width = 150,
                    Height = 80,
                    Text = $"{service.Item1}\n{service.Item2:N0}đ",
                    Tag = service, // Lưu thông tin sản phẩm
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
            lblTrangThai.Text = "Trạng thái: " + btn.Tag.ToString();

            // Giả lập dữ liệu hóa đơn khi bàn đang chơi
            dgvChiTietHoaDon.Rows.Clear();
            if (btn.Tag.ToString() == "Đang chơi")
            {
                lblGioVao.Text = "Giờ vào: " + DateTime.Now.AddHours(-1).ToString("HH:mm");
                dgvChiTietHoaDon.Rows.Add("Tiền giờ", "1.0", 60000, 60000);
                dgvChiTietHoaDon.Rows.Add("Coca Cola", "2", 15000, 30000);
            }
            else
            {
                lblGioVao.Text = "Giờ vào: N/A";
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
    }
}