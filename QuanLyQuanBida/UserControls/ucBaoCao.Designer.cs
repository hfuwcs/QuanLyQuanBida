using System.Windows.Forms;

namespace QuanLyQuanBida.UserControls
{
    partial class ucBaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tblCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartDoanhThuThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThuTheoLoaiDV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThuTheoBan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThuTheoNgay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tblCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoLoaiDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Controls.Add(this.btnLoc);
            this.pnlFilters.Controls.Add(this.dtpDenNgay);
            this.pnlFilters.Controls.Add(this.label2);
            this.pnlFilters.Controls.Add(this.dtpTuNgay);
            this.pnlFilters.Controls.Add(this.label1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilters.Size = new System.Drawing.Size(250, 641);
            this.pnlFilters.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTongDoanhThu);
            this.groupBox1.Controls.Add(this.lblSoHoaDon);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(13, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 150);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Quan";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(15, 85);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(189, 23);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "Doanh thu: 45,000,000";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSoHoaDon.Location = new System.Drawing.Point(15, 45);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(127, 23);
            this.lblSoHoaDon.TabIndex = 0;
            this.lblSoHoaDon.Text = "Số hóa đơn: 89";
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(13, 155);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(224, 45);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "Lọc Báo Cáo";
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDenNgay.Location = new System.Drawing.Point(13, 107);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(224, 30);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTuNgay.Location = new System.Drawing.Point(13, 43);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(224, 30);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // tblCharts
            // 
            this.tblCharts.ColumnCount = 2;
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCharts.Controls.Add(this.chartDoanhThuThang, 0, 0);
            this.tblCharts.Controls.Add(this.chartDoanhThuTheoLoaiDV, 1, 0);
            this.tblCharts.Controls.Add(this.chartDoanhThuTheoBan, 0, 1);
            this.tblCharts.Controls.Add(this.chartDoanhThuTheoNgay, 1, 1);
            this.tblCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCharts.Location = new System.Drawing.Point(250, 0);
            this.tblCharts.Name = "tblCharts";
            this.tblCharts.RowCount = 2;
            this.tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCharts.Size = new System.Drawing.Size(794, 641);
            this.tblCharts.TabIndex = 1;
            // 
            // chartDoanhThuThang
            // 
            this.chartDoanhThuThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThuThang.ChartAreas.Add(chartArea1);
            this.chartDoanhThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            this.chartDoanhThuThang.Legends.Add(legend1);
            this.chartDoanhThuThang.Location = new System.Drawing.Point(3, 3);
            this.chartDoanhThuThang.Name = "chartDoanhThuThang";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThuThang.Series.Add(series1);
            this.chartDoanhThuThang.Size = new System.Drawing.Size(391, 314);
            this.chartDoanhThuThang.TabIndex = 0;
            this.chartDoanhThuThang.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "Doanh Thu Theo Tháng";
            this.chartDoanhThuThang.Titles.Add(title1);
            // 
            // chartDoanhThuTheoLoaiDV
            // 
            this.chartDoanhThuTheoLoaiDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThuTheoLoaiDV.ChartAreas.Add(chartArea2);
            this.chartDoanhThuTheoLoaiDV.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chartDoanhThuTheoLoaiDV.Legends.Add(legend2);
            this.chartDoanhThuTheoLoaiDV.Location = new System.Drawing.Point(400, 3);
            this.chartDoanhThuTheoLoaiDV.Name = "chartDoanhThuTheoLoaiDV";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDoanhThuTheoLoaiDV.Series.Add(series2);
            this.chartDoanhThuTheoLoaiDV.Size = new System.Drawing.Size(391, 314);
            this.chartDoanhThuTheoLoaiDV.TabIndex = 1;
            this.chartDoanhThuTheoLoaiDV.Text = "chart2";
            title2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Tỷ Lệ Doanh Thu Theo Loại";
            this.chartDoanhThuTheoLoaiDV.Titles.Add(title2);
            // 
            // chartDoanhThuTheoBan
            // 
            this.chartDoanhThuTheoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea3.Name = "ChartArea1";
            this.chartDoanhThuTheoBan.ChartAreas.Add(chartArea3);
            this.chartDoanhThuTheoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            this.chartDoanhThuTheoBan.Legends.Add(legend3);
            this.chartDoanhThuTheoBan.Location = new System.Drawing.Point(3, 323);
            this.chartDoanhThuTheoBan.Name = "chartDoanhThuTheoBan";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDoanhThuTheoBan.Series.Add(series3);
            this.chartDoanhThuTheoBan.Size = new System.Drawing.Size(391, 315);
            this.chartDoanhThuTheoBan.TabIndex = 2;
            this.chartDoanhThuTheoBan.Text = "chart3";
            title3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            title3.ForeColor = System.Drawing.Color.White;
            title3.Name = "Title1";
            title3.Text = "Top 5 Bàn Doanh Thu Cao Nhất";
            this.chartDoanhThuTheoBan.Titles.Add(title3);
            // 
            // chartDoanhThuTheoNgay
            // 
            this.chartDoanhThuTheoNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            chartArea4.Name = "ChartArea1";
            this.chartDoanhThuTheoNgay.ChartAreas.Add(chartArea4);
            this.chartDoanhThuTheoNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Enabled = false;
            this.chartDoanhThuTheoNgay.Legends.Add(legend4);
            this.chartDoanhThuTheoNgay.Location = new System.Drawing.Point(400, 323);
            this.chartDoanhThuTheoNgay.Name = "chartDoanhThuTheoNgay";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartDoanhThuTheoNgay.Series.Add(series4);
            this.chartDoanhThuTheoNgay.Size = new System.Drawing.Size(391, 315);
            this.chartDoanhThuTheoNgay.TabIndex = 3;
            this.chartDoanhThuTheoNgay.Text = "chart4";
            title4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            title4.ForeColor = System.Drawing.Color.White;
            title4.Name = "Title1";
            title4.Text = "Doanh Thu 7 Ngày Gần Nhất";
            this.chartDoanhThuTheoNgay.Titles.Add(title4);
            // 
            // ucBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.tblCharts);
            this.Controls.Add(this.pnlFilters);
            this.Name = "ucBaoCao";
            this.Size = new System.Drawing.Size(1044, 641);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tblCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoLoaiDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuTheoNgay)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private Panel pnlFilters;
        private TableLayoutPanel tblCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuThang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuTheoLoaiDV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuTheoBan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuTheoNgay;
        private DateTimePicker dtpTuNgay;
        private Label label1;
        private Button btnLoc;
        private DateTimePicker dtpDenNgay;
        private Label label2;
        private GroupBox groupBox1;
        private Label lblTongDoanhThu;
        private Label lblSoHoaDon;
    }
}