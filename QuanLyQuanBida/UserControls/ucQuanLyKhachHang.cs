using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucQuanLyKhachHang : UserControl
    {
        // Lớp nội bộ để lưu trữ dữ liệu mẫu
        private class KhachHang
        {
            public int MaKhachHang { get; set; }
            public string HoTen { get; set; }
            public string SoDienThoai { get; set; }
            public int DiemTichLuy { get; set; }
            public string HangThanhVien { get; set; }
        }

        // Danh sách dữ liệu mẫu
        private List<KhachHang> danhSachKhachHang;

        public ucQuanLyKhachHang()
        {
            InitializeComponent();
            this.Load += UcQuanLyKhachHang_Load;
        }

        private void UcQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            SetupDataGridView();
            LoadDataToGrid();
            ClearFields();
        }

        private void TaoDuLieuMau()
        {
            danhSachKhachHang = new List<KhachHang>
            {
                new KhachHang { MaKhachHang = 1, HoTen = "Nguyễn Phi Hùng", SoDienThoai = "0901234567", DiemTichLuy = 150, HangThanhVien = "Bạc" },
                new KhachHang { MaKhachHang = 2, HoTen = "Trần Phạm Trọng Nhân", SoDienThoai = "0987654321", DiemTichLuy = 550, HangThanhVien = "Vàng" },
                new KhachHang { MaKhachHang = 3, HoTen = "Lưu Hoàng Phúc", SoDienThoai = "0123456789", DiemTichLuy = 1200, HangThanhVien = "Kim Cương" },
                new KhachHang { MaKhachHang = 4, HoTen = "Lê Thị Lan", SoDienThoai = "0334455667", DiemTichLuy = 50, HangThanhVien = "Thân thiết" }
            };
        }

        private void SetupDataGridView()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();
            
            var colMaKhahHang = new DataGridViewTextBoxColumn
            {
                Name = "MaKhachHang",
                HeaderText = "Mã KH",
                DataPropertyName = "MaKhachHang",
                Width = 80
            };
            dgvKhachHang.Columns.Add(colMaKhahHang);
            
            var colHoTen = new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ Tên",
                DataPropertyName = "HoTen",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvKhachHang.Columns.Add(colHoTen);

            var colSoDienThoai = new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                HeaderText = "Số Điện Thoại",
                DataPropertyName = "SoDienThoai",
                Width = 150
            };
            dgvKhachHang.Columns.Add(colSoDienThoai);

            var colDiemTichLuy = new DataGridViewTextBoxColumn
            {
                Name = "DiemTichLuy",
                HeaderText = "Điểm",
                DataPropertyName = "DiemTichLuy",
                Width = 80
            };
            dgvKhachHang.Columns.Add(colDiemTichLuy);

            var colHangThanhVien = new DataGridViewTextBoxColumn
            {
                Name = "HangThanhVien",
                HeaderText = "Hạng",
                DataPropertyName = "HangThanhVien",
                Width = 120
            };
            dgvKhachHang.Columns.Add(colHangThanhVien);
        }

        private void LoadDataToGrid()
        {
            var tuKhoa = txtTimKiem.Text.ToLower();
            var filteredList = danhSachKhachHang
                .Where(kh => string.IsNullOrEmpty(tuKhoa) ||
                             kh.HoTen.ToLower().Contains(tuKhoa) ||
                             kh.SoDienThoai.Contains(tuKhoa))
                .ToList();

            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = filteredList;
        }

        private void ClearFields()
        {
            txtMaKhachHang.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            numDiemTichLuy.Value = 0;
            txtHangThanhVien.Text = "Thân thiết";
            txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtMaKhachHang.Text)) // Sửa
            {
                int maKH = int.Parse(txtMaKhachHang.Text);
                var khachHang = danhSachKhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKH);
                if (khachHang != null)
                {
                    khachHang.HoTen = txtHoTen.Text;
                    khachHang.SoDienThoai = txtSoDienThoai.Text;
                    khachHang.DiemTichLuy = (int)numDiemTichLuy.Value;
                    khachHang.HangThanhVien = txtHangThanhVien.Text;
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else // Thêm mới
            {
                int newId = danhSachKhachHang.Any() ? danhSachKhachHang.Max(kh => kh.MaKhachHang) + 1 : 1;
                var khachHangMoi = new KhachHang
                {
                    MaKhachHang = newId,
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    DiemTichLuy = (int)numDiemTichLuy.Value,
                    HangThanhVien = txtHangThanhVien.Text
                };
                danhSachKhachHang.Add(khachHangMoi);
                MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDataToGrid();
            ClearFields();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
                    var khachHang = danhSachKhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKH);
                    if (khachHang != null)
                    {
                        danhSachKhachHang.Remove(khachHang);
                        LoadDataToGrid();
                        ClearFields();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhachHang.SelectedRows[0];
                txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                numDiemTichLuy.Value = Convert.ToDecimal(row.Cells["DiemTichLuy"].Value);
                txtHangThanhVien.Text = row.Cells["HangThanhVien"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }
    }
}