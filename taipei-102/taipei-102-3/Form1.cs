using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_102_3
{
    public partial class Form1 : Form
    {
        TextBox[,] txtbox;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            if( n < 3 | n > 11 | n%2 !=1)
            {
                label1.Text = "錯誤";
                return;
            }
            label1.Text = "成功";
            txtbox = new TextBox[n, n];
            for(int i = 0; i < txtbox.GetLength(1);i++)
            {
                for(int j = 0; j < txtbox.GetLength(0);j++)
                {
                    txtbox[j, i] = new TextBox();
                    txtbox[j, i].Text = "";
                    txtbox[j, i].Location = new Point(12 + j * 50, 37 + i * 31);
                    txtbox[j, i].Size = new Size(44, 25);
                    Controls.Add(txtbox[j, i]);
                }
            }
            int num = 1;
            Point p = new Point(n / 2 , 0);
            txtbox[p.X, p.Y].Text= num.ToString();
            
            while(num < n*n)
            {
                num++;
                Point temp = p;
                p.X -= 1;
                p.Y -= 1;
                if (p.X < 0)
                    p.X = n - 1;
                if (p.Y < 0)
                    p.Y = n - 1;
                if (txtbox[p.X, p.Y].Text != "")
                {
                    p.X = temp.X;
                    p.Y = temp.Y + 1;
                    txtbox[p.X, p.Y ].Text = num.ToString();
                }
                else
                    txtbox[p.X, p.Y].Text = num.ToString();
            }
        }
    }
}
