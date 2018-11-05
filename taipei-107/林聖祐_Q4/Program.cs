using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 林聖祐_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("記憶體管理程式-最適配置法(Best Fit)");
            Console.Write("請輸入記憶體區塊數(<6)：");
            int[] MemoryBlock = new int[int.Parse(Console.ReadLine())];
            Console.Write("請輸入程序數(<6)：");
            int[] ProgramNeed = new int[int.Parse(Console.ReadLine())];
            Console.WriteLine("請輸入各區塊大小(<10)---");
            
            for (int i = 0; i < MemoryBlock.Length; i++)
            {
                if(i !=0)
                {
                    Console.SetCursorPosition(i * 10, 4);
                }
                Console.Write($"區塊{i + 1}：");
                MemoryBlock[i] = int.Parse(Console.ReadLine());
                
            }
            Console.WriteLine("請輸入各程序所需的大小(<10)---");
            for (int i = 0; i < ProgramNeed.Length; i++)
            {
                if (i != 0)
                {
                    Console.SetCursorPosition(i * 10, 6);
                }
                Console.Write($"程序{i + 1}：");
                ProgramNeed[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("程序編號\t所需大小\t區塊編號\t區塊大小\t剩餘空間\r\n");
            int[] fit = new int[ProgramNeed.Length];
            bool[] book = new bool[MemoryBlock.Length];
            int[] MemoryFor = new int[MemoryBlock.Length];
            for(int i=0;i< ProgramNeed.Length;i++)
            {
                int min = 9999999;
                int index = 9999999;
                for (int j=0;j<MemoryBlock.Length;j++)
                    if(MemoryBlock[j] >= ProgramNeed[i] && !book[j] )
                    {
                        if (min > MemoryBlock[j])
                        {
                            min = MemoryBlock[j];
                            index = j;
                        }
                    }
                if (min == 9999999)
                    Console.WriteLine($"{i + 1}\t\t{ProgramNeed[i]}\t\t未分配記憶體區塊");
                else
                {
                    book[index] = true;
                    MemoryFor[index] = i + 1;
                    Console.WriteLine($"{i + 1}\t\t{ProgramNeed[i]}\t\t{index + 1}\t\t{MemoryBlock[index]}\t\t{ MemoryBlock[index] - ProgramNeed[i] }");
                }
               
            }
            Console.Write("\r\n\r\n\r\n配置程序前\r\n\r\n\t\t");
            for(int i=0;i<MemoryBlock.Length;i++)
            {
                string temp = "";
                for (int j = 1; j <= MemoryBlock[i]; j++)
                    temp+=$"{j}-";
                Console.Write(temp.PadRight(MemoryBlock[i] * 2 + 4,' '));
            }
            Console.Write("\r\n\r\n程序配置後\t");
            for(int i =0;i<MemoryFor.Length;i++)
            {
                if (MemoryFor[i] != 0)
                    Console.Write(($"P{MemoryFor[i]}" + "".PadRight(ProgramNeed[MemoryFor[i]-1] * 2 - 2, '=')).PadRight(MemoryBlock[i] * 2 + 4, ' '));
                else
                    Console.Write("".PadRight(MemoryBlock[i] * 2 + 4, ' '));
            }
            Console.Read();
        }
    }
}
