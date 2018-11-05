using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 林聖祐_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入 N 人數：");
            int N = int.Parse(Console.ReadLine());
            Console.Write("請輸入 M 報數：");
            int M = int.Parse(Console.ReadLine());
            List<int> people = new List<int>();
            for (int i = 0; i < N; i++) people.Add(i+1);
            Console.Write("淘汰順序：");
            int index = -1;
        
            while (people.Count != 1)
            {
                
                int count = M;
                while(count > 0)
                {
                 
                    if (index + 1 == people.Count)
                        index = 0;
                    else
                        index++;
                    while(people[index]==999)
                    {
                        if (index + 1 == people.Count)
                            index = 0;
                        else
                            index++;
                    }
                   
                    count--;
                }
                Console.Write($"{people[index]} ");

                people[index] = 999;
                if (people.Count(x => x == 999) == N - 1)
                    break;     
            }
            Console.Write("\r\n");
            Console.WriteLine($"最後贏家：{people.Min()}");
            Console.Read();
        }
    }
}
