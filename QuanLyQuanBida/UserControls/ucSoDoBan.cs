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
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();

        private int maBanHienTai = 0;
        private int previousMaBan = -1;
        private DateTime? thoiGianBatDauHienTai = null;

        private HoaDonDTO hoaDonContext = null;
        private BanBidaDTO banContext = null;
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
            int selectedBanId = 0;
            if (this.banContext != null)
            {
                selectedBanId = this.banContext.MaBan;
            }

            flpBanBida.Controls.Clear();
            List<BanBidaDTO> danhSachBan = BanBidaBll.LayDanhSachBan();

            Button buttonToReselect = null; 

            foreach (var banDTO in danhSachBan)
            {
                Button btn = new Button()
                {
                    Width = 120,
                    Height = 60,
                    Text = banDTO.TenBan,
                    Tag = banDTO,
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

                if (banDTO.MaBan == selectedBanId)
                {
                    buttonToReselect = btn;
                }
            }

            if (buttonToReselect != null)
            {
                buttonToReselect.PerformClick();
            }
            else
            {
                ResetPanelThongTin();
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
            this.banContext = (BanBidaDTO)btn.Tag;

            this.hoaDonContext = null;

            lblTenBan.Text = banContext.TenBan;
            lblTrangThai.Text = "Trạng thái: " + banContext.TrangThai;

            dgvChiTietHoaDon.Rows.Clear();

            if (banContext.TrangThai == "Đang chơi")
            {
                this.hoaDonContext = hoaDonBLL.LayHoaDonHienTaiCuaBan(banContext.MaBan);

                if (this.hoaDonContext != null)
                {
                    lblGioVao.Text = "Giờ vào: " + this.hoaDonContext.ThoiGianBatDau.ToString("HH:mm:ss dd/MM/yyyy");

                    CapNhatDongTienGio(); 
                    LoadChiTietDichVu();
                }

                btnBatDauChoi.Visible = false;
                btnThanhToan.Visible = true;
                btnInHoaDon.Visible = true;
            }
            else // Bàn Trống hoặc Bảo trì
            {
                btnBatDauChoi.Visible = (banContext.TrangThai == "Trống");
                btnThanhToan.Visible = false;
                btnInHoaDon.Visible = false;
                lblGioVao.Text = "Giờ vào: N/A";
            }

            TinhTongTien();
        }


        private void LoadChiTietDichVu()
        {
            for (int i = dgvChiTietHoaDon.Rows.Count - 1; i >= 0; i--)
            {
                var row = dgvChiTietHoaDon.Rows[i];
                if (row.Tag == null || row.Tag.ToString() != "TIEN_GIO")
                {
                    dgvChiTietHoaDon.Rows.RemoveAt(i);
                }
            }

            if (this.hoaDonContext == null || this.hoaDonContext.ChiTietDichVu == null)
            {
                return;
            }

            var chiTietDichVu = this.hoaDonContext.ChiTietDichVu;

            foreach (var item in chiTietDichVu)
            {
                int rowIndex = dgvChiTietHoaDon.Rows.Add();
                DataGridViewRow newRow = dgvChiTietHoaDon.Rows[rowIndex];

                string tenDV = DichVuBLL.LayTenDichVu(item.MaDichVu);
                newRow.Tag = item.MaCTHD;

                newRow.Cells["colTenSanPham"].Value = tenDV;
                newRow.Cells["colSoLuong"].Value = item.SoLuong;
                newRow.Cells["colDonGia"].Value = item.DonGia; // Đơn giá tại thời điểm gọi món
                newRow.Cells["colThanhTien"].Value = item.DonGia * item.SoLuong;
            }
        }

        private void CapNhatDongTienGio()
        {
            if (this.banContext == null || this.hoaDonContext == null)
            {
                XoaDongTienGio();
                return;
            }

            decimal donGiaGio = this.banContext.GiaTheoGio;
            DateTime thoiGianBatDau = this.hoaDonContext.ThoiGianBatDau;

            var ketQuaTinhTien = hoaDonBLL.TinhTienGio(thoiGianBatDau, DateTime.Now, donGiaGio);
            decimal tienGioHienTai = ketQuaTinhTien.Item2;
            int phutDaTinh = ketQuaTinhTien.Item1;

            DataGridViewRow rowTienGio = null;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Tag != null && row.Tag.ToString() == "TIEN_GIO")
                {
                    rowTienGio = row;
                    break;
                }
            }

            if (rowTienGio == null)
            {
                dgvChiTietHoaDon.Rows.Insert(0, 1);
                rowTienGio = dgvChiTietHoaDon.Rows[0];
                rowTienGio.Tag = "TIEN_GIO";
            }

            rowTienGio.Cells["colTenSanPham"].Value = $"Tiền giờ ({phutDaTinh} phút)";
            rowTienGio.Cells["colSoLuong"].Value = 1;
            rowTienGio.Cells["colDonGia"].Value = donGiaGio;
            rowTienGio.Cells["colThanhTien"].Value = tienGioHienTai;

            rowTienGio.ReadOnly = true;
            rowTienGio.DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224); // Màu xám nhạt
            rowTienGio.DefaultCellStyle.ForeColor = Color.Black;
            rowTienGio.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            rowTienGio.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (rowTienGio.Cells["colGiamSoLuong"] is DataGridViewButtonCell cellGiam)
            {
                cellGiam.Value = "";
            }
            if (rowTienGio.Cells["colTangSoLuong"] is DataGridViewButtonCell cellTang)
            {
                cellTang.Value = "";
            }
        }

        private void XoaDongTienGio()
        {
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Tag != null && row.Tag.ToString() == "TIEN_GIO")
                {
                    dgvChiTietHoaDon.Rows.Remove(row);
                    break;
                }
            }
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
            //1. Xem nó có chơi k đã
            if (this.hoaDonContext == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn đang chơi hợp lệ để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tất cả thông tin cần thiết đều nằm trong 'hoaDonContext'
            int maHoaDonCanThanhToan = this.hoaDonContext.MaHoaDon;
            int maBanCanThanhToan = this.hoaDonContext.MaBan;
            DateTime thoiGianBatDau = this.hoaDonContext.ThoiGianBatDau;
            decimal donGia = this.hoaDonContext.GiaTheoGio;

            // Tính toán lại tiền giờ lần cuối cùng
            var ketQuaTinhTien = hoaDonBLL.TinhTienGio(thoiGianBatDau, DateTime.Now, donGia);
            decimal tienGio = ketQuaTinhTien.Item2;

            // 2. Tính tổng tiền dịch vụ
            decimal tienDichVu = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                // Tính mỗi dịch vụ thôi mount fuack
                if (row.Tag == null || row.Tag.ToString() != "TIEN_GIO")
                {
                    tienDichVu += Convert.ToDecimal(row.Cells["colThanhTien"].Value);
                }
            }

            // 3. Tính giảm giá và tổng tiền cuối cùng
            decimal giamGia = 0; //Cút m, nghèo lắm k có giảm giá đâu
            decimal tongTien = tienGio + tienDichVu - giamGia;


            // Hiển thị hộp thoại xác nhận
            string thongBao = $"Thanh toán cho {lblTenBan.Text}?\n\n" +
                              $"Tiền giờ: {tienGio:N0}đ\n" +
                              $"Tiền dịch vụ: {tienDichVu:N0}đ\n" +
                              $"Giảm giá: {giamGia:N0}đ\n" +
                              $"----------------------------------\n" +
                              $"TỔNG TIỀN: {tongTien:N0}đ";

            if (MessageBox.Show(thongBao, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool thanhCong = hoaDonBLL.ThanhToan(maHoaDonCanThanhToan, maBanCanThanhToan, tongTien, giamGia, tienGio, tienDichVu);

                if (thanhCong)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset GUI
                    ResetPanelThongTin();
                    LoadBanBida();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ResetPanelThongTin()
        {
            lblTenBan.Text = "CHỌN BÀN";
            lblTrangThai.Text = "Trạng thái:";
            lblGioVao.Text = "Giờ vào: N/A";
            dgvChiTietHoaDon.Rows.Clear();
            lblTongTien.Text = "Tổng tiền: 0đ";

            thoiGianBatDauHienTai = null;

            btnBatDauChoi.Visible = false;
            btnThanhToan.Visible = false;
            btnInHoaDon.Visible = false;
        }
        private void btnBatDauChoi_Click(object sender, EventArgs e)
        {
            if (maBanHienTai == 0) return;
            string tenBanHienTai = lblTenBan.Text;

            using (var form = new frmBatDauChoi(lblTenBan.Text))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int? maKH = form.MaKhachHangChon;
                    string tenKhach = form.TenKhachVangLai;

                    if(maKH == null && string.IsNullOrWhiteSpace(tenKhach))
                    {
                        return;
                    }
                    else if (maKH == null && !string.IsNullOrWhiteSpace(tenKhach))
                    {
                        maKH = 0;
                    }
                    else if (maKH != null && string.IsNullOrWhiteSpace(tenKhach))
                    {
                        tenKhach = KhachHangBLL.LayTenKhachHang((int)maKH);
                    }
                    int maNhanVien = Program.NhanVienHienTai.MaNhanVien;

                    int maHoaDonMoi = hoaDonBLL.TaoHoaDon(maKH.Value, tenKhach, maBanHienTai, maNhanVien);
                    // Tải lại danh sách bàn để cập nhật màu sắc.
                    LoadBanBida();
                    //
                    ///Chưa làm, f
                    // 4. Cập nhật giao diện bên phải để hiển thị hóa đơn mới.
                    //    (Ẩn nút Bắt đầu, hiện nút Thanh toán,...)

                    MessageBox.Show($"Bắt đầu chơi cho {tenBanHienTai} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBanBida();
                    
                    lblTrangThai.Text = "Trạng thái: Đang chơi";
                    lblGioVao.Text = "Giờ vào: " + this.thoiGianBatDauHienTai.Value.ToString("HH:mm:ss dd/MM/yyyy");

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
            if (selectedRow.Tag != null && selectedRow.Tag.ToString() == "TIEN_GIO")
            {
                return;
            }
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