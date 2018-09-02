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

namespace taipei_104_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            for (int i = 0;i<bmp.Width;i++)
            {
                for(int j =0;j<bmp.Height;j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    if (c.R != 255 | c.G !=255  | c.B!=255)
                    {
                        for (int m = -1; m <= 1; m++)
                            for (int n = -1; n <= 1; n++)
                            {
                                int tx = i + m;
                                int ty = j + n;
                                if (tx < 0 | ty < 0 | tx > bmp.Width - 1 | ty > bmp.Height - 1 | m == 0 | n == 0)
                                    continue;
                                Color c2 = bmp.GetPixel(tx, ty);
                                if (c2.R ==255 && c2.G== 255 && c2.B == 255)
                                {
                                    bmp2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                                }
                            }
                    }
                }
            }
            pictureBox1.Image = bmp2;
        }
    }
}
