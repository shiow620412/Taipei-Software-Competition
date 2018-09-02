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

namespace taipei_104_4
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
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int w = bmp.Width, h = bmp.Height;
            double n=w*h;
            double muA = 0, muB = 0
                , muA2 = 0, muB2 = 0
                , sigmaA2 = 0, sigmaB2 = 0;
            for(int i =0;i<w;i++)
                for(int j =0;j<h;j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    muA += c.R - c.G;
                    muB += (c.R + c.G) * 0.5 - c.B;
                }
            muA /= n;
            muB /= n;
            muA2 = muA * muA;
            muB2 = muB * muB;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    double alpha= c.R - c.G;
                    double beta = (c.R + c.G) * 0.5 - c.B;
                    sigmaA2 += alpha * alpha - muA2;
                    sigmaB2 += beta * beta - muB2;
                }
            sigmaA2 /= n;
            sigmaB2 /= n;
            double QM1 = 0, QM2 = 0;
            QM1 = (Math.Sqrt(sigmaA2 + sigmaB2) + 0.3 * Math.Sqrt(muA2 + muB2)) / 85.59;
            QM2 = 0.02 * Math.Log(sigmaA2 / (Math.Pow(Math.Abs(muA), 0.2))) * Math.Log(sigmaB2 / (Math.Pow(Math.Abs(muB), 0.2)));
            textBox1.Text = QM1.ToString();
            textBox2.Text = QM2.ToString();
        }
    }
}
