using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;//libreria

namespace ConsoleApplication6
{
    class Program
    {
        public static float suma=0;
        static void calculopi(Object numero)
        {
            float suma2 = 0;
            int n = (int)numero;
            for (int i = 10000*(n-1); i < 10000*(n); i++)
            {
                if (i % 2 == 0)
                {
                    suma2 += (1 / (2 * (float)i + 1));
                }
                else
                {
                    suma2 -= (1 / (2 * (float)i + 1));
                }
            }
            suma = suma+suma2 * 4;
        }
        static void Main(string[] args)
        {
            Thread p1 = new Thread(calculopi)  { Name = "p1" };
            Thread p2 = new Thread(calculopi) { Name = "p2" };
            Thread p3 = new Thread(calculopi) { Name = "p3" };
            Thread p4 = new Thread(calculopi) { Name= "p4" };
            p1.Start(1);
            p2.Start(2);
            p3.Start(3);
            p4.Start(4);
            Console.WriteLine("Calculo de numero pi con 4 hilos es: "+suma);
            Console.ReadKey();
        }
    }
    
}
