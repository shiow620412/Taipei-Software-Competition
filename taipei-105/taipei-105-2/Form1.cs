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

namespace taipei_105_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[,] input;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "文字檔(*.txt)|*.txt";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                txtbox_obj.Clear();
                txtbox_data.Clear();
                txtbox_file.Text = ofd.FileName;
                string[] data = File.ReadAllLines(ofd.FileName);
                txtbox_height.Text =data.Length.ToString();
                txtbox_width.Text = data[0].Split('\t').Length.ToString();
                input = new string[int.Parse(txtbox_height.Text), int.Parse(txtbox_width.Text)];
                string[] temp;
                for(int i =0;i<data.Length;i++)
                {
                    temp = data[i].Split('\t');
                    for(int j =0;j<temp.Length;j++)
                    {
                        input[i, j] = temp[j];
                        txtbox_data.Text += temp[j] + "\t";
                    }
                    txtbox_data.Text += "\r\n";
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Point> l = new List<Point>();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                    if (input[i, j] == "255")
                    {
                        l.Add(new Point(i, j));
                        dfs(l.Last().X, l.Last().Y, l.Count);
                    }
            
            }        
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    txtbox_obj.Text += input[i, j] + "\t";
                }
                txtbox_obj.Text += "\r\n";

            }
            lbl_obj.Text = l.Count.ToString();
        }
        void dfs(int a,int b,int count )
        {
            int arr_index1, arr_index2;
            for(int i = -1;i<=1;i++)
            {
                for(int j =-1;j<=1;j++)
                {
                    arr_index1 = a + i;
                    arr_index2 = b + j;
                    if (arr_index1 < 0 | arr_index2 < 0 | arr_index1 >= input.GetLength(0) | arr_index2 >= input.GetLength(1))
                        continue;
                    if (input[arr_index1, arr_index2] == "255")
                    {
                        input[arr_index1, arr_index2] = count.ToString();
                        dfs(arr_index1, arr_index2, count);
                    }
                }
            }
        }
    }
}
