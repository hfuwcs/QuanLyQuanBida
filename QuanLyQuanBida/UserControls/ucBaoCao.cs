using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanBida.UserControls
{
    public partial class ucBaoCao : UserControl
    {
        public ucBaoCao()
        {
            InitializeComponent();
            this.Load += UcBaoCao_Load;
        }

        private void UcBaoCao_Load(object sender, EventArgs e)
        {
            SetupDoanhThuThangChart();
            SetupDoanhThuTheoLoaiDVChart();
            SetupDoanhThuTheoBanChart();
            SetupDoanhThuTheoNgayChart();
        }

        private void SetupDoanhThuThangChart()
        {
            var monthlyRevenue = new Dictionary<string, double>
            {
                { "Tháng 6", 25000000 },
                { "Tháng 7", 31000000 },
                { "Tháng 8", 45000000 },
                { "Tháng 9", 38000000 }
            };

            chartDoanhThuThang.Series.Clear();
            chartDoanhThuThang.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartDoanhThuThang.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (var item in monthlyRevenue)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThuThang.Series.Add(series);
        }

        private void SetupDoanhThuTheoLoaiDVChart()
        {
            // Dữ liệu mẫu
            var revenueByCategory = new Dictionary<string, double>
            {
                { "Tiền giờ", 55 },
                { "Đồ uống", 25 },
                { "Đồ ăn", 15 },
                { "Khác", 5 }
            };

            chartDoanhThuTheoLoaiDV.Series.Clear();
            Series series = new Series("Tỷ lệ")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "0.##'%'",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                LabelForeColor = Color.White
            };

            foreach (var item in revenueByCategory)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThuTheoLoaiDV.Series.Add(series);
        }

        // Cấu hình và tải dữ liệu cho Biểu đồ Doanh thu theo Bàn
        private void SetupDoanhThuTheoBanChart()
        {
            // Dữ liệu mẫu
            var revenueByTable = new Dictionary<string, double>
            {
                { "VIP 1", 8500000 }, { "L-06", 6200000 }, { "L-02", 5800000 },
                { "VIP 2", 4500000 }, { "L-10", 3100000 }
            };

            chartDoanhThuTheoBan.Series.Clear();
            chartDoanhThuTheoBan.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Bar
            };

            foreach (var item in revenueByTable)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThuTheoBan.Series.Add(series);
        }

        // Cấu hình và tải dữ liệu cho Biểu đồ Doanh thu theo Ngày
        private void SetupDoanhThuTheoNgayChart()
        {
            // Dữ liệu mẫu
            var revenueByDay = new Dictionary<DateTime, double>
            {
                { DateTime.Now.AddDays(-6), 1200000 }, { DateTime.Now.AddDays(-5), 1800000 },
                { DateTime.Now.AddDays(-4), 1500000 }, { DateTime.Now.AddDays(-3), 2500000 },
                { DateTime.Now.AddDays(-2), 2200000 }, { DateTime.Now.AddDays(-1), 3100000 },
                { DateTime.Now, 4500000 }
            };

            chartDoanhThuTheoNgay.Series.Clear();
            chartDoanhThuTheoNgay.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartDoanhThuTheoNgay.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3
            };

            foreach (var item in revenueByDay)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThuTheoNgay.Series.Add(series);
        }
    }
}