using System.Windows.Forms;

namespace QuanLyQuanBida.Forms
{
    partial class frmBatDauChoi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKhachVangLai = new System.Windows.Forms.TextBox();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(28, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bắt Đầu Chơi Bàn ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(35, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khách hàng (thẻ TV):";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(35, 95);
            this.cboKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(395, 36);
            this.cboKhachHang.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(35, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Khách vãng lai (tên):";
            // 
            // txtKhachVangLai
            // 
            this.txtKhachVangLai.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtKhachVangLai.Location = new System.Drawing.Point(35, 168);
            this.txtKhachVangLai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKhachVangLai.Name = "txtKhachVangLai";
            this.txtKhachVangLai.Size = new System.Drawing.Size(395, 34);
            this.txtKhachVangLai.TabIndex = 4;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBatDau.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBatDau.FlatAppearance.BorderSize = 0;
            this.btnBatDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(280, 221);
            this.btnBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(150, 40);
            this.btnBatDau.TabIndex = 5;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(114, 221);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // frmBatDauChoi
            // 
            this.AcceptButton = this.btnBatDau;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(468, 282);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.txtKhachVangLai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboKhachHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBatDauChoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác nhận bắt đầu chơi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label lblTitle;
        private Label label2;
        private ComboBox cboKhachHang;
        private Label label3;
        private TextBox txtKhachVangLai;
        private Button btnBatDau;
        private Button btnHuy;
    }
}