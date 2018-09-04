using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_103_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int m = int.Parse(textBox2.Text);
            int b = int.Parse(textBox3.Text);
            chart1.Series.Clear();
            chart1.Series.Add("triangle");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[0].Points.AddXY(a, 0);
            chart1.Series[0].Points.AddXY(m, 1);
            chart1.Series[0].Points.AddXY(b,0);
            chart1.Series[0].Points.AddXY(10, 0);
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox4.Text);            
            int b = int.Parse(textBox5.Text);
            int c = int.Parse(textBox6.Text);
            int d = int.Parse(textBox7.Text);
            chart1.Series.Clear();
            chart1.Series.Add("梯形");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            chart1.ChartAreas[0].AxisX.Minimum= 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[0].Points.AddXY(a, 0);
            chart1.Series[0].Points.AddXY(b, 1);
            chart1.Series[0].Points.AddXY(c, 1);
            chart1.Series[0].Points.AddXY(d, 0);
            chart1.Series[0].Points.AddXY(20, 0);            
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }
    }
}
