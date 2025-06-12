using QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
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
        private BanBidaBLL BanBidaBll = new BanBidaBLL();
        private KhachHangBLL KhachHangBLL = new KhachHangBLL();
        private DichVuBLL DichVuBLL = new DichVuBLL();
        private LoaiDichVuBLL LoaiDichVuBLL = new LoaiDichVuBLL();
        public ucSoDoBan()
        {
            InitializeComponent();
            this.Load += UcSoDoBan_Load;
            this.dgvChiTietHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietHoaDon_CellContentClick);
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
            List<BanBidaDTO> danhSachBan = BanBidaBll.LayDanhSachBan();

            foreach (var banDTO in danhSachBan)
            {
                Button btn = new Button()
                {
                    Width = 120,
                    Height = 60,
                    Text = banDTO.TenBan,
                    Tag = banDTO.TrangThai,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Margin = new Padding(10)
                };

                switch (banDTO.TrangThai)
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
            string[] categories = LoaiDichVuBLL.LayDanhSachLoaiDichVu().ToArray();

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
            var services = DichVuBLL.LayDanhSachDichVu(category);

            foreach (var service in services)
            {
                Button btn = new Button()
                {
                    Width = 150,
                    Height = 80,
                    Text = $"{service.TenDichVu}\n{service.Gia:N0}đ",
                    Tag = service.MaDichVu,
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
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            var colMaDichVu = new DataGridViewTextBoxColumn
            {
                Name = "colMaDichVu",
                DataPropertyName = "MaDichVu",
                ReadOnly = true,
                Visible = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvChiTietHoaDon.Columns.Add(colMaDichVu);

            var colTenSP = new DataGridViewTextBoxColumn
            {
                Name = "colTenSanPham",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenDichVu", 
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvChiTietHoaDon.Columns.Add(colTenSP);

            var colGiam = new DataGridViewButtonColumn
            {
                Name = "colGiamSoLuong",
                HeaderText = "-",
                Text = "-",
                UseColumnTextForButtonValue = true, 
                Width = 40
            };
            dgvChiTietHoaDon.Columns.Add(colGiam);

            // 3. Cột Số lượng (TextBoxColumn)
            var colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                HeaderText = "SL",
                DataPropertyName = "SoLuong",
                ReadOnly = false,
                Width = 50,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChiTietHoaDon.Columns.Add(colSoLuong);

            var colTang = new DataGridViewButtonColumn
            {
                Name = "colTangSoLuong",
                HeaderText = "+",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dgvChiTietHoaDon.Columns.Add(colTang);

            var colDonGia = new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "Gia",
                ReadOnly = true,
                Width = 100
            };
            colDonGia.DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns.Add(colDonGia);

            var colThanhTien = new DataGridViewTextBoxColumn
            {
                Name = "colThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                ReadOnly = true,
                Width = 120
            };
            colThanhTien.DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns.Add(colThanhTien);
        }

        // Sự kiện khi nhấn vào 1 bàn
        private void Ban_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lblTenBan.Text = btn.Text;
            string trangThai = btn.Tag.ToString();
            lblTrangThai.Text = "Trạng thái: " + btn.Tag.ToString();
            var serviceInfo = DichVuBLL.LayDichVuTheoID(Convert.ToInt32(btn.Tag));

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


                    //Chỗ này phải truy vấn từ CSDL để lấy chi tiết hóa đơn
                    //Giá tiền của bàn
                    //Giờ chơi tính tới hiện tại
                    //Nhân cả 2 lại

                    //int rowIndex = dgvChiTietHoaDon.Rows.Add();

                    //DataGridViewRow newRow = dgvChiTietHoaDon.Rows[rowIndex];

                    //newRow.Tag = serviceInfo.MaDichVu;

                    //newRow.Cells["colTenSanPham"].Value = tenSP;
                    //newRow.Cells["colSoLuong"].Value = 1;
                    //newRow.Cells["colDonGia"].Value = donGia;
                    //newRow.Cells["colThanhTien"].Value = donGia;
                }
            }
            TinhTongTien();
        }

        private void LoaiDichVu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
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
            var serviceInfo = DichVuBLL.LayDichVuTheoID(Convert.ToInt32(btn.Tag));
            string tenSP = serviceInfo.TenDichVu;
            decimal donGia = serviceInfo.Gia;

            bool existed = false;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["colTenSanPham"].Value.ToString() == tenSP)
                {
                    int currentQty = Convert.ToInt32(row.Cells["colSoLuong"].Value); // Số lượng hiện tại
                    row.Cells["colSoLuong"].Value = currentQty + 1;
                    row.Cells["colThanhTien"].Value = (currentQty + 1) * donGia;
                    existed = true;
                    break;
                }
            }

            if (!existed)
            {
                int rowIndex = dgvChiTietHoaDon.Rows.Add();
                
                DataGridViewRow newRow = dgvChiTietHoaDon.Rows[rowIndex];

                newRow.Tag = serviceInfo.MaDichVu;

                newRow.Cells["colTenSanPham"].Value = tenSP;
                newRow.Cells["colSoLuong"].Value = 1;
                newRow.Cells["colDonGia"].Value = donGia;
                newRow.Cells["colThanhTien"].Value = donGia;
            }
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["colThanhTien"].Value);
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
            using (var form = new frmBatDauChoi(lblTenBan.Text))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int? maKH = form.MaKhachHangChon;
                    string tenKhach = form.TenKhachVangLai;

                    // --- PHẦN NGHIỆP VỤ ---
                    // 1. Tạo một hóa đơn mới trong CSDL với:
                    //    - Mã bàn (lấy từ lblTenBan.Text)
                    //    - Mã khách hàng (maKH)
                    //    - Tên khách vãng lai (tenKhach)
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

                    LoadBanBida();
                    lblTenBan.Text = "CHỌN BÀN";
                    lblTrangThai.Text = "Trạng thái:";
                    dgvChiTietHoaDon.Rows.Clear();
                    btnBatDauChoi.Visible = false;
                }
            }
        }
        private void dgvChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvChiTietHoaDon.Columns[e.ColumnIndex].Name;
            DataGridViewRow selectedRow = dgvChiTietHoaDon.Rows[e.RowIndex];

            int soLuongHienTai = Convert.ToInt32(selectedRow.Cells["colSoLuong"].Value);
            decimal donGia = Convert.ToDecimal(selectedRow.Cells["colDonGia"].Value);

            if (columnName == "colGiamSoLuong")
            {
                int soLuongMoi = soLuongHienTai - 1;
                if (soLuongMoi > 0)
                {
                    selectedRow.Cells["colSoLuong"].Value = soLuongMoi;
                    selectedRow.Cells["colThanhTien"].Value = soLuongMoi * donGia;
                }
                else
                {
                    dgvChiTietHoaDon.Rows.Remove(selectedRow);
                }
                TinhTongTien();
            }
            else if (columnName == "colTangSoLuong")
            {
                int soLuongMoi = soLuongHienTai + 1;
                selectedRow.Cells["colSoLuong"].Value = soLuongMoi;
                selectedRow.Cells["colThanhTien"].Value = soLuongMoi * donGia;
                TinhTongTien();
            }
        }
    }
}