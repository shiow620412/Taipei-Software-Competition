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

namespace taipei_105_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap gray;
        Bitmap Ix, Iy;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "圖檔|*.png";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pb_original.Image = Image.FromFile(ofd.FileName);
       
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gray = new Bitmap(pb_original.Image);
            for(int i =0; i< gray.Width;i++)
                for(int j =0;j< gray.Height;j++)
                {
                    Color c = gray.GetPixel(i, j);
                    int grayValue = (int)(c.R * 0.2125+ c.G * 0.7154+c.B * 0.0721);
                    gray.SetPixel(i,j,Color.FromArgb(grayValue,grayValue,grayValue));
                }
            pb_result.Image = gray;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ix = new Bitmap(gray);
            for (int i = 0; i < gray.Width; i++)
                for (int j = 0; j < gray.Height; j++)
                {
                    if (i - 1 < 0 | j - 1 < 0 | i + 1 > gray.Width - 1 | j + 1 > gray.Height-1)
                        continue;
                    double temp = (
                        gray.GetPixel(i - 1, j - 1).R + 
                        gray.GetPixel(i, j - 1).R + 
                        gray.GetPixel(i + 1, j - 1).R - 
                        gray.GetPixel(i-1, j + 1).R -
                        gray.GetPixel(i , j + 1).R -
                        gray.GetPixel(i + 1, j + 1).R
                        ) * 0.166666667;
                    int value = Math.Abs((int)temp);
                    Ix.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            pb_result.Image = Ix;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Iy = new Bitmap(gray);
            for (int i = 0; i < gray.Width; i++)
                for (int j = 0; j < gray.Height; j++)
                {
                    if (i - 1 < 0 | j - 1 < 0 | i + 1 > gray.Width - 1 | j + 1 > gray.Height - 1)
                        continue;
                    double temp = (
                        gray.GetPixel(i - 1, j - 1).R +
                        gray.GetPixel(i -1, j ).R +
                        gray.GetPixel(i - 1, j + 1).R -
                        gray.GetPixel(i + 1, j - 1).R -
                        gray.GetPixel(i+1, j ).R -
                        gray.GetPixel(i + 1, j + 1).R
                        ) * 0.166666667;
                    int value = Math.Abs((int)temp);
                    Iy.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            pb_result.Image = Iy;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(gray);
            for (int i = 0; i < gray.Width; i++)
                for (int j = 0; j < gray.Height; j++)
                {                   
                    int value = (int)Math.Sqrt((Ix.GetPixel(i,j).R* Ix.GetPixel(i, j).R));
                    result.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            pb_result.Image = result;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(gray);
            for (int i = 0; i < gray.Width; i++)
                for (int j = 0; j < gray.Height; j++)
                {
                    int value = (int)Math.Sqrt((Iy.GetPixel(i, j).R * Iy.GetPixel(i, j).R));
                    result.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            pb_result.Image = result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(gray);
            for (int i = 0; i < gray.Width; i++)
                for (int j = 0; j < gray.Height; j++)
                {
                    int value = (int)Math.Sqrt((Ix.GetPixel(i, j).R * Iy.GetPixel(i, j).R));
                    result.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            pb_result.Image = result;
        }
    }
}
