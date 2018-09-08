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
namespace taipei_100_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        float[] scale = new float[] {
            0.06334372f,
            0.04596527f,
            0.053497944f,
            0.0470347665f,
            0.06004141f,
            0.04918033f,
            0.05785124f,
            0.03959391f,
            0.07225131f,
            0.05894519f
        };
        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory()+"\number";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

                Bitmap bmp = new Bitmap(pictureBox1.Image);
                float black = 0, white = 0;
                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        if (c.R == c.G && c.G == c.B && c.B == 255)
                            white++;
                        else
                            black++;
                    }
                }
                label1.Text = "";
                //double val = (black / white *100000000/100000000)%1;
                float val = black / white ;
                for (int i = 0; i < scale.Length; i++)
                {
                    if (scale[i] == val)
                    {
                        label1.Text = i.ToString();
                    }
                }
                if (label1.Text.Equals(""))
                    label1.Text = "無法辨識";
                //File.AppendAllText(@".\比例.txt", $"{ofd.SafeFileName} 黑={black} 白={white} 黑除白={val}" + Environment.NewLine);
            }
           
        }
    }
}
