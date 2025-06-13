using QuanLyQuanBida.BLL; // Thêm BLL
using QuanLyQuanBida.BLL.QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO; // Thêm DTO
using QuanLyQuanBida.Forms; // Thêm Forms
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucQuanLyKhachHang : UserControl
    {
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private List<KhachHangDTO> danhSachKhachHangFull;
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
            this.Load += UcQuanLyKhachHang_Load; 
        }

        private void UcQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.SelectionChanged -= dgvKhachHang_SelectionChanged;

            SetupDataGridView();
            RefreshDataAndGrid();

            MakeInputFieldsReadOnly();
            ClearFields();

            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
        }

        private void RefreshDataAndGrid()
        {
            danhSachKhachHangFull = khachHangBLL.LayDanhSachKhachHangDayDu();
            FilterDataGrid(); // Lọc và hiển thị
            if (dgvKhachHang.Rows.Count > 0)
            {
                dgvKhachHang.ClearSelection();
            }
            else
            {
                ClearFields();
            }
        }

        private void MakeInputFieldsReadOnly()
        {
            txtMaKhachHang.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            numDiemTichLuy.ReadOnly = true;
            numDiemTichLuy.Increment = 0;
            txtHangThanhVien.ReadOnly = true;
        }


        private void SetupDataGridView()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();

            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKhachHang", HeaderText = "Mã KH", DataPropertyName = "MaKhachHang", Width = 80 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ Tên", DataPropertyName = "HoTen", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "Số Điện Thoại", DataPropertyName = "SoDienThoai", Width = 150 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTichLuy", HeaderText = "Điểm", DataPropertyName = "DiemTichLuy", Width = 80 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "HangThanhVien", HeaderText = "Hạng", DataPropertyName = "HangThanhVien", Width = 120 });
        }

        private void FilterDataGrid() // Đổi tên từ LoadDataToGrid
        {
            if (danhSachKhachHangFull == null) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();
            var filteredList = danhSachKhachHangFull
                .Where(kh => string.IsNullOrEmpty(tuKhoa) ||
                             kh.HoTen.ToLower().Contains(tuKhoa) ||
                             kh.SoDienThoai.Contains(tuKhoa))
                .ToList();

            dgvKhachHang.DataSource = null;
            if (filteredList.Any())
            {
                dgvKhachHang.DataSource = filteredList;
            }
        }

        private void ClearFields()
        {
            txtMaKhachHang.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            numDiemTichLuy.Value = 0;
            txtHangThanhVien.Text = ""; // Hạng sẽ được cập nhật khi chọn dòng
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemSuaKhachHang formThemKH = new frmThemSuaKhachHang())
            {
                if (formThemKH.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataAndGrid();
                    if (formThemKH.SavedKhachHang != null)
                    {
                        SelectRowByMaKhachHang(formThemKH.SavedKhachHang.MaKhachHang);
                    }
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e) 
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
                var khachHangCanSua = khachHangBLL.LayThongTinKhachHang(maKH); // Lấy thông tin mới nhất

                if (khachHangCanSua != null)
                {
                    using (frmThemSuaKhachHang formSuaKH = new frmThemSuaKhachHang(khachHangCanSua))
                    {
                        if (formSuaKH.ShowDialog() == DialogResult.OK)
                        {
                            RefreshDataAndGrid();
                            if (formSuaKH.SavedKhachHang != null)
                            {
                                SelectRowByMaKhachHang(formSuaKH.SavedKhachHang.MaKhachHang);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để sửa. Vui lòng làm mới danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                string tenKH = dgvKhachHang.SelectedRows[0].Cells["HoTen"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{tenKH}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);
                    try
                    {
                        bool success = khachHangBLL.XoaKhachHang(maKH);
                        if (success)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataAndGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Xóa khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidOperationException exOp)
                    {
                        MessageBox.Show(exOp.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                numDiemTichLuy.Value = Convert.ToDecimal(row.Cells["DiemTichLuy"].Value ?? 0);
                txtHangThanhVien.Text = row.Cells["HangThanhVien"].Value?.ToString() ?? "";
            }
            else
            {
                ClearFields();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterDataGrid();
        }

        private void SelectRowByMaKhachHang(int maKH)
        {
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (row.Cells["MaKhachHang"].Value != null && (int)row.Cells["MaKhachHang"].Value == maKH)
                {
                    row.Selected = true;
                    dgvKhachHang.CurrentCell = row.Cells[1]; // Focus vào cột Họ Tên
                    return;
                }
            }
        }
        // Loại bỏ btnLuu_Click
    }
}