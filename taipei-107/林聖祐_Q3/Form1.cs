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
namespace 林聖祐_Q3
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
                label1.Text = $"W:{pictureBox1.Image.Width} H:{pictureBox1.Image.Height}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int xBlock = int.Parse(textBox1.Text);
            int yBlock = int.Parse(textBox2.Text);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            double[,] M = new double[8, 8];
            double[,] A = new double[8, 8];
            string txt3 = "";
            string txt4 = "";
            for (int i = xBlock * 8; i < xBlock * 8+8; i++)
            {
                for (int j = yBlock* 8; j < yBlock * 8+8; j++)
                {
                    float GxR = (i+1 > bmp.Width ? 0 : bmp.GetPixel(i + 1, j).R) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).R);
                    float GyR = (j+1 > bmp.Height ? 0 : bmp.GetPixel(i , j + 1).R) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i , j - 1).R);
                    //
                    float GxG = (i + 1 > bmp.Width ? 0 : bmp.GetPixel(i + 1, j).G) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).G);
                    float GyG = (j +1 > bmp.Height ? 0 : bmp.GetPixel(i, j + 1).G) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i, j - 1).G);
                    //
                    float GxB = (i + 1 > bmp.Width ? 0 : bmp.GetPixel(i + 1, j).B) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).B);
                    float GyB = (j +1 > bmp.Height ? 0 : bmp.GetPixel(i, j + 1).B) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i, j - 1).B);
                    //
                    double MR = Math.Sqrt(GxR * GxR + GyR * GyR);
                    double MG = Math.Sqrt(GxG * GxG + GyG * GyG);
                    double MB = Math.Sqrt(GxB * GxB + GyB * GyB);
                    double AR = GxR == 0 ? 0 : Math.Atan(GyR / GxR)*57.3;
                    double AG = GxG == 0 ? 0 : Math.Atan(GyG / GxG)*57.3;
                    double AB = GxB == 0 ? 0 : Math.Atan(GyB / GxB)*57.3;
                    double Mmax = 0;double Amax = 0;
                    if( MR > MG && MR > MB)
                    {
                        Mmax = MR;
                        Amax = AR;
                    }
                    else if(MG >MR && MG>MB)
                    { 
                        Mmax = MG;
                        Amax = AG;
                    }
                    else if (MB > MR && MB > MG)
                    {
                        Mmax = MB;
                        Amax = AB;
                    }
                    M[i%8, j%8] = Math.Floor(Mmax+0.5);
                    A[i%8, j%8] = Math.Floor(Amax+0.5);
                  
                }
              
            }
            for(int i = 0; i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    txt3 += M[j, i].ToString().PadLeft(7);
                    txt4 += A[j, i].ToString().PadLeft(7);
                }
                txt3 += "\r\n";
                txt4 += "\r\n";
            }
            textBox3.Text = txt3;
            textBox4.Text = txt4;
        }
      
            
       
    }
}
