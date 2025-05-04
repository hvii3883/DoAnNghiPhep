using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmAdmin2 : Form
    {
        private LeaveRequestBL requestBL = new LeaveRequestBL();
        public frmAdmin2()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void LoadStats()
        {
            var data = requestBL.GetMonthlyStatistics();
            chartStats.Series.Clear();
            chartStats.ChartAreas[0].AxisX.Title = "Tháng";
            chartStats.ChartAreas[0].AxisY.Title = "Số đơn";

            var series = new Series("Số đơn nghỉ phép");
            series.ChartType = SeriesChartType.Column;
            int total = 0;
            int monthCount = 0;

            for (int month = 1; month <= 12; month++)
            {
                int count = data.ContainsKey(month) ? data[month] : 0;
                series.Points.AddXY($"Tháng {month}", count);
                total += count; // Cộng dồn tổng số đơn
                if (count > 0)
                {
                    monthCount++; // Tính số tháng có dữ liệu
                }
            }

            chartStats.Series.Add(series);
            
            if (monthCount > 0)
            {
                double avg = (double)total / monthCount;
                lbForecast.Text = $"Dự báo: \ntrung bình {avg:F1} đơn/tháng.";
            }
            else
            {
                lbForecast.Text = "Chưa có dữ liệu thống kê.";
            }
        }

        private void frmAdmin2_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void chartStats_Click(object sender, EventArgs e)
        {

        }

        private void lbForecast_Click(object sender, EventArgs e)
        {

        }
    }
}
