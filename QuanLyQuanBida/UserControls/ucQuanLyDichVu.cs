using QuanLyQuanBida.BLL;
using QuanLyQuanBida.DTO;
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
        private BanBidaBLL BanBidaBll = new BanBidaBLL();
        private KhachHangBLL KhachHangBLL = new KhachHangBLL();
        private DichVuBLL DichVuBLL = new DichVuBLL();
        private LoaiDichVuBLL LoaiDichVuBLL = new LoaiDichVuBLL();

        //private class DichVu
        //{
        //    public int MaDichVu { get; set; }
        //    public string TenDichVu { get; set; }
        //    public string LoaiDichVu { get; set; }
        //    public string DonViTinh { get; set; }
        //    public decimal Gia { get; set; }
        //}

        private List<DichVuDTO> danhSachDichVu;

        public ucQuanLyDichVu()
        {
            InitializeComponent();
            this.Load += UcQuanLyDichVu_Load;
        }

        private void UcQuanLyDichVu_Load(object sender, EventArgs e)
        {
            LayDanhSachDichVu();
            dgvDichVu.SelectionChanged -= dgvDichVu_SelectionChanged;
            SetupDataGridView();
            LoadDataToGrid();
            LoadLoaiDichVuToComboBox();
            dgvDichVu.SelectionChanged += dgvDichVu_SelectionChanged;
            ClearFields();
        }

        private void LayDanhSachDichVu()
        {
            danhSachDichVu = DichVuBLL.LayDanhSachDichVu();
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
                Width = 120
            };
            colGia.DefaultCellStyle.Format = "N0";
            dgvDichVu.Columns.Add(colGia);
        }

        private void LoadDataToGrid()
        {
            dgvDichVu.DataSource = null;
            dgvDichVu.DataSource = danhSachDichVu;
        }

        private void LoadLoaiDichVuToComboBox()
        {
            var loaiDichVu = LoaiDichVuBLL.LayDanhSachLoaiDichVuToComboBox();

            // ComboBox lọc
            cboLocLoaiDV.Items.Clear();
            cboLocLoaiDV.Items.Add("Tất cả");
            cboLocLoaiDV.Items.AddRange(loaiDichVu.ToArray());
            cboLocLoaiDV.SelectedIndex = 0;

            // ComboBox form nhập
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.AddRange(loaiDichVu.ToArray());
        }

        private void ClearFields()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            cboLoaiDichVu.SelectedIndex = -1;
            txtDonViTinh.Text = "";
            numGiaBan.Value = 0;
            txtTenDichVu.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenDichVu.Text) || cboLoaiDichVu.SelectedIndex < 0 || numGiaBan.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtMaDichVu.Text))
            {
                int maDV = int.Parse(txtMaDichVu.Text);
                var dichVuCanSua = danhSachDichVu.FirstOrDefault(dv => dv.MaDichVu == maDV);
                if (dichVuCanSua != null)
                {
                    dichVuCanSua.TenDichVu = txtTenDichVu.Text;
                    dichVuCanSua.LoaiDichVu = cboLoaiDichVu.Text;
                    dichVuCanSua.DonViTinh = txtDonViTinh.Text;
                    dichVuCanSua.Gia = numGiaBan.Value;
                    MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                int newId = danhSachDichVu.Any() ? danhSachDichVu.Max(dv => dv.MaDichVu) + 1 : 1;
                var dichVuMoi = new DichVuDTO
                {
                    MaDichVu = newId,
                    TenDichVu = txtTenDichVu.Text,
                    LoaiDichVu = cboLoaiDichVu.Text,
                    DonViTinh = txtDonViTinh.Text,
                    Gia = numGiaBan.Value
                };
                danhSachDichVu.Add(dichVuMoi);
                MessageBox.Show("Thêm dịch vụ mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FilterData();
            ClearFields();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maDV = Convert.ToInt32(dgvDichVu.SelectedRows[0].Cells["MaDichVu"].Value);
                    var dichVuCanXoa = danhSachDichVu.FirstOrDefault(dv => dv.MaDichVu == maDV);
                    if (dichVuCanXoa != null)
                    {
                        danhSachDichVu.Remove(dichVuCanXoa);
                        FilterData();
                        ClearFields();
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtMaDichVu.Text = selectedRow.Cells["MaDichVu"].Value.ToString();
                txtTenDichVu.Text = selectedRow.Cells["TenDichVu"].Value.ToString();
                //cboLoaiDichVu.Text = selectedRow.Cells["LoaiDichVu"].Value.ToString();
                txtDonViTinh.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                numGiaBan.Value = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);
            }
        }

        // Hàm lọc dữ liệu dựa trên ô tìm kiếm và combobox
        private void FilterData()
        {
            string tuKhoa = txtTimKiem.Text.ToLower();
            string loaiDVLoc = cboLocLoaiDV.SelectedItem?.ToString() ?? "Tất cả";

            var ketQuaLoc = danhSachDichVu.Where(dv =>
                (string.IsNullOrEmpty(tuKhoa) || dv.TenDichVu.ToLower().Contains(tuKhoa)) &&
                (loaiDVLoc == "Tất cả" || dv.LoaiDichVu == loaiDVLoc)
            ).ToList();

            dgvDichVu.DataSource = null;
            dgvDichVu.DataSource = ketQuaLoc;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cboLocLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
    }
}