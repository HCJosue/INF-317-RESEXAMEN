using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;//libreria

namespace ConsoleApplication6
{
    class Program
    {
        static double pi1=0;
        static double pi2 = 0;
        static int n=50000-4;
        static int i=0;
        static void calculopi(object state)
        {
            int lugar;
            while ((lugar=Interlocked.Increment(ref i)-1)<n) {

                pi1 += (double)(1 / (double)((lugar + 1) * (lugar + 1)));
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(calculopi);
            }
            while (i < n)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Calculo de numero pi con 4 hilos es: "+Math.Sqrt((pi1)*6));
            Console.ReadKey();
        }
    }
    
}
