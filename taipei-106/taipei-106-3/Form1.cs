using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace taipei_106_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            checkBox1.Checked = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = checkBox1.Checked;
        }
        List<PointF> lst;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            lst = new List<PointF>();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                string[] input = File.ReadAllLines(ofd.FileName);
                string[] temp;
                for(int i = 1;i< input.Length;i++)
                {
                    temp = input[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    lst.Add( new PointF( float.Parse(temp[0]), float.Parse(temp[1])));
                }
                chart1.Series.Clear();
                chart1.Series.Add("Point");
                chart1.Series[0].ChartType = SeriesChartType.Point;
                for (int i =0;i<lst.Count;i++)
                {
                    PointF p = lst[i];
                    chart1.Series[0].Points.AddXY(p.X, p.Y);
                }


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            lst.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisY.IsMarginVisible = false;
            chart1.Series.Add("Line");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            
            float min = lst.Min(x => x.X);
            float max = lst.Max(x => x.X);
            //以間隔0.1f來求 最小x 到 最大x 中的各個函數值            
            for (float m = min; m <= max; m += 0.1f)
            {
                float result = 0;
            
                for (int i = 0; i < lst.Count; i++)
                {                    
                    float up=1, down=1;
                    //求出各個點的Lagrange基底多項式 在各x值的函數值
                    for (int j = 0; j < lst.Count; j++)
                    {
                        if (i == j)
                            continue;
                        //將 x 帶入基底多項式求 各點Lagrange基底多項式 的值
                        up *= m - lst[j].X;
                        down *= lst[i].X - lst[j].X;
                    }
                    result += lst[i].Y * (up / down);
                }
                //新增線至chart1上
                chart1.Series[0].Points.AddXY(m, result);              
            }
            chart1.Series.Add("Point");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            for (int i = 0; i < lst.Count; i++)
                chart1.Series[1].Points.AddXY(lst[i].X, lst[i].Y);

        }
      
    }
}
