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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpBanBida = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlChonDichVu = new System.Windows.Forms.Panel();
            this.flpDichVu = new System.Windows.Forms.FlowLayoutPanel();
            this.flpLoaiDichVu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHoaDon = new System.Windows.Forms.Panel();
            this.tblHoaDonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlThongTinBan = new System.Windows.Forms.Panel();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.pnlNutBam = new System.Windows.Forms.Panel();
            this.btnBatDauChoi = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
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
            this.tblHoaDonLayout.SuspendLayout();
            this.pnlThongTinBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.pnlNutBam.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.flpBanBida.Name = "flpBanBida";
            this.flpBanBida.Padding = new System.Windows.Forms.Padding(5);
            this.flpBanBida.Size = new System.Drawing.Size(280, 513);
            this.flpBanBida.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
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
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(380, 513);
            this.pnlChonDichVu.TabIndex = 0;
            // 
            // flpDichVu
            // 
            this.flpDichVu.AutoScroll = true;
            this.flpDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDichVu.Location = new System.Drawing.Point(0, 40);
            this.flpDichVu.Name = "flpDichVu";
            this.flpDichVu.Padding = new System.Windows.Forms.Padding(5);
            this.flpDichVu.Size = new System.Drawing.Size(380, 473);
            this.flpDichVu.TabIndex = 1;
            // 
            // flpLoaiDichVu
            // 
            this.flpLoaiDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.flpLoaiDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpLoaiDichVu.Location = new System.Drawing.Point(0, 0);
            this.flpLoaiDichVu.Name = "flpLoaiDichVu";
            this.flpLoaiDichVu.Padding = new System.Windows.Forms.Padding(5);
            this.flpLoaiDichVu.Size = new System.Drawing.Size(380, 40);
            this.flpLoaiDichVu.TabIndex = 0;
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlHoaDon.Controls.Add(this.tblHoaDonLayout);
            this.pnlHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.pnlHoaDon.Location = new System.Drawing.Point(0, 0);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.Padding = new System.Windows.Forms.Padding(10);
            this.pnlHoaDon.Size = new System.Drawing.Size(376, 513);
            this.pnlHoaDon.TabIndex = 0;
            // 
            // tblHoaDonLayout
            // 
            this.tblHoaDonLayout.ColumnCount = 1;
            this.tblHoaDonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHoaDonLayout.Controls.Add(this.pnlThongTinBan, 0, 0);
            this.tblHoaDonLayout.Controls.Add(this.dgvChiTietHoaDon, 0, 1);
            this.tblHoaDonLayout.Controls.Add(this.pnlNutBam, 0, 2);
            this.tblHoaDonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHoaDonLayout.Location = new System.Drawing.Point(10, 10);
            this.tblHoaDonLayout.Name = "tblHoaDonLayout";
            this.tblHoaDonLayout.RowCount = 3;
            this.tblHoaDonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblHoaDonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHoaDonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblHoaDonLayout.Size = new System.Drawing.Size(356, 493);
            this.tblHoaDonLayout.TabIndex = 8;
            // 
            // pnlThongTinBan
            // 
            this.pnlThongTinBan.Controls.Add(this.lblGioVao);
            this.pnlThongTinBan.Controls.Add(this.lblTrangThai);
            this.pnlThongTinBan.Controls.Add(this.lblTenBan);
            this.pnlThongTinBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTinBan.Location = new System.Drawing.Point(3, 3);
            this.pnlThongTinBan.Name = "pnlThongTinBan";
            this.pnlThongTinBan.Size = new System.Drawing.Size(350, 124);
            this.pnlThongTinBan.TabIndex = 0;
            // 
            // lblGioVao
            // 
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGioVao.Location = new System.Drawing.Point(3, 89);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(108, 23);
            this.lblGioVao.TabIndex = 2;
            this.lblGioVao.Text = "Giờ vào: N/A";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(3, 56);
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
            this.lblTenBan.Location = new System.Drawing.Point(3, 10);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(179, 41);
            this.lblTenBan.TabIndex = 0;
            this.lblTenBan.Text = "CHỌN BÀN";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(3, 133);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 29;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(350, 237);
            this.dgvChiTietHoaDon.TabIndex = 3;
            // 
            // pnlNutBam
            // 
            this.pnlNutBam.Controls.Add(this.btnBatDauChoi);
            this.pnlNutBam.Controls.Add(this.btnInHoaDon);
            this.pnlNutBam.Controls.Add(this.btnThanhToan);
            this.pnlNutBam.Controls.Add(this.lblTongTien);
            this.pnlNutBam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNutBam.Location = new System.Drawing.Point(3, 376);
            this.pnlNutBam.Name = "pnlNutBam";
            this.pnlNutBam.Size = new System.Drawing.Size(350, 114);
            this.pnlNutBam.TabIndex = 2;
            // 
            // btnBatDauChoi
            // 
            this.btnBatDauChoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatDauChoi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBatDauChoi.FlatAppearance.BorderSize = 0;
            this.btnBatDauChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDauChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBatDauChoi.ForeColor = System.Drawing.Color.White;
            this.btnBatDauChoi.Location = new System.Drawing.Point(3, 58);
            this.btnBatDauChoi.Name = "btnBatDauChoi";
            this.btnBatDauChoi.Size = new System.Drawing.Size(344, 50);
            this.btnBatDauChoi.TabIndex = 7;
            this.btnBatDauChoi.Text = "Bắt Đầu Chơi";
            this.btnBatDauChoi.UseVisualStyleBackColor = false;
            this.btnBatDauChoi.Click += new System.EventHandler(this.btnBatDauChoi_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(3, 58);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(170, 50);
            this.btnInHoaDon.TabIndex = 5;
            this.btnInHoaDon.Text = "In Hóa Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(65)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(177, 58);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(170, 50);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Gold;
            this.lblTongTien.Location = new System.Drawing.Point(3, 10);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(174, 32);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // ucSoDoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
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
            this.tblHoaDonLayout.ResumeLayout(false);
            this.pnlThongTinBan.ResumeLayout(false);
            this.pnlThongTinBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.pnlNutBam.ResumeLayout(false);
            this.pnlNutBam.PerformLayout();
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
        private TableLayoutPanel tblHoaDonLayout;
        private Panel pnlThongTinBan;
        private Panel pnlNutBam;
    }
}