using System.Windows.Forms;

namespace QuanLyQuanBida.Forms
{
    partial class frmThemSuaKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMaKhachHangForm = new System.Windows.Forms.Label();
            this.txtMaKhachHangForm = new System.Windows.Forms.TextBox();
            this.lblHoTenForm = new System.Windows.Forms.Label();
            this.txtHoTenForm = new System.Windows.Forms.TextBox();
            this.lblSoDienThoaiForm = new System.Windows.Forms.Label();
            this.txtSoDienThoaiForm = new System.Windows.Forms.TextBox();
            this.lblDiemTichLuyForm = new System.Windows.Forms.Label();
            this.numDiemTichLuyForm = new System.Windows.Forms.NumericUpDown();
            this.lblHangThanhVienForm = new System.Windows.Forms.Label();
            this.txtHangThanhVienForm = new System.Windows.Forms.TextBox();
            this.btnLuuFormKH = new System.Windows.Forms.Button();
            this.btnHuyFormKH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemTichLuyForm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaKhachHangForm
            // 
            this.lblMaKhachHangForm.AutoSize = true;
            this.lblMaKhachHangForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMaKhachHangForm.Location = new System.Drawing.Point(25, 30);
            this.lblMaKhachHangForm.Name = "lblMaKhachHangForm";
            this.lblMaKhachHangForm.Size = new System.Drawing.Size(79, 28);
            this.lblMaKhachHangForm.TabIndex = 0;
            this.lblMaKhachHangForm.Text = "Mã KH:";
            // 
            // txtMaKhachHangForm
            // 
            this.txtMaKhachHangForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaKhachHangForm.Location = new System.Drawing.Point(170, 27);
            this.txtMaKhachHangForm.Name = "txtMaKhachHangForm";
            this.txtMaKhachHangForm.Size = new System.Drawing.Size(280, 34);
            this.txtMaKhachHangForm.TabIndex = 0;
            // 
            // lblHoTenForm
            // 
            this.lblHoTenForm.AutoSize = true;
            this.lblHoTenForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHoTenForm.Location = new System.Drawing.Point(25, 75);
            this.lblHoTenForm.Name = "lblHoTenForm";
            this.lblHoTenForm.Size = new System.Drawing.Size(80, 28);
            this.lblHoTenForm.TabIndex = 2;
            this.lblHoTenForm.Text = "Họ Tên:";
            // 
            // txtHoTenForm
            // 
            this.txtHoTenForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHoTenForm.Location = new System.Drawing.Point(170, 72);
            this.txtHoTenForm.Name = "txtHoTenForm";
            this.txtHoTenForm.Size = new System.Drawing.Size(280, 34);
            this.txtHoTenForm.TabIndex = 1;
            // 
            // lblSoDienThoaiForm
            // 
            this.lblSoDienThoaiForm.AutoSize = true;
            this.lblSoDienThoaiForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSoDienThoaiForm.Location = new System.Drawing.Point(25, 120);
            this.lblSoDienThoaiForm.Name = "lblSoDienThoaiForm";
            this.lblSoDienThoaiForm.Size = new System.Drawing.Size(54, 28);
            this.lblSoDienThoaiForm.TabIndex = 4;
            this.lblSoDienThoaiForm.Text = "SĐT:";
            // 
            // txtSoDienThoaiForm
            // 
            this.txtSoDienThoaiForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSoDienThoaiForm.Location = new System.Drawing.Point(170, 117);
            this.txtSoDienThoaiForm.Name = "txtSoDienThoaiForm";
            this.txtSoDienThoaiForm.Size = new System.Drawing.Size(280, 34);
            this.txtSoDienThoaiForm.TabIndex = 2;
            // 
            // lblDiemTichLuyForm
            // 
            this.lblDiemTichLuyForm.AutoSize = true;
            this.lblDiemTichLuyForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDiemTichLuyForm.Location = new System.Drawing.Point(25, 165);
            this.lblDiemTichLuyForm.Name = "lblDiemTichLuyForm";
            this.lblDiemTichLuyForm.Size = new System.Drawing.Size(133, 28);
            this.lblDiemTichLuyForm.TabIndex = 6;
            this.lblDiemTichLuyForm.Text = "Điểm Tích Lũy:";
            // 
            // numDiemTichLuyForm
            // 
            this.numDiemTichLuyForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numDiemTichLuyForm.Location = new System.Drawing.Point(170, 163);
            this.numDiemTichLuyForm.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDiemTichLuyForm.Name = "numDiemTichLuyForm";
            this.numDiemTichLuyForm.Size = new System.Drawing.Size(280, 34);
            this.numDiemTichLuyForm.TabIndex = 3;
            // 
            // lblHangThanhVienForm
            // 
            this.lblHangThanhVienForm.AutoSize = true;
            this.lblHangThanhVienForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHangThanhVienForm.Location = new System.Drawing.Point(25, 210);
            this.lblHangThanhVienForm.Name = "lblHangThanhVienForm";
            this.lblHangThanhVienForm.Size = new System.Drawing.Size(68, 28);
            this.lblHangThanhVienForm.TabIndex = 8;
            this.lblHangThanhVienForm.Text = "Hạng:";
            // 
            // txtHangThanhVienForm
            // 
            this.txtHangThanhVienForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHangThanhVienForm.Location = new System.Drawing.Point(170, 207);
            this.txtHangThanhVienForm.Name = "txtHangThanhVienForm";
            this.txtHangThanhVienForm.Size = new System.Drawing.Size(280, 34);
            this.txtHangThanhVienForm.TabIndex = 4;
            // 
            // btnLuuFormKH
            // 
            this.btnLuuFormKH.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLuuFormKH.FlatAppearance.BorderSize = 0;
            this.btnLuuFormKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuFormKH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuuFormKH.ForeColor = System.Drawing.Color.White;
            this.btnLuuFormKH.Location = new System.Drawing.Point(170, 270);
            this.btnLuuFormKH.Name = "btnLuuFormKH";
            this.btnLuuFormKH.Size = new System.Drawing.Size(120, 45);
            this.btnLuuFormKH.TabIndex = 5;
            this.btnLuuFormKH.Text = "Lưu";
            this.btnLuuFormKH.UseVisualStyleBackColor = false;
            this.btnLuuFormKH.Click += new System.EventHandler(this.btnLuuFormKH_Click);
            // 
            // btnHuyFormKH
            // 
            this.btnHuyFormKH.BackColor = System.Drawing.Color.Gray;
            this.btnHuyFormKH.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyFormKH.FlatAppearance.BorderSize = 0;
            this.btnHuyFormKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyFormKH.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnHuyFormKH.ForeColor = System.Drawing.Color.White;
            this.btnHuyFormKH.Location = new System.Drawing.Point(300, 270);
            this.btnHuyFormKH.Name = "btnHuyFormKH";
            this.btnHuyFormKH.Size = new System.Drawing.Size(120, 45);
            this.btnHuyFormKH.TabIndex = 6;
            this.btnHuyFormKH.Text = "Hủy";
            this.btnHuyFormKH.UseVisualStyleBackColor = false;
            this.btnHuyFormKH.Click += new System.EventHandler(this.btnHuyFormKH_Click);
            // 
            // frmThemSuaKhachHang
            // 
            this.AcceptButton = this.btnLuuFormKH;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuyFormKH;
            this.ClientSize = new System.Drawing.Size(482, 343);
            this.Controls.Add(this.btnHuyFormKH);
            this.Controls.Add(this.btnLuuFormKH);
            this.Controls.Add(this.txtHangThanhVienForm);
            this.Controls.Add(this.lblHangThanhVienForm);
            this.Controls.Add(this.numDiemTichLuyForm);
            this.Controls.Add(this.lblDiemTichLuyForm);
            this.Controls.Add(this.txtSoDienThoaiForm);
            this.Controls.Add(this.lblSoDienThoaiForm);
            this.Controls.Add(this.txtHoTenForm);
            this.Controls.Add(this.lblHoTenForm);
            this.Controls.Add(this.txtMaKhachHangForm);
            this.Controls.Add(this.lblMaKhachHangForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSuaKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Khách Hàng";
            this.Load += new System.EventHandler(this.frmThemSuaKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDiemTichLuyForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblMaKhachHangForm;
        private System.Windows.Forms.TextBox txtMaKhachHangForm;
        private System.Windows.Forms.Label lblHoTenForm;
        private System.Windows.Forms.TextBox txtHoTenForm;
        private System.Windows.Forms.Label lblSoDienThoaiForm;
        private System.Windows.Forms.TextBox txtSoDienThoaiForm;
        private System.Windows.Forms.Label lblDiemTichLuyForm;
        private System.Windows.Forms.NumericUpDown numDiemTichLuyForm;
        private System.Windows.Forms.Label lblHangThanhVienForm;
        private System.Windows.Forms.TextBox txtHangThanhVienForm;
        private System.Windows.Forms.Button btnLuuFormKH;
        private System.Windows.Forms.Button btnHuyFormKH;
    }
}