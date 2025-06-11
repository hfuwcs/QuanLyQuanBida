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
        //DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();
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

            var danhSachKH= db.KhachHang.Select(kh => new
            {
                MaKhachHang = kh.MaKhachHang,
                HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai
            }).ToList();
            cboKhachHang.DataSource = danhSachKH;
            cboKhachHang.DisplayMember = "HoTenVaSDT";
            cboKhachHang.ValueMember = "MaKhachHang";
            cboKhachHang.SelectedIndex = -1;
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            int MaKhachHang = cboKhachHang.SelectedValue != null ? (int)cboKhachHang.SelectedValue : 0;
            if (MaKhachHang == 0 && string.IsNullOrWhiteSpace(txtKhachVangLai.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng hoặc nhập tên khách vãng lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MaKhachHang > 0 || !string.IsNullOrWhiteSpace(txtKhachVangLai.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng hoặc nhập tên khách vãng lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
