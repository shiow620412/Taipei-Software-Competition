using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_103_2
{
    public partial class Form1 : Form
    {
        Button[,] btns;
        public Form1()
        {
            InitializeComponent();
            btns = new Button[5, 5];
            for (int i = 0; i < btns.GetLength(0); i++)
            {
                for (int j = 0; j < btns.GetLength(1); j++)
                {
                    btns[i, j] = new Button();
                    btns[i, j].Text = "";
                    btns[i, j].BackColor = Color.White;
                    btns[i, j].Size = new Size(50, 50);
                    btns[i, j].Location = new Point(0 + 50 * i, 0 + 50 * j);
                    btns[i, j].Click += (s, e) =>
                    {
                        Button btn = (Button)s;
                        if (btn.BackColor == Color.White)
                            btn.BackColor = Color.Black;
                        else
                            btn.BackColor = Color.White;

                    };
                    Controls.Add(btns[i, j]);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Button> lst = Controls.OfType<Button>().ToList();
            List<Point> markP = new List<Point>();
            lst.SkipWhile(x => x.Text == "轉換").ToList().ForEach(x =>
                {
                    if (x.BackColor == Color.Black && x.Enabled == true)
                    {
                        Point p = new Point(x.Location.X / 50, x.Location.Y / 50);
                        Point nP = new Point();
                        nP.X = (1 * p.X + 1 * p.Y) % 5;
                        nP.Y = (1 * p.X + 2 * p.Y) % 5;
                        btns[p.X, p.Y].BackColor = Color.White;
                        markP.Add(nP);
                       
                    }

                });
            markP.ForEach(x =>
            {
                btns[x.X, x.Y].BackColor = Color.Black;
            });
        }
    }
}
