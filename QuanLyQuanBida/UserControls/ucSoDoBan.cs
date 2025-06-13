using QuanLyQuanBida.BLL;
using QuanLyQuanBida.BLL.QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
using QuanLyQuanBida.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucSoDoBan : UserControl
    {
        private System.Drawing.Printing.PrintDocument printDoc;
        private string hoaDonContentToPrint;
        // Business Logic Layer
        private readonly BanBidaBLL BanBidaBll = new BanBidaBLL();
        private readonly KhachHangBLL KhachHangBLL = new KhachHangBLL();
        private readonly DichVuBLL DichVuBLL = new DichVuBLL();
        private readonly LoaiDichVuBLL LoaiDichVuBLL = new LoaiDichVuBLL();
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private readonly ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();

        // Data Context for UI
        private BanBidaDTO banContext = null;
        private HoaDonDTO hoaDonContext = null;
        private List<ChiTietHoaDonDTO> danhSachDichVuChonTruoc = new List<ChiTietHoaDonDTO>();

        public ucSoDoBan()
        {
            InitializeComponent();
            this.Load += UcSoDoBan_Load;

            this.dgvChiTietHoaDon.CellContentClick += new DataGridViewCellEventHandler(this.dgvChiTietHoaDon_CellContentClick);
        }

        #region Form & Control Load Events

        private void UcSoDoBan_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadLoaiDichVu();
            if (flpLoaiDichVu.Controls.Count > 0)
            {
                (flpLoaiDichVu.Controls[0] as Button).PerformClick();
            }
            LoadBanBida();
        }

        private void LoadBanBida()
        {
            int selectedBanId = this.banContext?.MaBan ?? 0;
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
            var categories = LoaiDichVuBLL.LayDanhSachTenLoaiDichVu();
            foreach (var cat in categories)
            {
                Button btn = new Button
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
                Button btn = new Button
                {
                    Width = 150,
                    Height = 80,
                    Text = $"{service.TenDichVu}\n{service.Gia:N0} đ",
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

        private void SetupDataGridView()
        {
            dgvChiTietHoaDon.Columns.Clear();
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMaDichVu", Visible = false });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenSanPham", HeaderText = "Tên sản phẩm", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewButtonColumn { Name = "colGiamSoLuong", HeaderText = "", Text = "-", UseColumnTextForButtonValue = true, Width = 30 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSoLuong", HeaderText = "SL", ReadOnly = true, Width = 40, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewButtonColumn { Name = "colTangSoLuong", HeaderText = "", Text = "+", UseColumnTextForButtonValue = true, Width = 30 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDonGia", HeaderText = "Đơn giá", ReadOnly = true, Width = 100, DefaultCellStyle = { Format = "N0" } });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "colThanhTien", HeaderText = "Thành tiền", ReadOnly = true, Width = 120, DefaultCellStyle = { Format = "N0" } });
        }

        #endregion

        #region UI Event Handlers (Clicks)

        private void Ban_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.banContext = (BanBidaDTO)btn.Tag;
            this.hoaDonContext = null;
            this.danhSachDichVuChonTruoc.Clear();

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
                    LoadChiTietDichVuVaoDGV();
                }
                btnBatDauChoi.Visible = false;
                btnThanhToan.Visible = true;
                btnInHoaDon.Visible = true;
            }
            else
            {
                lblGioVao.Text = "Giờ vào: N/A";
                XoaDongTienGio();
                btnBatDauChoi.Visible = (banContext.TrangThai == "Trống");
                btnThanhToan.Visible = false;
                btnInHoaDon.Visible = false;
            }
            TinhTongTien();
        }

        private void LoaiDichVu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            foreach (Control c in flpLoaiDichVu.Controls)
            {
                c.BackColor = Color.DimGray;
            }
            btn.BackColor = Color.Goldenrod;
            LoadDichVu(btn.Text);
        }

        private void DichVu_Click(object sender, EventArgs e)
        {
            if (this.banContext == null || this.banContext.TrangThai == "Bảo trì")
            {
                MessageBox.Show("Vui lòng chọn bàn hợp lệ hoặc bàn không đang bảo trì.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btnDV = sender as Button;
            var serviceDTO = (DichVuDTO)btnDV.Tag;
            CapNhatChiTietHoaDon(serviceDTO, 1); 
        }

        private void dgvChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChiTietHoaDon.Rows[e.RowIndex];
            if (row.Tag?.ToString() == "TIEN_GIO" || row.Cells["colMaDichVu"].Value == null) return;

            var maDichVu = Convert.ToInt32(row.Cells["colMaDichVu"].Value);
            var serviceInfo = DichVuBLL.LayDichVuTheoID(maDichVu); // Lấy thông tin mới nhất
            if (serviceInfo == null) return;

            var columnName = dgvChiTietHoaDon.Columns[e.ColumnIndex].Name;

            if (columnName == "colGiamSoLuong")
            {
                CapNhatChiTietHoaDon(serviceInfo, -1);
            }
            else if (columnName == "colTangSoLuong")
            {
                CapNhatChiTietHoaDon(serviceInfo, 1); 
            }
        }

        private void btnBatDauChoi_Click(object sender, EventArgs e)
        {
            if (this.banContext == null || this.banContext.TrangThai != "Trống")
            {
                MessageBox.Show("Vui lòng chọn một bàn đang trống để bắt đầu chơi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formChonKhach = new frmBatDauChoi(this.banContext.TenBan))
            {
                if (formChonKhach.ShowDialog() != DialogResult.OK) return;

                int? maKH = formChonKhach.MaKhachHangChon;
                string tenKhachHang = formChonKhach.TenKhachVangLai;

                // Xác định tên khách hàng cuối cùng
                if (maKH.HasValue && maKH > 0)
                {
                    var khachHangDTO = KhachHangBLL.LayThongTinKhachHang(maKH.Value);
                    if (khachHangDTO != null) tenKhachHang = khachHangDTO.HoTen;
                }
                else if (string.IsNullOrWhiteSpace(tenKhachHang))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng thành viên hoặc nhập tên khách vãng lai.", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    int maHoaDonMoiVuaTao = hoaDonBLL.TaoHoaDon(maKH.Value, tenKhachHang, this.banContext.MaBan, Program.NhanVienHienTai.MaNhanVien, this.danhSachDichVuChonTruoc);

                    if (maHoaDonMoiVuaTao > 0)
                    {
                        MessageBox.Show($"Bắt đầu chơi cho {this.banContext.TenBan} thành công.\nKhách hàng: {tenKhachHang}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.danhSachDichVuChonTruoc.Clear();
                        LoadBanBida();
                    }
                    else
                    {
                        MessageBox.Show("Không thể tạo hóa đơn mới. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadBanBida(); // Tải lại phòng trường hợp trạng thái bàn bị lỗi
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (this.hoaDonContext == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn đang chơi hợp lệ để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ketQuaTinhTien = hoaDonBLL.TinhTienGio(this.hoaDonContext.ThoiGianBatDau, DateTime.Now, this.banContext.GiaTheoGio);
            decimal tienGio = ketQuaTinhTien.Item2;
            decimal tienDichVu = this.hoaDonContext.ChiTietDichVu?.Sum(ct => ct.SoLuong * ct.DonGia) ?? 0;
            decimal giamGia = 0; // Logic giảm giá nếu có
            decimal tongTien = tienGio + tienDichVu - giamGia;

            string thongBao = $"Thanh toán cho {lblTenBan.Text}?\n\n" +
                              $"Tiền giờ: {tienGio:N0} đ\n" +
                              $"Tiền dịch vụ: {tienDichVu:N0} đ\n" +
                              $"Giảm giá: {giamGia:N0} đ\n" +
                              $"----------------------------------\n" +
                              $"TỔNG TIỀN: {tongTien:N0} đ";

            if (MessageBox.Show(thongBao, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool thanhCong = hoaDonBLL.ThanhToan(this.hoaDonContext.MaHoaDon, this.banContext.MaBan, tongTien, giamGia, tienGio, tienDichVu);
                if (thanhCong)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBanBida();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CapNhatChiTietHoaDon(DichVuDTO serviceDTO, int changeAmount)
        {
            // Tìm dòng tương ứng trong DataGridView
            DataGridViewRow existingRow = dgvChiTietHoaDon.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["colMaDichVu"].Value != null && Convert.ToInt32(r.Cells["colMaDichVu"].Value) == serviceDTO.MaDichVu);

            int soLuongHienTai = existingRow != null ? Convert.ToInt32(existingRow.Cells["colSoLuong"].Value) : 0;
            int soLuongMoi = soLuongHienTai + changeAmount;

            // Xử lý lưu trữ dựa trên trạng thái bàn
            if (this.banContext.TrangThai == "Trống")
            {
                var itemChonTruoc = danhSachDichVuChonTruoc.FirstOrDefault(dv => dv.MaDichVu == serviceDTO.MaDichVu);
                if (soLuongMoi > 0)
                {
                    if (itemChonTruoc != null)
                    {
                        itemChonTruoc.SoLuong = soLuongMoi;
                    }
                    else
                    {
                        danhSachDichVuChonTruoc.Add(new ChiTietHoaDonDTO { MaDichVu = serviceDTO.MaDichVu, TenDichVu = serviceDTO.TenDichVu, SoLuong = soLuongMoi, DonGia = serviceDTO.Gia });
                    }
                }
                else
                {
                    if (itemChonTruoc != null) danhSachDichVuChonTruoc.Remove(itemChonTruoc);
                }
                // Tải lại DGV từ danh sách chọn trước
                LoadDanhSachChonTruocVaoDGV();
            }
            else if (this.banContext.TrangThai == "Đang chơi" && this.hoaDonContext != null)
            {
                try
                {
                    chiTietHoaDonBLL.ThemHoacCapNhatDichVuChoHoaDon(this.hoaDonContext.MaHoaDon, serviceDTO.MaDichVu, soLuongMoi, serviceDTO.Gia);

                    this.hoaDonContext = hoaDonBLL.LayHoaDonHienTaiCuaBan(this.banContext.MaBan);
                    LoadChiTietDichVuVaoDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.hoaDonContext = hoaDonBLL.LayHoaDonHienTaiCuaBan(this.banContext.MaBan);
                    LoadChiTietDichVuVaoDGV();
                }
            }
            TinhTongTien();
        }

        private void LoadChiTietDichVuVaoDGV()
        {
            XoaDongDichVu(); // Xóa các dòng dịch vụ cũ
            if (this.hoaDonContext?.ChiTietDichVu == null) return;

            foreach (var item in this.hoaDonContext.ChiTietDichVu)
            {
                ThemRowDichVuVaoDGV(item.MaDichVu, DichVuBLL.LayTenDichVu(item.MaDichVu), item.SoLuong, item.DonGia, item.MaCTHD);
            }
            TinhTongTien();
        }

        private void LoadDanhSachChonTruocVaoDGV()
        {
            XoaDongDichVu();
            if (this.danhSachDichVuChonTruoc == null) return;

            foreach (var item in this.danhSachDichVuChonTruoc)
            {
                ThemRowDichVuVaoDGV(item.MaDichVu, item.TenDichVu, item.SoLuong, item.DonGia, null);
            }
            TinhTongTien();
        }

        private void ThemRowDichVuVaoDGV(int maDichVu, string tenDichVu, int soLuong, decimal donGia, int? maCTHD)
        {
            int rowIndex = dgvChiTietHoaDon.Rows.Add();
            DataGridViewRow newRow = dgvChiTietHoaDon.Rows[rowIndex];

            newRow.Tag = maCTHD; // Lưu MaCTHD (nếu có) vào Tag
            newRow.Cells["colMaDichVu"].Value = maDichVu;
            newRow.Cells["colTenSanPham"].Value = tenDichVu;
            newRow.Cells["colSoLuong"].Value = soLuong;
            newRow.Cells["colDonGia"].Value = donGia;
            newRow.Cells["colThanhTien"].Value = soLuong * donGia;
        }

        #endregion

        #region UI Helper Methods

        private void CapNhatDongTienGio()
        {
            XoaDongTienGio();
            if (this.banContext == null || this.hoaDonContext == null) return;

            var ketQuaTinhTien = hoaDonBLL.TinhTienGio(this.hoaDonContext.ThoiGianBatDau, DateTime.Now, this.banContext.GiaTheoGio);
            int phutDaTinh = ketQuaTinhTien.Item1;
            decimal tienGioHienTai = ketQuaTinhTien.Item2;

            dgvChiTietHoaDon.Rows.Insert(0, 1);
            var rowTienGio = dgvChiTietHoaDon.Rows[0];
            rowTienGio.Tag = "TIEN_GIO";
            rowTienGio.Cells["colTenSanPham"].Value = $"Tiền giờ ({phutDaTinh} phút)";
            rowTienGio.Cells["colSoLuong"].Value = 1;
            rowTienGio.Cells["colDonGia"].Value = this.banContext.GiaTheoGio; // Hiển thị giá theo giờ
            rowTienGio.Cells["colThanhTien"].Value = tienGioHienTai;

            rowTienGio.ReadOnly = true;
            rowTienGio.DefaultCellStyle.BackColor = Color.LightGray;
            rowTienGio.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            rowTienGio.DefaultCellStyle.ForeColor = Color.Black;
            rowTienGio.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void XoaDongDichVu()
        {
            for (int i = dgvChiTietHoaDon.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvChiTietHoaDon.Rows[i].Tag?.ToString() != "TIEN_GIO")
                {
                    dgvChiTietHoaDon.Rows.RemoveAt(i);
                }
            }
        }

        private void XoaDongTienGio()
        {
            for (int i = dgvChiTietHoaDon.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvChiTietHoaDon.Rows[i].Tag?.ToString() == "TIEN_GIO")
                {
                    dgvChiTietHoaDon.Rows.RemoveAt(i);
                    return;
                }
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["colThanhTien"].Value);
                }
            }
            this.hoaDonContext.TongTien = tongTien; // Cập nhật tổng tiền vào context
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} đ";
        }

        private void ResetPanelThongTin()
        {
            lblTenBan.Text = "CHỌN BÀN";
            lblTrangThai.Text = "Trạng thái:";
            lblGioVao.Text = "Giờ vào: N/A";
            dgvChiTietHoaDon.Rows.Clear();
            lblTongTien.Text = "Tổng tiền: 0 đ";

            this.banContext = null;
            this.hoaDonContext = null;
            this.danhSachDichVuChonTruoc.Clear();

            btnBatDauChoi.Visible = false;
            btnThanhToan.Visible = false;
            btnInHoaDon.Visible = false;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (this.hoaDonContext.ChiTietDichVu == null || !this.hoaDonContext.ChiTietDichVu.Any() || this.hoaDonContext.ChiTietDichVu.Any(ct => string.IsNullOrEmpty(ct.TenDichVu)))
            {
                var hoaDonDayDu = hoaDonBLL.LayHoaDonHienTaiCuaBan(banContext.MaBan);
                CapNhatDongTienGio();
                LoadChiTietDichVuVaoDGV();

                if (hoaDonDayDu != null)
                {
                    this.hoaDonContext = hoaDonDayDu; 
                }
                else
                {
                    MessageBox.Show("Không thể lấy đầy đủ thông tin chi tiết hóa đơn để in.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            HoaDonPrinter printer = new HoaDonPrinter(this.hoaDonContext);
            printer.Preview(); 
        }
        #endregion
    }
}