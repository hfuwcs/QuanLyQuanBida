using QuanLyQuanBida.DTO;
using QuanLyQuanBida.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBida
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static NhanVienDTO NhanVienHienTai = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin loginForm = new frmLogin();
            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                NhanVienHienTai = loginForm.NhanVienLogin;

                Application.Run(new frmMain());
            }
        }
    }
}
