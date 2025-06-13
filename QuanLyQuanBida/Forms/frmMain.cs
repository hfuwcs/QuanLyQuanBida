using QuanLyQuanBida.DTO;
using QuanLyQuanBida.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBida
{
    public partial class frmMain : Form
    {
        private Button currentButton;
        public static int MaNhanVien { get; set; } = Program.NhanVienHienTai.MaNhanVien;
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnSoDoBan.PerformClick();
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.FromArgb(0, 122, 204);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                    lblTitle.Text = currentButton.Text.ToUpper();
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(37, 37, 38);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }

        private void btnSoDoBan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new ucSoDoBan());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new ucQuanLyDichVu());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new ucQuanLyKhachHang());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new ucBaoCao());
        }
    }
}