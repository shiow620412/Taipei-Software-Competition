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
namespace taipei_102_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] output;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(Image.FromFile(ofd.FileName));
                output = new int[bmp.Width, bmp.Height];
                for(int i = 0; i < bmp.Height;i++)
                {
                    for(int j = 0;j<bmp.Width; j++)
                    {
                        output[j, i] = bmp.GetPixel(j, i).R;
                    }
                }
                pictureBox1.Image = bmp;
                /*string[] input;
                input = File.ReadAllLines(ofd.FileName);
                string[] temp = input[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                output = new int[temp.Length, input.Length];
                textBox1.Text = ofd.FileName;
                textBox2.Clear();                
                for(int i = 0;i < input.Length;i++)
                {
                    temp = input[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j =0; j< temp.Length;j++)
                    {
                        output[j, i] = int.Parse(temp[j]);                                                
                        textBox2.Text += $"_{temp[j]}";
                    }
                    textBox2.Text += "\r\n";
                }
                */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            int error = 0;
            for (int j = 0; j < bmp.Height; j++)
                for (int i = 0;i < bmp.Width;i++)                
                {
                    if(output[i,j] > 128)
                    {
                        error = output[i, j] - 255;
                        output[i, j] = 255;                        
                    }
                    else
                    {
                        error = output[i, j];
                        output[i, j] = 0;
                    }
                    if (i + 1 <  bmp.Width)
                    {
                        if ((output[i + 1, j] + error * 7 / 16) > 255)
                            output[i + 1, j] = 255;
                        else if ((output[i + 1, j] + error * 7 / 16) < 0)
                            output[i + 1, j] = 0;
                        else
                            output[i + 1, j] += error * 7 / 16;
                    }
                    if (i - 1 > 0 && j+1 <  bmp.Height)
                    {
                        if ((output[i - 1, j+1] + error * 3 / 16) > 255)
                            output[i - 1, j+1] = 255;
                        else if ((output[i - 1, j+1] + error * 3 / 16) < 0)
                            output[i - 1, j + 1] = 0;
                        else         
                            output[i - 1, j+1] += error * 3 / 16;
                    }
                    if ( j + 1 <  bmp.Height)
                    {
                        if ((output[i, j + 1] + error * 5 /  16) > 255)
                            output[i , j + 1] = 255;
                        else if ((output[i , j+1] + error * 5 / 16) < 0)
                            output[i , j+1] = 0;
                        else
                            output[i , j + 1] += error * 5 / 16;
                    }
                    if (i + 1 <  bmp.Width && j + 1 <  bmp.Height)
                    {
                        if ((output[i + 1, j + 1] + error * 1 / 16) > 255)
                            output[i + 1, j + 1] = 255;
                        else if ((output[i + 1, j+1] + error * 1 / 16) < 0)
                            output[i + 1, j+1] = 0;
                        else
                            output[i + 1, j + 1] += error * 1 / 16;
                    }

                }
            /*for (int j = 0; j < output.GetLength(1); j++)
            {
                for (int i = 0; i < output.GetLength(0); i++)
                    textBox3.Text += "_" + output[i, j];
                textBox3.Text += "\r\n";
            }*/
            
            for(int i = 0; i < bmp.Height;i++   )
            {
                for(int j =0; j <bmp.Width;j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(output[j, i], output[j, i], output[j, i]));
                }
            }
            pictureBox2.Image = bmp;

        }
    }
}
