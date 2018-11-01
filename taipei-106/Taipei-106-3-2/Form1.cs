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
namespace Taipei_106_3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int scale = 1;
        void rePaint()
        {
         
            Bitmap bmp = new Bitmap(1600, 880);
            Graphics g = Graphics.FromImage(bmp);
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    if (i % 5 == 0 && j % 5 == 0)
                        bmp.SetPixel(i, j, Color.Black);
                    if (i % 5 == 0 && j == 0 && checkBox1.Checked)
                        g.DrawLine(Pens.Black, i, 0, i, bmp.Height);
                }
                if (j % 5 == 0 && checkBox1.Checked)
                    g.DrawLine(Pens.Black, 0, j, bmp.Width, j);
            }
            pictureBox1.Image = bmp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 1600*scale;
            pictureBox1.Height = 880*scale;
            rePaint();            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            bool line = ((CheckBox)sender).Checked;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bmp);
            
            
            for (int i = 0; i < bmp.Width; i++)                 
                if (i % 5 ==  0 && line)
                    g.DrawLine(Pens.Black, i, 0, i, bmp.Height);       
            for (int i = 0; i < bmp.Height; i++)
                if (i % 5 == 0 && line)
                    g.DrawLine(Pens.Black, 0,i, bmp.Width, i);
            if(!line)
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    if (i % 5 != 0 | j % 5 != 0)
                        bmp.SetPixel(i, j, Color.White);
                   
                }
            }
            pictureBox1.Image = bmp;
            


        }
        List<PointF> pts = new List<PointF>();

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"座標({e.X/scale},{e.Y/scale})";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Bitmap bmp = new Bitmap(pictureBox1.Image);
 
            bmp.SetPixel(e.X/ scale, e.Y/ scale, Color.Red);
            pts.Add(new Point(e.X / scale, e.Y / scale));
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rePaint();
            pts.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            pts.Clear();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] input = File.ReadAllLines(ofd.FileName);
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Graphics g = Graphics.FromImage(bmp);
                for (int i = 1; i < input.Length; i++)
                {
                    PointF p = new PointF();
                    string[] point = input[i].Split(' ');
                    p.X = float.Parse(point[0]) ;
                    p.Y = float.Parse(point[1]) ;
                    bmp.SetPixel((int)p.X, (int)p.Y, Color.Red);
                    g.DrawEllipse(Pens.Red, new Rectangle((int)p.X - 2, (int)p.Y - 2, 2, 2));
                    pts.Add(p);
                }
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int min = (int)pts.Min(x => x.X);
            int max = (int)pts.Max(x => x.X);
            Bitmap bmp = new Bitmap(1600,880);
            Graphics g = Graphics.FromImage(bmp);
            List<Point> p = new List<Point>();
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    if (i % 5 == 0 && j % 5 == 0)
                        bmp.SetPixel(i, j, Color.Black);
                    if (i % 5 == 0 && j == 0 && checkBox1.Checked)
                        g.DrawLine(Pens.Black, i, 0, i, bmp.Height);
                }
                if (j % 5 == 0 && checkBox1.Checked)
                    g.DrawLine(Pens.Black, 0, j, bmp.Width, j);
            }
            for (int i = 0; i < pts.Count; i++)
                g.DrawEllipse(Pens.Red, new Rectangle((int)pts[i].X - 2, (int)pts[i].Y - 2, 2, 2));
            for (int i = 0; i <= 1599; i++)
            {
                int result = 0;
                for (int m = 0; m < pts.Count; m++)
                {
                    float up = 1;
                    float down = 1;
                    for (int n = 0; n < pts.Count; n++)
                    {
                        if (m == n)
                            continue;
                        up *= i - pts[n].X;
                        down *= pts[m].X - pts[n].X;
                    }
                    result += (int)(pts[m].Y * up / down);
                }
                if (result < 880 && result > -1)
                {
                    bmp.SetPixel(i, result, Color.Red);
                   
                }
                p.Add(new Point(i, result));

            }
            g.DrawLines(Pens.Red, p.ToArray());
            pictureBox1.Image = bmp;
        }
    }
}
