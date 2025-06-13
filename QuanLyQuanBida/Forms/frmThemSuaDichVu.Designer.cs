using System.Windows.Forms;

namespace QuanLyQuanBida.Forms
{
    partial class frmThemSuaDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMaDichVuForm = new System.Windows.Forms.Label();
            this.txtMaDichVuForm = new System.Windows.Forms.TextBox();
            this.lblTenDichVuForm = new System.Windows.Forms.Label();
            this.txtTenDichVuForm = new System.Windows.Forms.TextBox();
            this.lblLoaiDichVuForm = new System.Windows.Forms.Label();
            this.cboLoaiDichVuForm = new System.Windows.Forms.ComboBox();
            this.lblDonViTinhForm = new System.Windows.Forms.Label();
            this.txtDonViTinhForm = new System.Windows.Forms.TextBox();
            this.lblGiaBanForm = new System.Windows.Forms.Label();
            this.numGiaBanForm = new System.Windows.Forms.NumericUpDown();
            this.btnLuuForm = new System.Windows.Forms.Button();
            this.btnHuyForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBanForm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaDichVuForm
            // 
            this.lblMaDichVuForm.AutoSize = true;
            this.lblMaDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDichVuForm.Location = new System.Drawing.Point(30, 30);
            this.lblMaDichVuForm.Name = "lblMaDichVuForm";
            this.lblMaDichVuForm.Size = new System.Drawing.Size(120, 28);
            this.lblMaDichVuForm.TabIndex = 0;
            this.lblMaDichVuForm.Text = "Mã Dịch Vụ:";
            // 
            // txtMaDichVuForm
            // 
            this.txtMaDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDichVuForm.Location = new System.Drawing.Point(170, 27);
            this.txtMaDichVuForm.Name = "txtMaDichVuForm";
            this.txtMaDichVuForm.ReadOnly = true;
            this.txtMaDichVuForm.Size = new System.Drawing.Size(280, 34);
            this.txtMaDichVuForm.TabIndex = 0; // TabIndex 0, nhưng ReadOnly
            // 
            // lblTenDichVuForm
            // 
            this.lblTenDichVuForm.AutoSize = true;
            this.lblTenDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDichVuForm.Location = new System.Drawing.Point(30, 75);
            this.lblTenDichVuForm.Name = "lblTenDichVuForm";
            this.lblTenDichVuForm.Size = new System.Drawing.Size(121, 28);
            this.lblTenDichVuForm.TabIndex = 2;
            this.lblTenDichVuForm.Text = "Tên Dịch Vụ:";
            // 
            // txtTenDichVuForm
            // 
            this.txtTenDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDichVuForm.Location = new System.Drawing.Point(170, 72);
            this.txtTenDichVuForm.Name = "txtTenDichVuForm";
            this.txtTenDichVuForm.Size = new System.Drawing.Size(280, 34);
            this.txtTenDichVuForm.TabIndex = 1; // TabIndex 1
            // 
            // lblLoaiDichVuForm
            // 
            this.lblLoaiDichVuForm.AutoSize = true;
            this.lblLoaiDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiDichVuForm.Location = new System.Drawing.Point(30, 120);
            this.lblLoaiDichVuForm.Name = "lblLoaiDichVuForm";
            this.lblLoaiDichVuForm.Size = new System.Drawing.Size(125, 28);
            this.lblLoaiDichVuForm.TabIndex = 4;
            this.lblLoaiDichVuForm.Text = "Loại Dịch Vụ:";
            // 
            // cboLoaiDichVuForm
            // 
            this.cboLoaiDichVuForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDichVuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiDichVuForm.FormattingEnabled = true;
            this.cboLoaiDichVuForm.Location = new System.Drawing.Point(170, 117);
            this.cboLoaiDichVuForm.Name = "cboLoaiDichVuForm";
            this.cboLoaiDichVuForm.Size = new System.Drawing.Size(280, 36);
            this.cboLoaiDichVuForm.TabIndex = 2; // TabIndex 2
            // 
            // lblDonViTinhForm
            // 
            this.lblDonViTinhForm.AutoSize = true;
            this.lblDonViTinhForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinhForm.Location = new System.Drawing.Point(30, 165);
            this.lblDonViTinhForm.Name = "lblDonViTinhForm";
            this.lblDonViTinhForm.Size = new System.Drawing.Size(118, 28);
            this.lblDonViTinhForm.TabIndex = 6;
            this.lblDonViTinhForm.Text = "Đơn Vị Tính:";
            // 
            // txtDonViTinhForm
            // 
            this.txtDonViTinhForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonViTinhForm.Location = new System.Drawing.Point(170, 162);
            this.txtDonViTinhForm.Name = "txtDonViTinhForm";
            this.txtDonViTinhForm.Size = new System.Drawing.Size(280, 34);
            this.txtDonViTinhForm.TabIndex = 3; // TabIndex 3
            // 
            // lblGiaBanForm
            // 
            this.lblGiaBanForm.AutoSize = true;
            this.lblGiaBanForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaBanForm.Location = new System.Drawing.Point(30, 210);
            this.lblGiaBanForm.Name = "lblGiaBanForm";
            this.lblGiaBanForm.Size = new System.Drawing.Size(84, 28);
            this.lblGiaBanForm.TabIndex = 8;
            this.lblGiaBanForm.Text = "Giá Bán:";
            // 
            // numGiaBanForm
            // 
            this.numGiaBanForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGiaBanForm.Location = new System.Drawing.Point(170, 208);
            this.numGiaBanForm.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGiaBanForm.Name = "numGiaBanForm";
            this.numGiaBanForm.Size = new System.Drawing.Size(280, 34);
            this.numGiaBanForm.TabIndex = 4; // TabIndex 4
            this.numGiaBanForm.ThousandsSeparator = true;
            // 
            // btnLuuForm
            // 
            this.btnLuuForm.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLuuForm.FlatAppearance.BorderSize = 0;
            this.btnLuuForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuForm.ForeColor = System.Drawing.Color.White;
            this.btnLuuForm.Location = new System.Drawing.Point(170, 270);
            this.btnLuuForm.Name = "btnLuuForm";
            this.btnLuuForm.Size = new System.Drawing.Size(120, 45);
            this.btnLuuForm.TabIndex = 5; // TabIndex 5
            this.btnLuuForm.Text = "Lưu";
            this.btnLuuForm.UseVisualStyleBackColor = false;
            this.btnLuuForm.Click += new System.EventHandler(this.btnLuuForm_Click);
            // 
            // btnHuyForm
            // 
            this.btnHuyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnHuyForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyForm.FlatAppearance.BorderSize = 0;
            this.btnHuyForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyForm.ForeColor = System.Drawing.Color.White;
            this.btnHuyForm.Location = new System.Drawing.Point(300, 270);
            this.btnHuyForm.Name = "btnHuyForm";
            this.btnHuyForm.Size = new System.Drawing.Size(120, 45);
            this.btnHuyForm.TabIndex = 6; // TabIndex 6
            this.btnHuyForm.Text = "Hủy";
            this.btnHuyForm.UseVisualStyleBackColor = false;
            this.btnHuyForm.Click += new System.EventHandler(this.btnHuyForm_Click);
            // 
            // frmThemSuaDichVu
            // 
            this.AcceptButton = this.btnLuuForm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnHuyForm;
            this.ClientSize = new System.Drawing.Size(482, 343);
            this.Controls.Add(this.btnHuyForm);
            this.Controls.Add(this.btnLuuForm);
            this.Controls.Add(this.numGiaBanForm);
            this.Controls.Add(this.lblGiaBanForm);
            this.Controls.Add(this.txtDonViTinhForm);
            this.Controls.Add(this.lblDonViTinhForm);
            this.Controls.Add(this.cboLoaiDichVuForm);
            this.Controls.Add(this.lblLoaiDichVuForm);
            this.Controls.Add(this.txtTenDichVuForm);
            this.Controls.Add(this.lblTenDichVuForm);
            this.Controls.Add(this.txtMaDichVuForm);
            this.Controls.Add(this.lblMaDichVuForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSuaDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa Dịch Vụ";
            this.Load += new System.EventHandler(this.frmThemSuaDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBanForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaDichVuForm;
        private System.Windows.Forms.TextBox txtMaDichVuForm;
        private System.Windows.Forms.Label lblTenDichVuForm;
        private System.Windows.Forms.TextBox txtTenDichVuForm;
        private System.Windows.Forms.Label lblLoaiDichVuForm;
        private System.Windows.Forms.ComboBox cboLoaiDichVuForm;
        private System.Windows.Forms.Label lblDonViTinhForm;
        private System.Windows.Forms.TextBox txtDonViTinhForm;
        private System.Windows.Forms.Label lblGiaBanForm;
        private System.Windows.Forms.NumericUpDown numGiaBanForm;
        private System.Windows.Forms.Button btnLuuForm;
        private System.Windows.Forms.Button btnHuyForm;
    }
}