using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace taipei_101_4正常解法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Button> btn = panel1.Controls.OfType<Button>().ToList();
            btn.ForEach(x => x.Click += (s, e) => { textBox1.Text += ((Button)s).Text; });
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (!Regex.IsMatch(input, @"^[0-9().*/+-]+$"))
            {
                MessageBox.Show("運算式有誤");
                return;
            }

            Stack<string> output = new Stack<string>();
            string temp = "";
            string tempNum = "";
            string tempOpa = "";
            for (int i = 0; i < input.Length; i++)
            {
                temp = input.Substring(i, 1);
                if (Regex.IsMatch(temp, @"^[0-9]$") | temp == ".")
                    tempNum += temp;
                else
                {
                    if (tempNum.Length != 0)
                    {
                        output.Push(tempNum);
                        tempNum = "";
                    }
                    if (temp =="(" | temp==")" | tempOpa.Length >0)
                    {
                        tempOpa += temp;
                        if (tempOpa.Length > 2)
                            if (tempOpa.Substring(0, 1) == "(" && tempOpa.Substring(tempOpa.Length - 1, 1) == ")")
                            {
                                tempOpa = tempOpa.Substring(1).Remove(tempOpa.Substring(1).Length - 1);
                                output.Push(tempOpa);
                                tempOpa = "";
                            }
                    }
                    else                    
                        output.Push(temp);                                    
                }                
            }
            if(tempNum.Length>0)
                output.Push(tempNum);
            float limit = 2147483647;
            float ans1 = limit;
            float ans2 = limit;
            
            Stack<string> opa = new Stack<string>();
            while(output.Count>0)
            {
                temp = output.Pop();
                if (Regex.IsMatch(temp, @"^[0-9.]+$"))
                {
                    if (ans1 == limit)
                        ans1 = float.Parse(temp);
                    else
                        ans2 = float.Parse(temp);
                }
                else
                {
                    opa.Push(temp);
                }
                if(opa.Count>0 && ans1!=limit && ans2!=limit)
                {
                    ans1 = Operator(opa.Pop(), ans1, ans2);
                    ans2 = limit;
                }
            }
            File.WriteAllText(@".\b.txt", $"{textBox1.Text} = {ans1}");
        }
        float Operator(string temp,float ans1,float ans2)
        {
            switch (temp)
            {
                case "+":
                    ans1 = ans1 + ans2;
                    ans2 = 2147483647;
                    break;
                case "-":
                    ans1 = ans1 - ans2;
                    ans2 = 2147483647;
                    break;
                case "*":
                    ans1 = ans1 * ans2;
                    ans2 = 2147483647;
                    break;
                case "/":
                    ans1 = ans1 / ans2;
                    ans2 = 2147483647;
                    break;
            }
            return ans1;
        }
    }
}
