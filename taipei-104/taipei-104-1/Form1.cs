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

namespace taipei_104_1
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
            Button[] btn = new Button[9];
            TextBox[] tb = new TextBox[] { textBox1, textBox2 };
            for (int i = 0; i < btn.Length; i++)
            {
                btn[i] = new Button();
                btn[i].Name = "btn" + i;
                btn[i].Size = new Size(50, 50);
                btn[i].Location = new Point(0 + i % 3 * 50, 0 + i / 3 * 50);
                btn[i].Click += (s, e) =>
                {
                    foreach (var t in tb)
                    {
                        if (!Regex.IsMatch(t.Text, "[A-za-z]"))
                        {
                            MessageBox.Show("請輸入A-z or a-z");
                            return;
                        }
                    }
                    if (tb[0].Text == tb[1].Text)
                    {
                        MessageBox.Show("符號不可相同");
                        return;
                    }
                    if (!((Button)s).Text.Equals(""))
                    {
                        MessageBox.Show("該點已下過");
                        return;
                    }
                    Button button = (Button)s;
                    button.Text = turn ? tb[0].Text : tb[1].Text;
                    turnCount++;
                    turn = !turn;
                    bool iswin = false;
                    //直 橫 左斜 右斜
                    List<string> row = new List<string>(),col = new List<string>(), rightSlash = new List<string>(), leftSlash = new List<string>();
                    for (int m = 0; m <= 6 & !iswin; m += 3)
                    {
                        for (int n = m; n <= m + 2; n++)
                            row.Add(btn[n].Text);
                       if (row.Count(x=>x==row[0] && x!="") == 3)
                           iswin = true;
                        row.Clear();
                    }
                    for (int m = 0; m <= 2 & !iswin; m++)
                    {
                        for (int n = m; n <= m + 6; n += 3)
                            col.Add(btn[n].Text);
     
                            if (col.Count(x => x == col[0] && x != "") == 3)
                                iswin = true;
                        col.Clear();
                    }
                    for (int m = 0; m <= 8 & !iswin; m += 4)
                    {
                        rightSlash.Add(btn[m].Text);
                    }
      
                        if (rightSlash.Count(x => x == rightSlash[0] && x != "") == 3)
                            iswin = true;
                    for (int m = 6; m >= 2 & !iswin; m -= 2)
                    {
                        leftSlash.Add(btn[m].Text);
                    }

                        if (leftSlash.Count(x => x == leftSlash[0] && x != "") == 3)
                            iswin = true;
                    if (iswin)
                    { 
                        if (turnCount % 2 == 0)
                            MessageBox.Show("乙方勝利");
                        else
                            MessageBox.Show("甲方勝利");
                        foreach (var b in btn) b.Text = "";
                        turnCount = 0;
                        turn = true;
                     }


                };
            }
            Controls.AddRange(btn);
        }

   
    }
}
