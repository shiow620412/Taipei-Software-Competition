using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
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
            if( !Regex.IsMatch(input,@"^[0-9+-/*.()]+$"))
            {
                MessageBox.Show("運算式錯誤");
                return;
            }
            //將中序式轉為後序式
            Queue<string> Postfix = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            for(int i = 0;i<input.Length;i++)
            {
                string temp = input[i].ToString();
                switch(temp)
                {
                    case "(":
                        stack.Push(temp);
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        //先乘除後加減 進來的如果是 加或減 則先把 乘或除 的符號輸出
                        while(stack.Count >0 && getPriority(stack.Peek()) >= getPriority(temp) )
                        {
                            Postfix.Enqueue(stack.Pop());
                        }
                        stack.Push(temp);
                        break;
                    case ")":
                        //將括號裡面剩下的運算子都輸出
                        while( stack.Peek() !="(")
                        {
                            Postfix.Enqueue(stack.Pop());
                        }
                        stack.Pop();
                        break;
                    default:
                        string num = "";
                        //讀取二位數以上的數字
                        for(;i< input.Length;i++)
                        {
                            if (!isNum(input[i].ToString())) break;
                            num += input[i];
                        }
                        //由於迴圈會在讀到不是數字的時候跳出
                        //但運算子還沒被排進後序式 所以要 i--
                        i--;
                        //將數字加入 佇列中
                        Postfix.Enqueue(num);
                        break;
                }
            }
            while (stack.Count > 0)
                Postfix.Enqueue(stack.Pop());

            Stack<float> ans = new Stack<float>();

            while(Postfix.Count>0)
            {
                string temp = Postfix.Dequeue();
                switch (temp)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        //將數字取出做運算
                        float a = ans.Pop();
                        float b = ans.Pop();
                        // 後序式：14/ => 中序式：1/4
                        // 堆疊會先取到 4 (a ) 在取到 1 (b)
                        // 所以如果填入 calc( / , a , b )會變成 4/1
                        // 必須將兩者調換成 calc( / , b , a )結果 1/4 才是對的
                        ans.Push(calc(temp, b,a));
                        break;
                    default:
                        //數字丟入堆疊
                        ans.Push(float.Parse(temp));
                        break;
                }
            }
          
            File.WriteAllText(@".\b.txt", $"{textBox1.Text} = {ans.Pop()}");
        }
        float calc(string opa,float a , float b)
        {
            switch (opa)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
            }
            return 0;
        }
        int getPriority(string str)
        {
            switch(str)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;                    
                default:
                    return 0;
            }
        }
        bool isNum(string str)
        {
            return Regex.IsMatch(str, "^[0-9.]+$");
        }
    }
}
