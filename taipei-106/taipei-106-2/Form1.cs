using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_106_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Poker[] p = new Poker[2];
        PictureBox[] com;
        PictureBox[] player;
        private void Form1_Load(object sender, EventArgs e)
        {
            com = new PictureBox[]
            {
                pb_com_1,
                pb_com_2,
                pb_com_3,
                pb_com_4,
                pb_com_5,
            };
            player = new PictureBox[]
            {
                pb_player_1,
                pb_player_2,
                pb_player_3,
                pb_player_4,
                pb_player_5,
            };
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                p[0] = new Poker(File.ReadAllText(ofd.FileName).Split(' '));
                for (int i = 0; i < player.Length; i++)
                {
                    player[i].Image = Image.FromFile(@".\cards\" + p[0].FlowerColor[i] + p[0].Num[i] + ".bmp");
                }
            }

        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            string[] fc = new string[] { "C", "D", "H", "S" };
            List<string> poker = new List<string>();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 1; i <= 5; i++)
                poker.Add(fc[rnd.Next(4)] + rnd.Next(1, 11));
            p[1] = new Poker(poker.ToArray());
            for (int i = 0; i < com.Length; i++)
            {
                com[i].Image = Image.FromFile(@".\cards\" + p[1].FlowerColor[i] + p[1].Num[i] + ".bmp");
            }
            string[] data = p[0].getGrade();
            string[] data2 = p[1].getGrade();
            string s = "甲方類別：" + data[1] + Environment.NewLine;
            s += "乙方類別：" + data2[1] + Environment.NewLine;
            if (int.Parse(data[0]) > int.Parse(data2[0]))
                s += "甲方獲勝";
            else if (int.Parse(data[0]) < int.Parse(data2[0]))
                s += "乙方獲勝";
            else
                s += "和局";
            txtbox_inf.Text = s;


        }
        class Poker
        {
            public List<int> Num = new List<int>();
            public List<string> FlowerColor = new List<string>();
            private int[] bookNum = new int[11];
            private int[] bookFlowerColor = new int[5];
            public Poker(string[] str)
            {
                foreach (var s in str)
                {
                    Num.Add(int.Parse(s.Substring(1, 1)));
                    FlowerColor.Add(s.Substring(0, 1));
                    bookNum[Num[Num.Count - 1]]++;
                    switch (FlowerColor[FlowerColor.Count - 1])
                    {
                        case "C":
                            bookFlowerColor[1]++;
                            break;
                        case "D":
                            bookFlowerColor[2]++;
                            break;
                        case "H":
                            bookFlowerColor[3]++;
                            break;
                        case "S":
                            bookFlowerColor[4]++;
                            break;
                    }


                }
            }
            public string[] getGrade()
            {
                if (bookNum.Contains(4) | bookNum.Contains(5))
                    return new string[] { "10", "4 張相同" };
                if (bookNum.Contains(3) && bookNum.Contains(2))
                    return new string[] { "7", "3+2 張相同型式" };
                if (bookNum.Contains(3))
                    return new string[] { "5", "3 張相同" };
                if (bookNum.Count(x => x == 2) == 2)
                    return new string[] { "4", "2+2 張相同型式" };
                if (bookNum.Contains(2))
                    return new string[] { "2", "2 張相同" };
                if (bookFlowerColor.Count(x => x == bookFlowerColor[0]) == 5)
                    return new string[] { "1", "花色相同" };

                return new string[] { "0", "其他" };
            }
        }


    }
}
