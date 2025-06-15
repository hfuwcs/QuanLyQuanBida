using Helper;
using QuanLyQuanBida.BLL;
using QuanLyQuanBida.BLL.QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBida.Forms
{
    public partial class frmBatDauChoi : Form
    {
        private KhachHangBLL KhachHangBLL = new KhachHangBLL();
        private BindingList<KhachHangDTO> danhSachHienThi;
        private int pageNumber = 1;
        private const int pageSize = 50;
        private bool hasMoreData = true;

        private readonly KhachHangDTO taiThemItem = new KhachHangDTO { MaKhachHang = -1, HoTenVaSDT = "[Tải thêm...]" };

        public int MaKhachHangChon { get; private set; }
        public string TenKhachVangLai { get; private set; }

        public frmBatDauChoi(string tenBan)
        {
            InitializeComponent();
            lblTitle.Text += tenBan;

            danhSachHienThi = new BindingList<KhachHangDTO>();
            cboKhachHang.DataSource = danhSachHienThi;
            cboKhachHang.DisplayMember = "HoTenVaSDT";
            cboKhachHang.ValueMember = "MaKhachHang";

            radThanhVien.CheckedChanged += RadioButton_CheckedChanged;
            radVangLai.CheckedChanged += RadioButton_CheckedChanged;
            txtTimKiemKH.KeyDown += TxtTimKiemKH_KeyDown;
            cboKhachHang.SelectionChangeCommitted += CboKhachHang_SelectionChangeCommitted;

            radThanhVien.Checked = true;
            RadioButton_CheckedChanged(null, null);
            LoadKhachHangThanhVien(isNewSearch: true);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isThanhVien = radThanhVien.Checked;
            cboKhachHang.Enabled = isThanhVien;
            txtTimKiemKH.Enabled = isThanhVien;
            txtKhachVangLai.Enabled = !isThanhVien;

            if (!isThanhVien)
            {
                txtKhachVangLai.Focus();
                txtTimKiemKH.Text = "";
            }
            else
            {
                cboKhachHang.Focus();
            }
        }

        private void LoadKhachHangThanhVien(bool isNewSearch = false)
        {
            if (isNewSearch)
            {
                pageNumber = 1;
                danhSachHienThi.Clear();
                hasMoreData = true;
            }

            if (danhSachHienThi.Any(kh => kh.MaKhachHang == -1))
            {
                danhSachHienThi.RemoveAt(danhSachHienThi.Count - 1);
            }

            if (!hasMoreData) return;

            string searchTerm = txtTimKiemKH.Text.Trim();
            var newList = KhachHangBLL.LayDanhSachThanhVien(pageNumber, pageSize, searchTerm);

            if (newList != null)
            {
                foreach (var kh in newList) danhSachHienThi.Add(kh);
                if (newList.Count < pageSize)
                {
                    hasMoreData = false;
                }
                else
                {
                    danhSachHienThi.Add(taiThemItem);
                }
                pageNumber++;
            }
        }

        private void CboKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue != null && (int)cboKhachHang.SelectedValue == -1)
            {
                int currentSelectedIndex = cboKhachHang.SelectedIndex;
                LoadKhachHangThanhVien();
                cboKhachHang.DroppedDown = true; 
                if (cboKhachHang.Items.Count > currentSelectedIndex)
                {
                    cboKhachHang.SelectedIndex = currentSelectedIndex;
                }
            }
        }

        private void TxtTimKiemKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadKhachHangThanhVien(isNewSearch: true);
                e.SuppressKeyPress = true;
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (radThanhVien.Checked)
            {
                if (cboKhachHang.SelectedValue == null || (int)cboKhachHang.SelectedValue == -1)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng thành viên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MaKhachHangChon = (int)cboKhachHang.SelectedValue;
                TenKhachVangLai = null;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtKhachVangLai.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách vãng lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MaKhachHangChon = AppSettings.VangLaiCustomerId;
                TenKhachVangLai = txtKhachVangLai.Text.Trim();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}