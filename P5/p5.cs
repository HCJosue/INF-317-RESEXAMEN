using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApplication12
{
    class Program
    {
        static int n = 10000;
        static int[] guardar = new int[n+1];
        static object lockObject = new object();
        static int i = 0;
        static void serieP(object state)
        {
            int lugar;
            while ((lugar = (Interlocked.Increment(ref i)) - 1) < n)
            {
                if (lugar % 2 == 0)
                {
                    guardar[lugar] = (int)Math.Pow(lugar / 2 + 1, 2) + 1;
                }
                else if(lugar%2==1)
                {
                    guardar[lugar] = (lugar + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            for (int j = 0; j < 4; j++)
            {
                ThreadPool.QueueUserWorkItem(serieP);
            }
            Thread.Sleep(1000);
            for (int j = 0; j < n; j++)
            {
                Console.Write(guardar[j] + ",");
            }
            Console.ReadKey();
        }
    }
}
