using QuanLyQuanBida.BLL.QuanLyQuanBida.BLL;
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
    public partial class frmThemSuaKhachHang : Form
    {
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private KhachHangDTO currentKhachHang;
        private bool isEditMode = false;

        public KhachHangDTO SavedKhachHang { get; private set; }

        public frmThemSuaKhachHang() // Chế độ Thêm mới
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Thêm Khách Hàng Mới";
            txtMaKhachHangForm.Text = "(Tự động)";
            txtMaKhachHangForm.ReadOnly = true;
            txtHangThanhVienForm.ReadOnly = true; 
            numDiemTichLuyForm.ValueChanged += NumDiemTichLuyForm_ValueChanged; // Để cập nhật hạng
            UpdateHangThanhVienDisplay();
        }

        public frmThemSuaKhachHang(KhachHangDTO khachHangToEdit)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Sửa Thông Tin Khách Hàng";
            currentKhachHang = khachHangToEdit;
            txtMaKhachHangForm.ReadOnly = true;
            txtHangThanhVienForm.ReadOnly = true;
            numDiemTichLuyForm.ValueChanged += NumDiemTichLuyForm_ValueChanged;
        }

        private void frmThemSuaKhachHang_Load(object sender, EventArgs e)
        {
            if (isEditMode && currentKhachHang != null)
            {
                PopulateDataForEdit();
            }
        }

        private void PopulateDataForEdit()
        {
            txtMaKhachHangForm.Text = currentKhachHang.MaKhachHang.ToString();
            txtHoTenForm.Text = currentKhachHang.HoTen;
            txtSoDienThoaiForm.Text = currentKhachHang.SoDienThoai;
            numDiemTichLuyForm.Value = currentKhachHang.DiemTichLuy;
            txtHangThanhVienForm.Text = currentKhachHang.HangThanhVien; // Hạng đã có
        }

        private void NumDiemTichLuyForm_ValueChanged(object sender, EventArgs e)
        {
            UpdateHangThanhVienDisplay();
        }

        private void UpdateHangThanhVienDisplay()
        {
            int diem = (int)numDiemTichLuyForm.Value;
            txtHangThanhVienForm.Text = khachHangBLL.XacDinhHangThanhVien(diem);
        }

        private void btnLuuFormKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTenForm.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTenForm.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoaiForm.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoaiForm.Focus();
                return;
            }
            // Có thể thêm validate SĐT (ví dụ: chỉ chứa số, độ dài)

            KhachHangDTO khachHangData = new KhachHangDTO
            {
                HoTen = txtHoTenForm.Text.Trim(),
                SoDienThoai = txtSoDienThoaiForm.Text.Trim(),
                DiemTichLuy = (int)numDiemTichLuyForm.Value,
                HangThanhVien = txtHangThanhVienForm.Text // Hạng đã được cập nhật
            };

            try
            {
                if (isEditMode)
                {
                    khachHangData.MaKhachHang = currentKhachHang.MaKhachHang;
                    bool success = khachHangBLL.SuaKhachHang(khachHangData);
                    if (success)
                    {
                        SavedKhachHang = khachHangData;
                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Khách hàng có thể không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Thêm mới
                {
                    SavedKhachHang = khachHangBLL.ThemKhachHang(khachHangData);
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (InvalidOperationException exOp) // Lỗi nghiệp vụ (SĐT trùng)
            {
                MessageBox.Show(exOp.Message, "Lỗi Nghiệp Vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyFormKH_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
