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

namespace taipei_105_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Fruit
        {
            public string fruit;
            public int count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "文字檔(*.txt)|*.txt";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                string[] input = File.ReadAllText(ofd.FileName, Encoding.Default).Replace("\r","").Split('\n');
                List<Fruit> l = new List<Fruit>();
                string[] temp;
                for(int i =0;i<input.Length;i++)
                {
                    temp = input[i].Split('、');
                    for(int j =0;j<temp.Length;j++)
                    {
                        if(l.Exists(x=>x.fruit==temp[j]))
                        {
                            l.Find(x => x.fruit == temp[j]).count++;
                        }
                        else
                        {
                            Fruit f = new Fruit();
                            f.fruit = temp[j];
                            f.count++;
                            l.Add(f);
                        }
                    }
                }
                l = l.OrderByDescending(x=>x.count).ToList();
                List<TextBox> txt = Controls.OfType<TextBox>().Reverse().ToList();
                for(int i =0;i<txt.Count-1;i++)
                {
                    txt[i].Text = l[i].fruit;
                }
                txt[txt.Count - 1].Text = l[l.Count - 1].fruit;
            }
        }
    }
}
