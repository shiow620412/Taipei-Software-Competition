using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_99_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class PointData
        {
            public int X;
            public int Y;
            public int Type;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                int[] input = Array.ConvertAll(File.ReadAllText(ofd.FileName).Split(' '),s=>int.Parse(s));
                List<PointData> pd = new List<PointData>();
                PointData p = new PointData();
                for(int i = 2;i< input.Length-2;i+=3)
                {
                    p = new PointData();
                    p.X = input[i];
                    p.Y = input[i+1];
                    p.Type = input[i+2];
                    pd.Add(p);
                }
                chart1.Series.Clear();
                chart1.Series.Add("Type1");
                chart1.Series.Add("Type2");
                
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.Minimum = pd.Min(x => x.X);
                chart1.ChartAreas[0].AxisY.Minimum = pd.Min(x => x.Y);
                chart1.ChartAreas[0].AxisX.Maximum = pd.Max(x => x.X);
                chart1.ChartAreas[0].AxisY.Maximum = pd.Max(x => x.Y);
                pd.ForEach(x =>
                {
                    if(x.Type==0)
                        chart1.Series[0].Points.AddXY(x.X, x.Y);
                    else
                        chart1.Series[1].Points.AddXY(x.X, x.Y);
                });
            }
        }
    }
}
