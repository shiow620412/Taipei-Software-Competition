using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_99_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Status
        {
            public int[] status;
            public int father;
            public int index;
            public Status(int[] status,int father,int index)
            {
                this.status = status;
                this.father = father;
                this.index = index;
                
            }
            public Status()
            {

            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Status> s = new List<Status>();
            s.Add(new Status(Array.ConvertAll(textBox1.Text.Split(','), int.Parse), 0,0));
            Status ans=new Status(), temp;
            Queue<Status> q = new Queue<Status>();
            int[] i;
            q.Enqueue(s[0]);
            book.Add(s[0].status);
            bool getAns = false;
            while( q.Count>0 &&!getAns)
            {
                temp = q.Dequeue();
                i = temp.status;
                if(i[3]==3 && i[4] == 3 && i[5] == 1)
                {
                    ans = temp;
                    getAns = true;
                    break;
                }
                if (temp.status[2]==1)
                {                   
                    if (check(new int[] { i[0]-1, i[1]-1, i[2]-1,
                                          i[3]+1, i[4]+1, i[5]+1 }))
                    {
                        s.Add(new Status(new int[] { i[0] - 1, i[1] - 1, i[2] - 1,
                                                     i[3] + 1, i[4] + 1, i[5] + 1 }, temp.index, s.Count));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0]-1, i[1], i[2]-1,
                                          i[3]+1, i[4], i[5]+1 }))
                    {
                        s.Add(new Status(new int[] { i[0] - 1, i[1] , i[2] - 1,
                                                     i[3] + 1, i[4] , i[5] + 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0], i[1]-1, i[2]-1,
                                          i[3], i[4]+1, i[5]+1 }))
                    {
                        s.Add(new Status(new int[] { i[0] , i[1] - 1, i[2] - 1,
                                                     i[3] , i[4] + 1, i[5] + 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0]-2, i[1], i[2]-1,
                                          i[3]+2, i[4], i[5]+1 }))
                    {
                         s.Add(new Status(new int[] { i[0] - 2, i[1] , i[2] - 1,
                                                      i[3] + 2, i[4] , i[5] + 1 }, temp.index, s.Count));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0], i[1]-2, i[2]-1,
                                          i[3], i[4]+2, i[5]+1 }))
                    {
                        s.Add(new Status(new int[] { i[0] , i[1] - 2, i[2] - 1,
                                                     i[3] , i[4] + 2, i[5] + 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                }
                else
                {
                    if (check(new int[] { i[0]+1, i[1]+1, i[2]+1,
                                          i[3]-1, i[4]-1, i[5]-1 }))
                    {
                        s.Add(new Status(new int[] { i[0] + 1, i[1] + 1, i[2] + 1,
                                                     i[3] - 1, i[4] - 1, i[5] - 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0]+1, i[1], i[2]+1,
                                          i[3]-1, i[4], i[5]-1 }))
                    {
                        s.Add(new Status(new int[] { i[0] + 1, i[1] , i[2] + 1,
                                                     i[3] - 1, i[4] , i[5] - 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0], i[1]+1, i[2]+1,
                                          i[3], i[4]-1, i[5]-1 }))
                    {
                        s.Add(new Status(new int[] { i[0] , i[1] + 1, i[2] + 1,
                                                     i[3] , i[4] - 1, i[5] - 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0]+2, i[1], i[2]+1,
                                          i[3]-2, i[4], i[5]-1 }))
                    {
                        s.Add(new Status(new int[] { i[0] + 2, i[1] , i[2] + 1,
                                                     i[3] - 2, i[4] , i[5] - 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                    if (check(new int[] { i[0], i[1]+2, i[2]+1,
                                          i[3], i[4]-2, i[5]-1 }))
                    {
                        s.Add(new Status(new int[] { i[0] , i[1] + 2, i[2] + 1,
                                                     i[3] , i[4] - 2, i[5] - 1 }, temp.index, s.Count ));
                        q.Enqueue(s.Last());
                    }
                }
            }
            int[] tempInt = new int[6];
            List<string> output = new List<string>();
            int a = 0, b = 0;
            q.Clear();
            q.Enqueue(ans);
            while(q.Count>0)
            {
                temp = q.Dequeue();
                tempInt = temp.status;                
                //右岸至左岸                
                if(tempInt[2] ==1)
                {
                    a = Math.Abs(tempInt[3] - s[temp.father].status[3]);
                    b = Math.Abs(tempInt[4] - s[temp.father].status[4]);
                    output.Add($"右岸->左岸 傳教士過去 {a} ,野人過去 {b}        左岸(野{tempInt[0]}傳{tempInt[1]}船{tempInt[2]})        右岸(野{tempInt[3]}傳{tempInt[4]}船{tempInt[5]}) \r\n");
                }
                else
                {
                    a = Math.Abs(tempInt[0] - s[temp.father].status[0]);
                    b = Math.Abs(tempInt[1] - s[temp.father].status[1]);
                    output.Add($"左岸->右岸 傳教士過去 {a} ,野人過去 {b}        左岸(野{tempInt[0]}傳{tempInt[1]}船{tempInt[2]})        右岸(野{tempInt[3]}傳{tempInt[4]}船{tempInt[5]}) \r\n");
                }
                if (temp.father != 0)
                    q.Enqueue(s[temp.father]);
            }          
            output.Reverse();
            textBox2.Clear();
            foreach(var str in output)
            {
                textBox2.Text += str;
            }
            

            

               
        }
        List<int[]> book = new List<int[]>();
        bool check(int[] i)
        {
            bool notRepeat = true;
            book.ForEach(x =>
            {
                if (x == i)
                    notRepeat= false;
            });
            if ((i[0] > i[1] && i[1]>0 )| (i[3] > i[4] && i[4]>0)|i[0]<0 | i[1] < 0 | i[2] < 0 | i[3] < 0 | i[4] < 0 | i[5] < 0)
                notRepeat = false;
            if (notRepeat)
                book.Add(i);
            return notRepeat;
        }
    }
}
