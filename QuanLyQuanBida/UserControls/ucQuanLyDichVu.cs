using QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
using QuanLyQuanBida.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucQuanLyDichVu : UserControl
    {
        private DichVuBLL dichVuBLL = new DichVuBLL(); 
        private LoaiDichVuBLL loaiDichVuBLL = new LoaiDichVuBLL();

        private List<DichVuDTO> danhSachDichVuFull; 

        public ucQuanLyDichVu()
        {
            InitializeComponent();
            UcQuanLyDichVu_Load();
        }

        private void UcQuanLyDichVu_Load()
        {
            dgvDichVu.SelectionChanged -= dgvDichVu_SelectionChanged;

            SetupDataGridView();
            LoadLoaiDichVuToComboBoxes();
            RefreshDataAndGrid();

            dgvDichVu.SelectionChanged += dgvDichVu_SelectionChanged;
            MakeInputFieldsReadOnly();
            ClearFields(); 
        }

        private void RefreshDataAndGrid()
        {
            danhSachDichVuFull = dichVuBLL.LayDanhSachDichVu("All"); 
            FilterData();
            if (dgvDichVu.Rows.Count > 0)
            {
                dgvDichVu.ClearSelection(); // Bỏ chọn dòng hiện tại (nếu có)
                // dgvDichVu.Rows[0].Selected = true; // Hoặc chọn dòng đầu tiên nếu muốn
            }
            else
            {
                ClearFields();
            }
        }

        private void MakeInputFieldsReadOnly()
        {
            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.ReadOnly = true;
            cboLoaiDichVu.Enabled = false;
            txtDonViTinh.ReadOnly = true;
            numGiaBan.ReadOnly = true;
            numGiaBan.Increment = 0; 
        }


        private void SetupDataGridView()
        {
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.Columns.Clear();

            var colMaDV = new DataGridViewTextBoxColumn
            {
                Name = "MaDichVu",
                HeaderText = "Mã DV",
                DataPropertyName = "MaDichVu",
                Width = 80
            };
            dgvDichVu.Columns.Add(colMaDV);
            var colTenDV = new DataGridViewTextBoxColumn
            {
                Name = "TenDichVu",
                HeaderText = "Tên Dịch Vụ",
                DataPropertyName = "TenDichVu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvDichVu.Columns.Add(colTenDV);

            var colLoaiDV = new DataGridViewTextBoxColumn
            {
                Name = "LoaiDichVu",
                HeaderText = "Loại Dịch Vụ",
                DataPropertyName = "LoaiDichVu",
                Width = 150
            };
            dgvDichVu.Columns.Add(colLoaiDV);

            var colDVT = new DataGridViewTextBoxColumn
            {
                Name = "DonViTinh",
                HeaderText = "ĐVT",
                DataPropertyName = "DonViTinh",
                Width = 80
            };
            dgvDichVu.Columns.Add(colDVT);

            var colGia = new DataGridViewTextBoxColumn
            {
                Name = "Gia",
                HeaderText = "Giá Bán",
                DataPropertyName = "Gia",
                Width = 120,
                DefaultCellStyle = { Format = "N0" }
            };
            dgvDichVu.Columns.Add(colGia);
        }

        private void LoadLoaiDichVuToComboBoxes()
        {
            var tenLoaiDichVuList = loaiDichVuBLL.LayDanhSachTenLoaiDichVu();

            // ComboBox lọc
            cboLocLoaiDV.Items.Clear();
            cboLocLoaiDV.Items.Add("Tất cả");
            cboLocLoaiDV.Items.AddRange(tenLoaiDichVuList.ToArray());
            if (cboLocLoaiDV.Items.Count > 0) cboLocLoaiDV.SelectedIndex = 0;

            // ComboBox trên panel hiển thị (không dùng để nhập nữa)
            // Nếu bạn vẫn muốn cboLoaiDichVu hiển thị đúng tên loại, có thể làm như sau:
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.AddRange(tenLoaiDichVuList.ToArray());
        }

        private void ClearFields()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            cboLoaiDichVu.SelectedIndex = -1; // Hoặc cboLoaiDichVu.Text = "";
            txtDonViTinh.Text = "";
            numGiaBan.Value = 0;
            // txtTenDichVu.Focus(); // Không cần focus vì panel là read-only
        }

        // Nút Thêm (mở form thêm mới)
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemSuaDichVu formThem = new frmThemSuaDichVu())
            {
                if (formThem.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataAndGrid(); // Tải lại dữ liệu sau khi thêm thành công
                    // Tùy chọn: tìm và chọn dòng mới được thêm
                    if (formThem.SavedDichVu != null)
                    {
                        SelectRowByMaDichVu(formThem.SavedDichVu.MaDichVu);
                    }
                }
            }
        }

        // Bạn cần thêm một nút "Sửa" vào `ucQuanLyDichVu.Designer.cs`
        // Giả sử nút đó tên là btnSua
        private void btnSua_Click(object sender, EventArgs e) // Tạo event handler cho nút Sửa mới
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                int maDV = Convert.ToInt32(dgvDichVu.SelectedRows[0].Cells["MaDichVu"].Value);
                // Lấy DTO đầy đủ từ danh sách gốc hoặc query lại từ DB để đảm bảo dữ liệu mới nhất
                var dichVuCanSua = danhSachDichVuFull.FirstOrDefault(dv => dv.MaDichVu == maDV);
                // Hoặc: var dichVuCanSua = dichVuBLL.LayDichVuTheoID(maDV);

                if (dichVuCanSua != null)
                {
                    using (frmThemSuaDichVu formSua = new frmThemSuaDichVu(dichVuCanSua))
                    {
                        if (formSua.ShowDialog() == DialogResult.OK)
                        {
                            RefreshDataAndGrid();
                            if (formSua.SavedDichVu != null)
                            {
                                SelectRowByMaDichVu(formSua.SavedDichVu.MaDichVu);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ để sửa. Vui lòng làm mới danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                string tenDV = dgvDichVu.SelectedRows[0].Cells["TenDichVu"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa dịch vụ '{tenDV}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maDV = Convert.ToInt32(dgvDichVu.SelectedRows[0].Cells["MaDichVu"].Value);
                    try
                    {
                        bool success = dichVuBLL.XoaDichVu(maDV);
                        if (success)
                        {
                            MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataAndGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Xóa dịch vụ thất bại. Dịch vụ không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidOperationException exOp) // Bắt lỗi nghiệp vụ (ví dụ: đang sử dụng)
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
                MessageBox.Show("Vui lòng chọn một dịch vụ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDichVu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDichVu.SelectedRows[0];
                txtMaDichVu.Text = selectedRow.Cells["MaDichVu"].Value?.ToString() ?? "";
                txtTenDichVu.Text = selectedRow.Cells["TenDichVu"].Value?.ToString() ?? "";

                string tenLoaiDV = selectedRow.Cells["LoaiDichVu"].Value?.ToString() ?? "";
                // Tìm và chọn item trong ComboBox cboLoaiDichVu (panel hiển thị)
                int index = cboLoaiDichVu.FindStringExact(tenLoaiDV);
                if (index != -1) cboLoaiDichVu.SelectedIndex = index;
                else cboLoaiDichVu.SelectedIndex = -1; // Hoặc cboLoaiDichVu.Text = tenLoaiDV;

                txtDonViTinh.Text = selectedRow.Cells["DonViTinh"].Value?.ToString() ?? "";
                numGiaBan.Value = Convert.ToDecimal(selectedRow.Cells["Gia"].Value ?? 0);
            }
            else
            {
                ClearFields();
            }
        }

        private void FilterData()
        {
            if (danhSachDichVuFull == null) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();
            string loaiDVLoc = cboLocLoaiDV.SelectedItem?.ToString() ?? "Tất cả";

            var ketQuaLoc = danhSachDichVuFull.Where(dv =>
                (string.IsNullOrEmpty(tuKhoa) || dv.TenDichVu.ToLower().Contains(tuKhoa)) &&
                (loaiDVLoc == "Tất cả" || dv.LoaiDichVu == loaiDVLoc)
            ).ToList();

            dgvDichVu.DataSource = null;
            if (ketQuaLoc.Any())
            {
                dgvDichVu.DataSource = ketQuaLoc;
            }
            // else dgvDichVu.Rows.Clear(); // Nếu muốn xóa trắng grid khi không có kết quả
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cboLocLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectRowByMaDichVu(int maDichVu)
        {
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.Cells["MaDichVu"].Value != null && (int)row.Cells["MaDichVu"].Value == maDichVu)
                {
                    row.Selected = true;
                    dgvDichVu.CurrentCell = row.Cells[1];
                    return;
                }
            }
        }

    }
}