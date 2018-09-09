using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taipei_99_4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Node
        {
            public int[] Status;
            public Node Father;
            public Node(int[] Status,Node Father)
            {
                this.Status = Status;
                this.Father = Father;
            }
            public bool IsCorrect()
            {
                for (int i = 0; i < Status.Length; i++)
                    if (Status[i] < 0)
                        return false;
                if ((Status[0] > Status[1] && Status[1] > 0) | (Status[3] > Status[4] && Status[4] > 0))
                    return false;
                return true;
            }
            public bool boatInLeft() => Status[2] == 1;
            public Node MoveLtoR(int m , int p)
            {
                int[] arr = (int[])Status.Clone();
                arr[0] -= m;
                arr[1] -= p;
                arr[2] -= 1;
                arr[3] += m;
                arr[4] += p;
                arr[5] += 1;
                Node next = new Node(arr, this);
                if (next.IsCorrect())
                    return next;
                else
                    return null;

            }
            public Node MoveRtoL(int m, int p)
            {
                int[] arr = (int[])Status.Clone();
                arr[0] += m;
                arr[1] += p;
                arr[2] += 1;
                arr[3] -= m;
                arr[4] -= p;
                arr[5] -= 1;
                Node next = new Node(arr, this);
                if (next.IsCorrect())
                    return next;
                else
                    return null;

            }
            public string Sequence()
            {
                return string.Join("", Array.ConvertAll(Status, s=>s.ToString() ));
            }
            public override string ToString()
            {
                string str = "";
                if (boatInLeft())
                {
                    str = $"右岸->左岸 傳教士過去 {Father.Status[4]-Status[4]} , 野人過去 {Father.Status[3] - Status[3]}";
                }
                else
                {
                    str = $"左岸->右岸 傳教士過去 {Father.Status[1] - Status[1]} , 野人過去 {Father.Status[0] - Status[0]}";
                }
                return $"{str}\t 左岸( 野{Status[0]} 傳{Status[1]} 船{Status[2]} ) 右岸( 野{Status[3]} 傳{Status[4]} 船{Status[5]} )";
            }
        }
        List<Node> getNext(Node n)
        {
            List<Node> ln = new List<Node>();
            if (n.boatInLeft())
            {
                ln.Add(n.MoveLtoR(1, 1));
                ln.Add(n.MoveLtoR(0, 1));
                ln.Add(n.MoveLtoR(0, 2));
                ln.Add(n.MoveLtoR(1, 0));
                ln.Add(n.MoveLtoR(2, 0));
            }
            else
            {
                ln.Add(n.MoveRtoL(1, 1));
                ln.Add(n.MoveRtoL(0, 1));
                ln.Add(n.MoveRtoL(0, 2));
                ln.Add(n.MoveRtoL(1, 0));
                ln.Add(n.MoveRtoL(2, 0));
            }
            return ln;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int[] input = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);
            Node start = new Node(input, null);            
            if (!start.IsCorrect())
            {
                MessageBox.Show("違反題意");
                return;
            }
            Queue<Node> q = new Queue<Node>();
            SortedList<string, bool> book = new SortedList<string, bool>();
            book.Add(start.Sequence(), true);
            Node end = new Node(new int[] { 0, 0, 0, 3, 3, 1 }, null);
            string endSequence = end.Sequence();
            q.Enqueue(start);
            while (q.Count>0)
            {
                Node now = q.Dequeue();
                if(now.Sequence() == endSequence)
                {
                    Stack<Node> output = new Stack<Node>();
                    while(now.Father!=null)
                    {
                        output.Push(now);
                        now = now.Father;
                    }
                    while (output.Count > 0)
                        listBox1.Items.Add(output.Pop().ToString());
                    MessageBox.Show("成功過河");
                    return;
                }
                List<Node> next = getNext(now);
                foreach(var n in next)
                {
                    if (n==null) continue;
                    if (!book.Keys.Contains(n.Sequence()))
                    {
                        q.Enqueue(n);
                        book.Add(n.Sequence(), true);
                    }
                }
            }

        }
    }
}
