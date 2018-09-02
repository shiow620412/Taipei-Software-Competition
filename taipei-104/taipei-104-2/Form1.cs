using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace taipei_104_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            List<TextBox> l = Controls.OfType<TextBox>().ToList();
            l.ForEach(x => x.Clear());
        }
        string add1 = "";
        string add2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
             add1 = textBox1.Text.PadLeft(20, '0');
             add2 = textBox2.Text.PadLeft(20, '0');
            int carry = 0;
            Stack<string> answer =new Stack<string>();
            for(int i = 19;i>=0;i--)
            {
                int temp = add1.Substring(i, 1).ToInt()+
                    add2.Substring(i,1).ToInt()+
                    carry;
                carry = 0;
                if(temp.ToString().Length==2)
                {
                    carry = temp.ToString().Substring(0, 1).ToInt();
                    temp = temp.ToString().Substring(1, 1).ToInt();
                }
                answer.Push(temp.ToString());
            }
            if (carry != 0)
                answer.Push(carry.ToString());
            textBox3.Clear();
            bool clear0 = false;
            while (answer.Count > 0)
            {
                if (answer.Peek() == "0" && clear0 == false)
                {
                    answer.Pop();
                    continue;
                }
                else
                    clear0 = true;
                textBox3.Text += answer.Pop();
            }
                
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            bool big = true;
            if (textBox1.Text.Length > textBox2.Text.Length)
            {
                add1 = textBox1.Text.PadLeft(20, '0');
                add2 = textBox2.Text.PadLeft(20, '0');
            }
            else if (textBox1.Text.Length < textBox2.Text.Length)
            {
                add2 = textBox1.Text.PadLeft(20, '0');
                add1 = textBox2.Text.PadLeft(20, '0');
                big = false;
            }
            else if (textBox1.Text.Length == textBox2.Text.Length)
            {
                int i = 0;
                while(textBox1.Text.Substring(i,1)== textBox2.Text.Substring(i,1))
                {                    
                    i++;
                }
                if (textBox1.Text.Substring(i, 1).ToInt() > textBox2.Text.Substring(i, 1).ToInt())
                {
                    add1 = textBox1.Text.PadLeft(20, '0');
                    add2 = textBox2.Text.PadLeft(20, '0');
                }
                else
                {
                    add2 = textBox1.Text.PadLeft(20, '0');
                    add1 = textBox2.Text.PadLeft(20, '0');
                    big = false;
                }
            }

            Stack<string> answer = new Stack<string>();
            for (int i = 19; i >= 0; i--)
            {
                int temp = add1.Substring(i, 1).ToInt() -
                    add2.Substring(i, 1).ToInt();
                if(temp<0)
                {
                    borrow(i);
                    temp += 10;
                }
                                 
                answer.Push(temp.ToString());
            }          
            textBox3.Clear();
            if (!big)
                textBox3.Text += "-";
            bool clear0 = false;
            while (answer.Count > 0)
            {
                if (answer.Peek() == "0" && clear0 == false)
                {
                    answer.Pop();
                    continue;
                }                    
                else
                    clear0 = true;
                textBox3.Text += answer.Pop();
            }
                
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> ans = new List<int>();
            for (int i = 0; i < 40; i++)
                ans.Add(0);
            add1 = textBox1.Text.PadLeft(20, '0');
            add2 = textBox2.Text.PadLeft(20, '0');
            for(int i = 19;i>=0;i--)
            {
                for(int j =19;j>=0;j--)
                {
                    int val= add1.Substring(j, 1).ToInt() * add2.Substring(i, 1).ToInt();
                    ans[i+j+1] += val % 10;
                    ans[i+j] += val / 10;
                 
                }
            }
            voidCarry(ans);
            bool clear0 = false;
            textBox3.Clear();
            for(int i =0;i<ans.Count;i++)
            {
                if (ans[i] == 0 && !clear0)
                    continue;
                clear0 = true;
                textBox3.Text += ans[i];
            }

        }
        void voidCarry(List<int> ans)
        {
            for (int i = 39; i > 0; i--)
            {
                if (ans[i] > 9)
                {
                    ans[i - 1] += ans[i] / 10;
                    ans[i] %= 10;
                }
            }
        }
        void borrow(int i)
        {
            while (i > 0)
            {
                i--;
                if (add1.Substring(i, 1).ToInt() > 0)
                {
                    add1 = add1.Substring(0, i) + (add1.Substring(i, 1).ToInt() - 1).ToString() + add1.Substring(i + 1);
                    return;
                }
            }
        }
       
    }

    public static class Extension
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
}
