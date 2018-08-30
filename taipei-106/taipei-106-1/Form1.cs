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
namespace taipei_106_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] data;
        string filename;
        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "*.txt|*.txt";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                
                 data = File.ReadAllText(ofd.FileName,Encoding.Default).Split('\n');
                filename = ofd.SafeFileName;
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            string html = "";
            html += "<!DOCTYPE html>"+Environment.NewLine;
            html += "<html>" + Environment.NewLine;
            html += "<head><title>顯示各類食材熱量</title>" + Environment.NewLine;
            html += "<style>img {width:100%;height:auto;}</style>" + Environment.NewLine;
            html += "</head>" + Environment.NewLine;
            html += "<body>" + Environment.NewLine;
            html += $"<table cellspacing={txtbox_distance.Text} border={txtbox_width.Text}>" + Environment.NewLine;
            html += "<tr>" + Environment.NewLine;
            int col = int.Parse(txtbox_col.Text);
            for (int i = 0; i< data.Length / col + 1;i++)
            {                                         
                html += "<tr>" + Environment.NewLine;
                string[] temp;
                for(int j = 0; j< col; j++)
                {
                    if(j+i*4 <data.Length)
                    {
                        temp = data[j + i * 4].Split('\t');
                        html += $"<td style=\"background-color:lightgray\">{temp[0]}<br>{temp[1]}</td>" + Environment.NewLine;
                    }
                    else
                    {
                        html += $"<td style=\"background-color:lightgray\"><br></td>" + Environment.NewLine;
                    }
                    
                }                                
                html += "</tr>" + Environment.NewLine;
                html += "<tr>" + Environment.NewLine;                
                for (int j = 0; j < col; j++)
                {
                    if (j + i * 4 < data.Length)
                    {
                        temp = data[j + i * 4].Split('\t');
                        html += $"<td><img src=\"{temp[0]}.jpg\"</td>" + Environment.NewLine;
                    }
                }
                html += "</tr>" + Environment.NewLine;
            }            
            html += "</table>" + Environment.NewLine;
            html += "</body>" + Environment.NewLine;
            html += "</html>";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "HTML Files(*.html)|*.html";
            sfd.FileName = filename + ".html";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, html,Encoding.Default);
            }

        }
    }
}
