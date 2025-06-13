using QuanLyQuanBida.BLL;
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
        private HoaDonBLL baoCaoBLL = new HoaDonBLL(); 

        public ucBaoCao()
        {
            InitializeComponent();
            this.Load += UcBaoCao_Load;
        }

        private void UcBaoCao_Load(object sender, EventArgs e)
        {
            LoadDoanhThuThangChart();
            LoadDoanhThuTheoLoaiDVChart();
            LoadDoanhThuTheoBanChart();
            LoadDoanhThuTheoNgayChart();
        }

        private void LoadDoanhThuThangChart()
        {

            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddMonths(-3).AddDays(-endDate.Day + 1); // Đầu của 3 tháng trước
            var monthlyRevenue = baoCaoBLL.GetMonthlyRevenue(startDate, endDate);


            chartDoanhThuThang.Series.Clear();
            chartDoanhThuThang.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartDoanhThuThang.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column
            };

            if (monthlyRevenue != null)
            {
                foreach (var item in monthlyRevenue)
                {
                    series.Points.AddXY(item.Key, item.Value); 
                }
            }
            chartDoanhThuThang.Series.Add(series);
        }

        private void LoadDoanhThuTheoLoaiDVChart()
        {
            var revenueByCategory = baoCaoBLL.GetRevenueByCategory();

            chartDoanhThuTheoLoaiDV.Series.Clear();
            Series series = new Series("Tỷ lệ")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "0.##'%'", 
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                LabelForeColor = Color.White
            };

            if (revenueByCategory != null)
            {

                double totalRevenue = revenueByCategory.Sum(x => x.Value);
                if (totalRevenue > 0)
                {
                    foreach (var item in revenueByCategory)
                    {
                        DataPoint dataPoint = new DataPoint();
                        dataPoint.SetValueXY(item.Key, (item.Value / totalRevenue) * 100);
                        dataPoint.Label = $"{item.Key}\n({(item.Value / totalRevenue):P1})"; 
                        dataPoint.LegendText = item.Key; 
                        series.Points.Add(dataPoint);
                    }
                }
            }
            chartDoanhThuTheoLoaiDV.Series.Add(series);
            chartDoanhThuTheoLoaiDV.Legends[0].Enabled = true; 
        }

        private void LoadDoanhThuTheoBanChart()
        {
            var revenueByTable = baoCaoBLL.GetTopRevenueByTable(5); 

            chartDoanhThuTheoBan.Series.Clear();
            chartDoanhThuTheoBan.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartDoanhThuTheoBan.ChartAreas[0].AxisX.Interval = 1;

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Bar
            };

            if (revenueByTable != null)
            {
                var sortedRevenueByTable = revenueByTable.OrderByDescending(kvp => kvp.Value).ToList();
                foreach (var item in sortedRevenueByTable)
                {
                    series.Points.AddXY(item.Key, item.Value);
                }
            }
            chartDoanhThuTheoBan.Series.Add(series);
        }

        private void LoadDoanhThuTheoNgayChart()
        {
            var revenueByDay = baoCaoBLL.GetDailyRevenue(7); 

            chartDoanhThuTheoNgay.Series.Clear();
            chartDoanhThuTheoNgay.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartDoanhThuTheoNgay.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chartDoanhThuTheoNgay.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chartDoanhThuTheoNgay.ChartAreas[0].AxisX.Interval = 1;


            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                XValueType = ChartValueType.Date
            };

            if (revenueByDay != null)
            {
                var sortedRevenueByDay = revenueByDay.OrderBy(kvp => kvp.Key).ToList();
                foreach (var item in sortedRevenueByDay)
                {
                    series.Points.AddXY(item.Key.ToOADate(), item.Value);
                }
            }
            chartDoanhThuTheoNgay.Series.Add(series);
        }
    }
}