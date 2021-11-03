using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21App1
{
    class Program
    {
        //1.Имеется пустой участок земли(двумерный массив) и план сада, который необходимо реализовать.Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
        //    Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
        //    Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
        //    Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше.Садовники должны работать параллельно. 
        //    Создать многопоточное приложение, моделирующее работу садовников.
        static int[,] garden;
        static int a;
        static int b;
        static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Gardener2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Main(string[] args)
        {
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            garden = new int[a, b];

            Thread plot1 = new Thread(Gardener1);
            Thread plot2 = new Thread(Gardener2);

            plot1.Start();
            plot2.Start();
            plot1.Join();
            plot2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
