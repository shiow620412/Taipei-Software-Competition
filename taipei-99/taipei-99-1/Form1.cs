using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_99_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtbox = new TextBox[] {
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10
            };
            ans = new TextBox[]
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4
            };

        }
        TextBox[] txtbox,ans;
        class book
        {
            public int num;
            public bool record;
            public book (int num)
            {
                this.num = num;
                record = false;
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int[] tip;
        List<book> bk = new List<book>();
        int[] used = new int[5];
        private void button1_Click(object sender, EventArgs e)
        {
            txtbox.ToList().ForEach(x =>
            {
                int temp = int.Parse(x.Text);
                if(temp > 20 | temp <-20)
                {
                    MessageBox.Show("數字超出範圍");
                }
            });
            ans.ToList().ForEach(x => x.Clear());
            for (int i = -20; i <= 20; i++)
                bk.Add(new book(i));
            tip = Array.ConvertAll(txtbox, s => int.Parse(s.Text));
            getAns = false;
            dfs(1);
            if (!getAns)
                MessageBox.Show("無解");
        }
        bool getAns = false;
        void dfs(int step)
        {
            if (step == 5 )
            {
                if (used[1] + used[3] == tip[0] &&
                    used[2] + used[4] == tip[1] &&
                    used[1] + used[4] == tip[2] &&
                    used[3] + used[4] == tip[3] &&
                    used[1] + used[2] == tip[4] &&
                    used[2] + used[3] == tip[5])
                { 
                    textBox1.Text = used[1].ToString();
                    textBox2.Text = used[2].ToString();
                    textBox3.Text = used[3].ToString();
                    textBox4.Text = used[4].ToString();
                    getAns = true;
                }
                return;
            }
            for(int i = -20; i <=20; i++)
            {
                if(!bk.Find(x=>x.num==i).record && !getAns)
                {
                    book b = bk.Find(x => x.num == i);
                    b.record = true;
                    used[step] = i;
                    dfs(step + 1);
                    b.record = false;
                    used[step] = 0;
                }
            }
        }
    }
}
