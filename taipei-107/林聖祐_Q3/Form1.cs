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
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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
        decimal[,] M, A;
        private void button2_Click(object sender, EventArgs e)
        {
            int xBlock = int.Parse(textBox1.Text);
            int yBlock = int.Parse(textBox2.Text);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
             M = new decimal[bmp.Width, bmp.Height];
             A = new decimal[bmp.Width, bmp.Height];
            //double[,] M = new double[bmp.Width, bmp.Height];
            //double[,] A = new double[bmp.Width, bmp.Height];
            string txt3 = "";           string txt4 = "";
            for(int i = 0;i< bmp.Width;i++)
            //for (int i = xBlock * 8; i < xBlock * 8+8; i++)
            {
                for(int j =0;j<bmp.Height;j++)
                //for (int j = yBlock* 8; j < yBlock * 8+8; j++)
                {
                    /*
                    Color pixelLeft = i - 1 < 0 ? Color.Black : bmp.GetPixel(i - 1, j);
                    Color pixelUp = j + 1 >= bmp.Height ? Color.Black : bmp.GetPixel(i, j + 1);
                    Color pixelRight = i + 1 >= bmp.Width ? Color.Black : bmp.GetPixel(i + 1, j);
                    Color pixelDown = j - 1 < 0 ? Color.Black : bmp.GetPixel(i, j - 1);

                    float GxR = pixelRight.R - pixelLeft.R;
                    float GyR = pixelUp.R - pixelDown.R;
                    float MR = (float)Math.Sqrt(GxR * GxR + GyR * GyR);
                    float AR = (float)(Math.Atan2(GyR, GxR) * 180.0 / Math.PI);

                    float GxG = pixelRight.G - pixelLeft.G;
                    float GyG = pixelUp.G - pixelDown.G;
                    float MG = (float)Math.Sqrt(GxG * GxG + GyG * GyG);
                    float AG = (float)(Math.Atan2(GyG, GxG) * 180.0 / Math.PI);

                    float GxB = pixelRight.B - pixelLeft.B;
                    float GyB = pixelUp.B - pixelDown.B;
                    float MB = (float)Math.Sqrt(GxB * GxB + GyB * GyB);
                    float AB = (float)(Math.Atan2(GyB, GxB) * 180.0 / Math.PI);

                    float MaxM=0, MaxA=0;
                    if (MR > MG && MR > MB) { MaxM = MR; MaxA = AR; }
                    if (MG > MR && MG > MB) { MaxM = MG; MaxA = AG; }
                    if (MB > MR && MB > MG) { MaxM = MB; MaxA = AB; }
                    M[i, j] = Math.Floor(MaxM + 0.5);
                    A[i, j] = Math.Floor(MaxA + 0.5);*/
                    //M[i % 8, j % 8] = Math.Floor(MaxM + 0.5);
                    //A[i % 8, j % 8] = Math.Floor(MaxA + 0.5);

                    /*
                    float MaxGx = pixelRight.R - pixelLeft.R;
                    if (Math.Abs(MaxGx) <   Math.Abs(pixelRight.G - pixelLeft.G) ) MaxGx = pixelRight.G - pixelLeft.G;
                    if (Math.Abs(MaxGx) <   Math.Abs(pixelRight.B - pixelLeft.B) ) MaxGx = pixelRight.B - pixelLeft.B;

                    float MaxGy = pixelUp.R - pixelDown.R;
                    if (Math.Abs(MaxGy) < Math.Abs(pixelUp.G - pixelDown.G)) MaxGy = pixelUp.G - pixelDown.G;
                    if (Math.Abs(MaxGy) < Math.Abs(pixelUp.B - pixelDown.B)) MaxGy = pixelUp.B - pixelDown.B;

                    M[i % 8, j % 8] = Math.Floor(Math.Sqrt(MaxGx * MaxGx + MaxGy * MaxGy) + 0.5);
                    A[i % 8, j % 8] = Math.Floor(Math.Atan2(MaxGy, MaxGx) * 180 / Math.PI + 0.5);
                    */
                    

                    double GxR = (i+1 >= bmp.Width ? 0 : bmp.GetPixel(i + 1, j).R) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).R);
                    double GyR = (j+1 >= bmp.Height ? 0 : bmp.GetPixel(i , j + 1).R) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i , j - 1).R);
                    //
                    double GxG = (i + 1 >= bmp.Width ? 0 : bmp.GetPixel(i + 1, j).G) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).G);
                    double GyG = (j +1 >= bmp.Height ? 0 : bmp.GetPixel(i, j + 1).G) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i, j - 1).G);
                    //
                    double GxB = (i + 1 >= bmp.Width ? 0 : bmp.GetPixel(i + 1, j).B) -
                              (i -1 < 0 ? 0 : bmp.GetPixel(i - 1, j).B);
                    double GyB = (j +1 >= bmp.Height ? 0 : bmp.GetPixel(i, j + 1).B) -
                              (j -1 < 0 ? 0 : bmp.GetPixel(i, j - 1).B);
                    //
                    
                    decimal MR = (decimal)Math.Sqrt( GxR * GxR + GyR * GyR);
                    decimal MG = (decimal)Math.Sqrt(GxG * GxG + GyG * GyG);
                    decimal MB = (decimal)Math.Sqrt(GxB * GxB + GyB * GyB);
                    decimal AR =  (decimal)(Math.Atan2(GyR , GxR)*180/Math.PI);
                    decimal AG =  (decimal)(Math.Atan2(GyG , GxG)*180/Math.PI);
                    decimal AB =  (decimal)(Math.Atan2(GyB , GxB)*180/Math.PI);


                    decimal Mmax = 0; decimal Amax = 0;
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
                    M[i , j ] = Math.Floor(Mmax + 0.5M);
                    A[i , j ] =Math.Floor(Amax + 0.5M);
                   bmp2.SetPixel(i, j, Color.FromArgb((int)M[i, j] >= 255 ? 255 : (int)M[i, j], (int)M[i, j] >= 255 ? 255 : (int)M[i, j], (int)M[i, j] >= 255 ? 255 : (int)M[i, j]));
                }

            }
            pictureBox2.Image = bmp2;
            decimal[] hog = new decimal[9];
            for(int i = 0; i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    txt3 += M[j, i].ToString().PadLeft(7)+"\t";
                    txt4 += A[j, i].ToString().PadLeft(7)+"\t";
                    //計算HOG
                   
                }
                txt3 += "\r\n";
                txt4 += "\r\n";
            }                 
            textBox3.Text = txt3;
            textBox4.Text = txt4;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal[] hog = new decimal[9];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    int index = 0;
                    decimal getA = Math.Abs((int)A[j, i]);
                    while (getA >= 20)
                    {
                        getA -= 20;
                        index++;
                    }
                    if (getA == 0)
                    {
                        hog[index] += M[j, i];
                        continue;
                    }
                    decimal directionFirstValue = ((20 - getA) / 20 * M[j, i]);
                    decimal directionSecondValue = (M[j, i] - directionFirstValue);
                    int index2 = index + 1 >= hog.Length ? 0 : index + 1;
                    hog[index] += directionFirstValue;
                    hog[index2] += directionSecondValue;
                }
            textBox5.Clear();
            for (int i = 0; i < hog.Length; i++)
                textBox5.Text += $"{(i + ":" + hog[i]).ToString().PadLeft(7)}\t";
        }
    }

}

