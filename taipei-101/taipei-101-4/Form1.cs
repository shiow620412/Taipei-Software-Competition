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
namespace taipei_101_4
{
    public partial class Form1 : Form
    {
        WebBrowser web = new WebBrowser();
        public Form1()
        {
            InitializeComponent();
            web.DocumentText = @"<script>function calc(e){return eval(e);} </script>";
            List<Button> btn = Controls.OfType<Button>().ToList();
            btn.ForEach(x =>
            {
                if (x.Text != "執行")
                    x.Click += (s, Event) =>
                    {
                        textBox1.Text += ((Button)s).Text;
                    };
            });
        }

        private void button18_Click(object sender, EventArgs e)
        {            
            var obj = web.Document.InvokeScript("calc",new object[] { textBox1.Text});
            if (obj != null)            
                File.WriteAllText(@".\b.txt", $"{textBox1.Text} = {obj}");            
            else
                MessageBox.Show("輸出錯誤");

        }

    }
}
