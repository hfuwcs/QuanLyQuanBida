using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    partial class ucSoDoBan
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpBanBida = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlChonDichVu = new System.Windows.Forms.Panel();
            this.flpDichVu = new System.Windows.Forms.FlowLayoutPanel();
            this.flpLoaiDichVu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHoaDon = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.btnBatDauChoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlChonDichVu.SuspendLayout();
            this.pnlHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flpBanBida);
            this.splitContainer1.Panel1MinSize = 280;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1044, 513);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 0;
            // 
            // flpBanBida
            // 
            this.flpBanBida.AutoScroll = true;
            this.flpBanBida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.flpBanBida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBanBida.Location = new System.Drawing.Point(0, 0);
            this.flpBanBida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpBanBida.Name = "flpBanBida";
            this.flpBanBida.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.flpBanBida.Size = new System.Drawing.Size(280, 513);
            this.flpBanBida.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlChonDichVu);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnlHoaDon);
            this.splitContainer2.Size = new System.Drawing.Size(760, 513);
            this.splitContainer2.SplitterDistance = 380;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlChonDichVu
            // 
            this.pnlChonDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlChonDichVu.Controls.Add(this.flpDichVu);
            this.pnlChonDichVu.Controls.Add(this.flpLoaiDichVu);
            this.pnlChonDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChonDichVu.Location = new System.Drawing.Point(0, 0);
            this.pnlChonDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(380, 513);
            this.pnlChonDichVu.TabIndex = 0;
            // 
            // flpDichVu
            // 
            this.flpDichVu.AutoScroll = true;
            this.flpDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDichVu.Location = new System.Drawing.Point(0, 40);
            this.flpDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpDichVu.Name = "flpDichVu";
            this.flpDichVu.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.flpDichVu.Size = new System.Drawing.Size(380, 473);
            this.flpDichVu.TabIndex = 1;
            // 
            // flpLoaiDichVu
            // 
            this.flpLoaiDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.flpLoaiDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpLoaiDichVu.Location = new System.Drawing.Point(0, 0);
            this.flpLoaiDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpLoaiDichVu.Name = "flpLoaiDichVu";
            this.flpLoaiDichVu.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.flpLoaiDichVu.Size = new System.Drawing.Size(380, 40);
            this.flpLoaiDichVu.TabIndex = 0;
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlHoaDon.Controls.Add(this.btnThanhToan);
            this.pnlHoaDon.Controls.Add(this.btnInHoaDon);
            this.pnlHoaDon.Controls.Add(this.lblTongTien);
            this.pnlHoaDon.Controls.Add(this.dgvChiTietHoaDon);
            this.pnlHoaDon.Controls.Add(this.lblGioVao);
            this.pnlHoaDon.Controls.Add(this.lblTrangThai);
            this.pnlHoaDon.Controls.Add(this.lblTenBan);
            this.pnlHoaDon.Controls.Add(this.btnBatDauChoi);
            this.pnlHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.pnlHoaDon.Location = new System.Drawing.Point(0, 0);
            this.pnlHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlHoaDon.Size = new System.Drawing.Size(376, 513);
            this.pnlHoaDon.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(193, 463);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(170, 40);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(8, 463);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(170, 40);
            this.btnInHoaDon.TabIndex = 5;
            this.btnInHoaDon.Text = "In Hóa Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Gold;
            this.lblTongTien.Location = new System.Drawing.Point(2, 429);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(174, 32);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHoaDon.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(8, 220);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 29;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(350, 0);
            this.dgvChiTietHoaDon.TabIndex = 3;
            // 
            // lblGioVao
            // 
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGioVao.Location = new System.Drawing.Point(13, 72);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(108, 23);
            this.lblGioVao.TabIndex = 2;
            this.lblGioVao.Text = "Giờ vào: N/A";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(13, 49);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(91, 23);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // lblTenBan
            // 
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTenBan.ForeColor = System.Drawing.Color.White;
            this.lblTenBan.Location = new System.Drawing.Point(6, 8);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(179, 41);
            this.lblTenBan.TabIndex = 0;
            this.lblTenBan.Text = "CHỌN BÀN";
            // 
            // btnBatDauChoi
            // 
            this.btnBatDauChoi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBatDauChoi.FlatAppearance.BorderSize = 0;
            this.btnBatDauChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDauChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBatDauChoi.ForeColor = System.Drawing.Color.White;
            this.btnBatDauChoi.Location = new System.Drawing.Point(13, 387);
            this.btnBatDauChoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBatDauChoi.Name = "btnBatDauChoi";
            this.btnBatDauChoi.Size = new System.Drawing.Size(350, 40);
            this.btnBatDauChoi.TabIndex = 7;
            this.btnBatDauChoi.Text = "Bắt Đầu Chơi";
            this.btnBatDauChoi.UseVisualStyleBackColor = false;
            this.btnBatDauChoi.Click += new System.EventHandler(this.btnBatDauChoi_Click);
            // 
            // ucSoDoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucSoDoBan";
            this.Size = new System.Drawing.Size(1044, 513);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlChonDichVu.ResumeLayout(false);
            this.pnlHoaDon.ResumeLayout(false);
            this.pnlHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flpBanBida;
        private SplitContainer splitContainer2;
        private Panel pnlChonDichVu;
        private Panel pnlHoaDon;
        private FlowLayoutPanel flpDichVu;
        private FlowLayoutPanel flpLoaiDichVu;
        private Label lblTenBan;
        private Label lblGioVao;
        private Label lblTrangThai;
        private DataGridView dgvChiTietHoaDon;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Button btnInHoaDon;
        private System.Windows.Forms.Button btnBatDauChoi;
    }
}