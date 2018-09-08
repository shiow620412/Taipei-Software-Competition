using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_100_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Variability = double.Parse(textBox4.Text);
            double AverageValue = double.Parse(textBox3.Text);
            Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height); ;
            //Graphics繪製
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            int min = int.Parse(textBox1.Text);
            int max = int.Parse(textBox2.Text);
            PointF xy = new PointF(200 + min * 30 + 9, 200 + max * 30 + 4.5f);
            g.DrawLine(Pens.Black,xy.X , 300,xy.Y ,300);
            for(int i = min; i<=max;i++)
            {
                g.DrawString(i.ToString(), Font, Brushes.Black, 200+i*30, 300);
            }
            g.DrawLine(Pens.Black, xy.X, 50, xy.X, 300);
            int temp = 0;
            for (float i = -0.1f; i <= 1; i += 0.1f )
            {                
                g.DrawString(Math.Round(i,1).ToString(), Font,Brushes.Black, xy.X - 27, 270.5f-i*250);
                temp++;
           }         
            
            for(float i = min; i<=max;i+=0.001f)
            {
                bmp.SetPixel((int)Math.Truncate(209 + i * 30), (int)Math.Truncate(270.5f - 250 * (getFunctionValue(i, Variability, AverageValue))) ,Color.Blue);
            }
            pictureBox1.Image = bmp;
            //Chart圖表繪製
            chart1.Series.Clear();
            chart1.Series.Add("Gaussian 機率密度函數");
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.Minimum = min;
            chart1.ChartAreas[0].AxisX.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = -0.1;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (float i = min; i <= max; i += 0.001f)
            {
                chart1.Series[0].Points.AddXY(i,getFunctionValue(i, Variability, AverageValue));
            }
        }
        double getFunctionValue(double x,double Variability,double AverageValue)
        {
            return  1 / (Math.Sqrt(2 * Math.PI )* Math.Sqrt(Variability)) * Math.Exp(-1 * Math.Pow((x - AverageValue), 2) / (2 * Variability));
        }
    }
}
