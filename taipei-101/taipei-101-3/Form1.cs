using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_101_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] input = Array.ConvertAll(textBox1.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), s => double.Parse(s));
            Array.Sort(input);
            double Q1 = 0, Q2 = 0, Q3 = 0, IQR, limitMax, limitMin;

            double i = (0.25 * input.Length) - 1;
            if (i % 1 == 0)
                Q1 = (input[(int)i] + input[(int)i + 1]) / 2;
            else
                Q1 = input[(int)i + 1];

            i = (0.5) * input.Length - 1;
            if (i % 1 == 0)
                Q2 = (input[(int)i] + input[(int)i + 1]) / 2;
            else
                Q2 = input[(int)i + 1];

            i = 0.75 * input.Length - 1;
            if (i % 1 == 0)
                Q3 = (input[(int)i] + input[(int)i + 1]) / 2;
            else
                Q3 = input[(int)i + 1];

            IQR = Q3 - Q1;
            limitMin = Q1 - IQR;
            limitMax = Q3 + IQR;
            List<double> Outliers = new List<double>();
            input.ToList().ForEach(x =>
            {
                if (x > limitMax | x < limitMin)
                    Outliers.Add(x);
            });
            //畫圖
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double max = input.ToList().Max(), min = input.ToList().Min();
            float width = 0;
            float rect = 0;
            g.DrawLine(Pens.Black, 15, 5f, 15, (float)(max - min) * 7.5f + 5);
            for (double count = max; count >= min; count -= 1)
            {
                if (count == max)
                    g.DrawLine(Pens.Black, 50, width + 5, 60, width + 5);
                if (count == Q1)
                {
                    g.DrawLine(Pens.Blue, 45, width + 5, 65, width + 5);
                    g.DrawLine(Pens.Blue, 45, rect, 45, width + 5);
                    g.DrawLine(Pens.Blue, 65, rect, 65, width + 5);
                }
                if (count == Q2)
                    g.DrawLine(Pens.Red, 45, width + 5, 65, width + 5);
                if (count == Q3)
                {
                    g.DrawLine(Pens.Blue, 45, width + 5, 65, width + 5);
                    rect = (int)width + 5;
                }
                if (count == min)
                    g.DrawLine(Pens.Black, 50, width + 5, 60, width + 5);

                if (count % 2 == 0)
                {
                    g.DrawString(count.ToString(), Font, Brushes.Black, 0, width);
                }
                if (count != max && (count >= Q3 | count < Q1))
                    g.DrawLine(Pens.Black, 55, width, 55, width + 1);
                g.DrawLine(Pens.Black, 15, width + 5, 20, width + 5);
                width += 7.5f;
            }


        }





    }
}
