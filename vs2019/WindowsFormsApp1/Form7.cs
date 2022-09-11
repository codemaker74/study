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

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.Text = "Using Chart Control";
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("중간고사 성적");
            chart1.Series.Add("Series2");
            chart1.Series["Series1"].LegendText = "수학";
            chart1.Series["Series2"].LegendText = "영어";

            chart1.ChartAreas.Add("ChartArea2");
            chart1.Series["Series2"].ChartArea = "ChartArea2";

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, r.Next(100));
                chart1.Series["Series2"].Points.AddXY(i, r.Next(100));
            }
        }

        private void btnOneChartArea_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.RemoveAt(chart1.ChartAreas.IndexOf("ChartArea2"));
            chart1.Series["Series2"].ChartArea = "ChartArea1";
        }

        private void btnTwoChartArea_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.Add("ChartArea2");
            chart1.Series["Series2"].ChartArea = "ChartArea2";
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            chart2.ChartAreas[0].BackColor = Color.Black;

            // ChartArea X축과 Y축을 설정
            chart2.ChartAreas[0].AxisX.Minimum = -20;
            chart2.ChartAreas[0].AxisX.Maximum = 20;
            chart2.ChartAreas[0].AxisX.Interval = 2;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart2.ChartAreas[0].AxisY.Minimum = -2;
            chart2.ChartAreas[0].AxisY.Maximum = 2;
            chart2.ChartAreas[0].AxisY.Interval = 0.5;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Series[0] 설정(Sin/x)        
            chart2.Series[0].ChartType = SeriesChartType.Line;
            chart2.Series[0].Color = Color.LightGreen;
            chart2.Series[0].BorderWidth = 2;
            chart2.Series[0].LegendText = "sin(x)/x";

            // Series[1] 추가 및 설정(Cos/x)   
            if (chart2.Series.Count == 1)
            {
                chart2.Series.Add("Cos");
                chart2.Series["Cos"].ChartType = SeriesChartType.Line;
                chart2.Series["Cos"].Color = Color.Orange;
                chart2.Series["Cos"].BorderWidth = 2;
                chart2.Series["Cos"].LegendText = "cos(x)/x";
            }

            for (double x = -20; x < 20; x += 0.1)
            {
                double y = Math.Sin(x) / x;
                chart2.Series[0].Points.AddXY(x, y);
                y = Math.Cos(x) / x;
                chart2.Series["Cos"].Points.AddXY(x, y);
            }
        }
    }
}
