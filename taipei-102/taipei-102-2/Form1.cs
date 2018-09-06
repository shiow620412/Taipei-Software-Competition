using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_102_2
{
    public partial class Form1 : Form
    {
        TextBox[] txt;
        public Form1()
        {
            InitializeComponent();
            txt = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
        }
        class PointD
        {
            public double X;
            public double Y;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PointD[] p = new PointD[3];
       
            for(int i =0; i < p.Length;i++)
            {
                p[i] = new PointD();
                p[i].X = double.Parse(txt[i*2].Text);
                p[i].Y = double.Parse(txt[i * 2+1].Text);
            }
            double a = Math.Sqrt(Math.Pow( p[0].X - p[1].X , 2 )+ Math.Pow(p[0].Y - p[1].Y, 2));
            double b = Math.Sqrt(Math.Pow(p[2].X - p[1].X, 2) + Math.Pow(p[2].Y - p[1].Y, 2));
            double c = Math.Sqrt(Math.Pow(p[0].X - p[2].X, 2) + Math.Pow(p[0].Y - p[2].Y, 2));
            a = Math.Round(a,3);
            b = Math.Round(b,3);
            c = Math.Round(c,3);
            label4.Text = $"座標1~座標2 邊長={a}{Environment.NewLine}座標2~座標3 邊長={b}{Environment.NewLine}座標3~座標1 邊長={c}";
            double m1 = (p[1].Y - p[0].Y) / (p[1].X - p[0].X);
            double m2 = (p[2].Y - p[1].Y) / (p[2].X - p[1].X);
            if ((p[0].X == p[1].X && p[0].Y == p[1].Y) | (p[2].X == p[1].X && p[2].Y == p[1].Y) | (p[0].X == p[2].X && p[0].Y == p[2].Y))
                label5.Text = "有相同點座標";
            else if (m1 == m2)
                label5.Text = "此為三點一直線";
            else if (a == b && b == c)
                label5.Text = "此為正三角形";
            else if ((Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Round(Math.Pow(c, 2)) |
                      Math.Pow(c, 2) + Math.Pow(b, 2) == Math.Round(Math.Pow(a, 2)) |
                      Math.Pow(c, 2) + Math.Pow(a, 2) == Math.Round(Math.Pow(b, 2))) && (a == b | b == c | c == a))
                label5.Text = "此為等腰直角三角形";
            else if (a == b | b == c | c == a)
                label5.Text = "此為等腰三角形";
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Round(Math.Pow(c, 2))|
                      Math.Pow(c, 2) + Math.Pow(b, 2) ==Math.Round(Math.Pow(a, 2)) |
                      Math.Pow(c, 2) + Math.Pow(a, 2) == Math.Round(Math.Pow(b, 2)))
                label5.Text = "此為直角三角形";
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) < Math.Pow(c, 2) |
                      Math.Pow(c, 2) + Math.Pow(b, 2) < Math.Pow(a, 2) |
                      Math.Pow(c, 2) + Math.Pow(a, 2) < Math.Pow(b, 2))
                label5.Text = "此為鈍角三角形";
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) > Math.Pow(c, 2) |
                      Math.Pow(c, 2) + Math.Pow(b, 2) > Math.Pow(a, 2) |
                      Math.Pow(c, 2) + Math.Pow(a, 2) > Math.Pow(b, 2))
                label5.Text = "此為銳角三角形";

        }
    }
}

