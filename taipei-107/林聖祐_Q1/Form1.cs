using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 林聖祐_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] output ;
        void dfs(int step)
        {
            if(step== input.Count)
            {
                test.Add(string.Join("", output) + "\r\n");
               
                return;
            }
            for(int i =0;i<input.Count;i++)
            {
                if(!book[i])
                {
                    output[step] = input[i];
                    book[i] = true;
                    dfs(step + 1);
                    book[i] = false;
                    
                }
            }
        }
        List<string> input ;
        List<string> test = new List<string>();
        bool[] book;
        private void button1_Click(object sender, EventArgs e)
        {
            input = new List<string>();
            for(int i =0; i< textBox1.Text.Length;i++)
            {
                input.Add(textBox1.Text[i].ToString());
            }
            output = new string[input.Count];
            book = new bool[input.Count];
            textBox3.Clear();
            test.Clear();
            dfs(0);
            textBox3.Text = string.Join("", test.ToArray());
            textBox2.Text = (textBox3.Text.Split('\n').Length-1).ToString();
      
        }
    }
}
