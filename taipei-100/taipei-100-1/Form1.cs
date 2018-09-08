using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_100_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       void dfs(int step)
        {
            if(step==4)
            {
                if (card[1] + card[2] == sumAB && card[1] + card[3] == sumAC)
                    textBox4.Text += $"A ={card[1]} B ={card[2]} C ={card[3]} " + Environment.NewLine;
                return;
            }
            for(int i = 1;i<min;i++)
            {
                if (book[i] == 0)
                {
                    card[step] = i;
                    book[i] = 1;
                    dfs(step + 1);
                    book[i] = 0;
                    card[step] = 0;
                }
            }
        }
        int sumAB, sumAC, min;
        int[] book,card;
        private void button1_Click(object sender, EventArgs e)
        {
             sumAB = int.Parse(textBox1.Text);
             sumAC = int.Parse(textBox2.Text);
             min = int.Parse(textBox3.Text);
            book = new int[min];
            card = new int[4];
            textBox4.Text = "";
            dfs(1);
            if (textBox4.Text.Equals(""))
                textBox4.Text = "無解";
        }
    }
}
