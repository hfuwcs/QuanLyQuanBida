using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBida.Forms
{
    public partial class frmBatDauChoi : Form
    {
        public int? MaKhachHangChon { get; private set; }
        public string TenKhachVangLai { get; private set; }

        public frmBatDauChoi(string tenBan)
        {
            InitializeComponent();
            lblTitle.Text += tenBan; 
            LoadKhachHang();

            this.btnBatDau.Click += (s, e) => {
                if (cboKhachHang.SelectedValue != null)
                {
                    MaKhachHangChon = (int)cboKhachHang.SelectedValue;
                }
                TenKhachVangLai = txtKhachVangLai.Text;
            };
        }

        private void LoadKhachHang()
        {
            // --- PHẦN NGHIỆP VỤ CỦA BẠN ---
            // Đây là nơi bạn sẽ truy vấn CSDL để lấy danh sách khách hàng
            // và đổ vào ComboBox cboKhachHang.
            // Ví dụ:
            /*
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var danhSachKH = db.KhachHangs
                                   .Select(kh => new { kh.MaKhachHang, HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai })
                                   .ToList();

                cboKhachHang.DataSource = danhSachKH;
                cboKhachHang.DisplayMember = "HoTenVaSDT"; // Hiển thị tên và sđt
                cboKhachHang.ValueMember = "MaKhachHang";   // Giá trị thực là Mã KH
                cboKhachHang.SelectedIndex = -1; // Không chọn ai mặc định
            }
            */

            // Dữ liệu mẫu để demo
            var danhSachKHMau = new[] {
                new { MaKhachHang = 1, HoTenVaSDT = "Nguyễn Phi Hùng - 0901234567" },
                new { MaKhachHang = 2, HoTenVaSDT = "Trần Phạm Trọng Nhân - 0987654321" },
                new { MaKhachHang = 3, HoTenVaSDT = "Lưu Hoàng Phúc - 0123456789" }
            }.ToList();
            cboKhachHang.DataSource = danhSachKHMau;
            cboKhachHang.DisplayMember = "HoTenVaSDT";
            cboKhachHang.ValueMember = "MaKhachHang";
            cboKhachHang.SelectedIndex = -1;
        }
    }
}
