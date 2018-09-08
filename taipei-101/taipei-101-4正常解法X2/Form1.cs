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
        Stack<string> output = new Stack<string>();
        string input;
        private void button18_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            
            if (!Regex.IsMatch(input, @"^[0-9()+-/*.]+$"))
            {
                MessageBox.Show("運算式錯誤");
                return;
            }
            i = 0;
            Postfix(0,false);
            popStack();
            File.WriteAllText(@".\b.txt", $"{textBox1.Text} = {ans}");
        }
        int i = 0;
        void Postfix(int countNum,bool waitAdd )
        {
            string num = "", temp = "", bracketes = "";
            for (int count =i; i < input.Length; i++)
            {
                if (countNum == 2 && waitAdd)
                {
                    countNum =0;
                    return;
                }
                temp = textBox1.Text.Substring(i, 1);
                if (Regex.IsMatch(temp, @"^[0-9]$") | temp == ".")
                {
                    num += temp;                    
                }
                else
                {
                    if (num.Length > 0)
                    {
                        output.Push(num);
                        countNum++;
                        num = "";
                    }
                    if (temp == "(" | temp == ")" | bracketes.Contains("("))
                    {
                        bracketes += temp;
                        if (bracketes.Contains("(") && bracketes.Contains(")"))
                        {
                            bracketes = bracketes.Replace("(", "").Replace(")", "");
                            if (countNum < 2)
                            {
                                i++;
                                Postfix(countNum, true);
                            }
                            countNum -= 2;
                            output.Push(bracketes);
                            bracketes = "";
                        }
                    }
                    else
                    {
                        if (countNum < 2)
                        {
                            i++;
                            Postfix(countNum, true);
                        }
                        countNum -= 2;
                        output.Push(temp);
                    }
                }
            }
        }
        float ans = 0;
        float popStack()
        {
            string temp = "";
            float limit = 2147483647;
            float ans1 = limit, ans2 = limit;
            Stack<string> opa = new Stack<string>();
            while (output.Count > 0)
            {
                temp = output.Pop();
                if (Regex.IsMatch(temp, @"^[0-9.]+$"))
                    if (ans1 == limit)
                        ans1 = float.Parse(temp);
                    else
                        ans2 = float.Parse(temp);
                else
                    opa.Push(temp);
                if (ans1 != limit && ans2 != limit)
                    
                if (opa.Count > 0)
                {
                    if (ans1 != limit && ans2 != limit)
                    {
                        popStack();
                    }
                        Operator(opa.Pop(), ans1, ans2);
                        ans1 = limit;
                        ans2 = limit;
                    
                }
                

            }
            return 0;
        }
        void Operator(string ope,float ans1,float ans2)
        {
            switch (ope)
            {
                case "+":
                    ans = ans1 + ans2;
                    break; 
                case "-":
                    ans =  ans1 - ans2;
                    break;            
                case "*":
                    ans =  ans1* ans2;
                    break;
                case "/":
                    ans =   ans1 / ans2;
                    break;  
            }
            
        }
    }
}
