using QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
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
    public partial class frmThemSuaDichVu : Form
    {
        private DichVuBLL dichVuBLL = new DichVuBLL();
        private LoaiDichVuBLL loaiDichVuBLL = new LoaiDichVuBLL();
        private DichVuDTO currentDichVu;
        private bool isEditMode = false;

        public DichVuDTO SavedDichVu { get; private set; } // Để truyền DTO đã lưu về UC

        // Constructor cho chế độ Thêm mới
        public frmThemSuaDichVu()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Thêm Dịch Vụ Mới";
            // txtMaDichVuForm.Visible = false; // Hoặc ReadOnly và trống
            // lblMaDichVuForm.Visible = false; // Ẩn label và textbox mã khi thêm mới
            txtMaDichVuForm.ReadOnly = true;
            txtMaDichVuForm.Text = "(Tự động)";
        }

        // Constructor cho chế độ Sửa
        public frmThemSuaDichVu(DichVuDTO dichVuToEdit)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Sửa Thông Tin Dịch Vụ";
            currentDichVu = dichVuToEdit;
            // txtMaDichVuForm.Visible = true;
            // lblMaDichVuForm.Visible = true;
            txtMaDichVuForm.ReadOnly = true;
        }

        private void frmThemSuaDichVu_Load(object sender, EventArgs e)
        {
            LoadLoaiDichVuComboBox();
            if (isEditMode && currentDichVu != null)
            {
                PopulateDataForEdit();
            }
        }

        private void LoadLoaiDichVuComboBox()
        {
            var danhSachLoaiDV = loaiDichVuBLL.LayDanhSachLoaiDichVuDayDu();
            cboLoaiDichVuForm.DataSource = danhSachLoaiDV;
            cboLoaiDichVuForm.DisplayMember = "TenLoaiDV";
            cboLoaiDichVuForm.ValueMember = "MaLoaiDV";
            cboLoaiDichVuForm.SelectedIndex = -1;
        }

        private void PopulateDataForEdit()
        {
            txtMaDichVuForm.Text = currentDichVu.MaDichVu.ToString();
            txtTenDichVuForm.Text = currentDichVu.TenDichVu;
            // Chọn đúng loại dịch vụ trong ComboBox
            if (currentDichVu.MaLoaiDV.HasValue)
            {
                cboLoaiDichVuForm.SelectedValue = currentDichVu.MaLoaiDV.Value;
            }
            else if (!string.IsNullOrEmpty(currentDichVu.LoaiDichVu)) // Fallback nếu MaLoaiDV null nhưng Ten có
            {
                // Tìm theo tên (ít ưu tiên hơn)
                var loaiDVObj = (List<LoaiDichVuDTO>)cboLoaiDichVuForm.DataSource;
                var selected = loaiDVObj.FirstOrDefault(x => x.TenLoaiDV == currentDichVu.LoaiDichVu);
                if (selected != null) cboLoaiDichVuForm.SelectedValue = selected.MaLoaiDV;
            }

            txtDonViTinhForm.Text = currentDichVu.DonViTinh;
            numGiaBanForm.Value = currentDichVu.Gia;
        }

        private void btnLuuForm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDichVuForm.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDichVuForm.Focus();
                return;
            }
            if (cboLoaiDichVuForm.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiDichVuForm.Focus();
                return;
            }
            if (numGiaBanForm.Value <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numGiaBanForm.Focus();
                return;
            }

            DichVuDTO dichVuData = new DichVuDTO
            {
                TenDichVu = txtTenDichVuForm.Text.Trim(),
                MaLoaiDV = (int)cboLoaiDichVuForm.SelectedValue,
                LoaiDichVu = cboLoaiDichVuForm.Text, // Lấy TenLoaiDV để hiển thị ngay
                DonViTinh = txtDonViTinhForm.Text.Trim(),
                Gia = numGiaBanForm.Value
            };

            try
            {
                if (isEditMode)
                {
                    dichVuData.MaDichVu = currentDichVu.MaDichVu;
                    bool success = dichVuBLL.SuaDichVu(dichVuData);
                    if (success)
                    {
                        SavedDichVu = dichVuData; // Gán DTO với dữ liệu đã cập nhật
                        MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dịch vụ thất bại. Dịch vụ có thể không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Chế độ Thêm mới
                {
                    SavedDichVu = dichVuBLL.ThemDichVu(dichVuData); // BLL trả về DTO với MaDV mới
                    MessageBox.Show("Thêm dịch vụ mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
