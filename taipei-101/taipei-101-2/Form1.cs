using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_101_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                bmp = new Bitmap(Image.FromFile(ofd.FileName));
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Point> p = new List<Point>();
            Color c;
            //左上(寬先加)
            for(int i = 0; i < bmp.Height; i++)
            {
                for(int j =0; j < bmp.Width; j++)
                {
                    c = bmp.GetPixel(j, i);
                    if (c.R != 255 && c.G != 255 && c.B != 255)
                    {
                        p.Add(new Point(j, i));
                        break;
                    }
                }
                if (p.Count == 1)
                    break;
            }
            //右下(寬先減)
            for (int i = bmp.Height-1; i >-1 ; i--)
            {
                for (int j = bmp.Width-1; j >-1; j--)
                {
                    c = bmp.GetPixel(j, i);
                    if (c.R != 255 && c.G != 255 && c.B != 255 )
                    {
                        p.Add(new Point(j, i));
                        break;
                    }
                }
                if (p.Count == 2)
                    break;
            }
            //左上(高先加)
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (c.R != 255 && c.G != 255 && c.B != 255 )
                    {
                        p.Add(new Point(i, j));
                        break;
                    }
                }
                if (p.Count == 3)
                    break;
            }
            //右下(高先減)
            for (int i = bmp.Width-1; i>-1; i--)
            {
                for (int j = bmp.Height-1; j >-1; j--)
                {
                    c = bmp.GetPixel(i, j);
                    if (c.R != 255 && c.G != 255 && c.B != 255 )
                    {
                        p.Add(new Point(i, j));
                        break;
                    }
                }
                if (p.Count == 4)
                    break;
            }
            Point[] output = new Point[2];
            output[0]=new Point(p[2].X, p[0].Y);
            output[1]=new Point(p[3].X,p[1].Y);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(Pens.Red, output[0].X, output[0].Y, output[1].X, output[0].Y);
            g.DrawLine(Pens.Red, output[0].X, output[1].Y, output[1].X, output[1].Y);
            g.DrawLine(Pens.Red, output[0].X, output[0].Y, output[0].X, output[1].Y);
            g.DrawLine(Pens.Red, output[1].X, output[0].Y, output[1].X, output[1].Y);

        }
    }
}
