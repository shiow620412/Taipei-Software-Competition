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

namespace taipei_102_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] input;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd .ShowDialog()== DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(ofd.FileName);
                input = File.ReadAllLines(ofd.FileName);
            }
        }
        int[,] output;
        int[,] outputTemp;
        private void button2_Click(object sender, EventArgs e)
        {
            
            outputTemp = new int[input.Length, input[0].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).Length];
            output = new int[outputTemp.GetLength(0), outputTemp.GetLength(1)];
            int[] temp;
            
            for (int i =0; i < input.Length;i++)
            {
                temp = Array.ConvertAll(input[i].Split(new string[] { "\t" },StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
                for(int j = 0; j < outputTemp.GetLength(1); j++)
                {
                    outputTemp[i, j] = temp[j];
                }
            }
            for(int i = 0;i < output.GetLength(0);i++)
            {
                for(int j = 0; j<output.GetLength(1);j++)
                {
                    if (i == 0 && j == 0)
                        output[i, j] = outputTemp[i, j];
                    else if (i == 0)
                        output[i, j] = outputTemp[i, j]  + output[i, j - 1];
                    else if( j== 0 )
                        output[i, j] = outputTemp[i, j ] + output[i-1, j ];
                    else if ( i != 0 && j != 0)
                        output[i, j] = outputTemp[i,j]+output[i, j - 1] + output[i-1, j ]- output[i-1, j - 1];
                }
            }
            textBox2.Text += "0\t";
            for (int i = 0; i < output.GetLength(1); i++)
                textBox2.Text += "0\t";
            textBox2.Text += "\r\n";
            for (int i = 0; i < output.GetLength(0); i++)
            {
                textBox2.Text += "0\t";
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    textBox2.Text += output[i,j]+"\t";
                }
                textBox2.Text += "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point leftup = new Point(int.Parse(textBox4.Text) - 1, int.Parse(textBox3.Text) - 1);
            Point rightdown = new Point(int.Parse(textBox6.Text) - 1, int.Parse(textBox5.Text) - 1);
            int sum = 0;
            for(int i = leftup.X; i <= rightdown.X; i ++)
            {
                for(int j = leftup.Y; j<=rightdown.Y;j++)
                {
                    sum += outputTemp[i, j];
                }
            }
            textBox7.Text = sum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point leftup = new Point( int.Parse(textBox4.Text)-1, int.Parse(textBox3.Text)-1);
            Point rightdown = new Point( int.Parse(textBox6.Text)-1, int.Parse(textBox5.Text)-1);
            float average= 0;
 
            for (int i = leftup.X; i <= rightdown.X; i++)
            {
                for (int j = leftup.Y; j <= rightdown.Y; j++)
                {
                    average += outputTemp[i, j];
                }
            }
            textBox8.Text = (average/ ((rightdown.Y-leftup.Y+1)*(rightdown.X - leftup.X+1))).ToString();
        }
    }
}
