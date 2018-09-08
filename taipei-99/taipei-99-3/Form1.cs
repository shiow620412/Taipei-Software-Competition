using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_99_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if( ofd.ShowDialog()==DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(Image.FromFile(ofd.FileName));
                pictureBox1.Image = bmp;
                List<Point> p = new List<Point>();
                for(int i =0; i < bmp.Width; i++)
                {
                    for(int j = 0; j < bmp.Height;j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        if (c.R == c.G && c.G == c.B && c.B == 0)
                            p.Add(new Point(i, bmp.Height-j));
                    }
                }
                label1.Text = $"線段左邊座標 ({p[0].X} , {p[0].Y})";
                label2.Text = $"線段右邊座標 ({p.Last().X} , {p.Last().Y})";
                float m = (p.Last().Y - p[0].Y) / (float)(p.Last().X - p[0].X);
                label3.Text = $"線段斜率 {m}";
            }
        }
    }
}
