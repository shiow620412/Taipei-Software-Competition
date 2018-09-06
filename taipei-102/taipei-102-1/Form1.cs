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
        private void button2_Click(object sender, EventArgs e)
        {
            output = new int[input.Length, input[0].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).Length];
            int[] temp;
            for(int i =0; i < input.Length;i++)
            {
                temp = Array.ConvertAll(input[i].Split(new string[] { "\t" },StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
                for(int j = 0; j < output.GetLength(1); j++)
                {
                    output[i, j] = temp[j];
                }
            }
            textBox2.Text += "0\t";
            for (int i = 0; i < output.GetLength(1); i++)
                textBox2.Text += "0\t";

        }
    }
}
