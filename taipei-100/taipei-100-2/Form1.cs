using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_100_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Store
        {
            public string Name;
            public float AveragePrice;
            public int Price;
            public int Weight;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Store[] input = new Store[6];
            TextBox[] name = new TextBox[] { textBox3, textBox6, textBox9, textBox12, textBox15, textBox18 };
            TextBox[] price =  new TextBox[] { textBox2, textBox5, textBox8, textBox11, textBox14, textBox17 };
            TextBox[] weight = new TextBox[] { textBox1, textBox4, textBox7, textBox10, textBox13, textBox16 };
            for (int i = 0; i < input.Length;i++)
            {
                input[i] = new Store();
                input[i].Name = name[i].Text;
                input[i].Price = int.Parse(price[i].Text);
                input[i].Weight = int.Parse(weight[i].Text);
                input[i].AveragePrice = float.Parse(price[i].Text) / float.Parse(weight[i].Text);
            }
            input=input.OrderBy(x => x.AveragePrice).ToArray();
            int limit = int.Parse(textBox19.Text);
            int index = 5;
            int money=0;
            string combination = "";
            while(index > -1)
            {
                Store s = input[index];
                if( limit >= s.Weight)
                {
                    int w = limit / s.Weight;
                    money += w * s.Price;
                    limit = limit % s.Weight;
                    combination += s.Name + $"x {w} +";
                }
                index--;                   
            }
            SortedList<string, bool> sl = new SortedList<string, bool>();
            label5.Text = "=" + combination.Remove(combination.Length-1);
            label4.Text = "=" + money;

        }
    }
}


