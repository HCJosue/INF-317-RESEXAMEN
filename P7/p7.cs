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
        static void calculoip(Object  numero){
            int n = (int)numero;
            for (int i =0;i<n;i++) {
                if (i % 2 == 0)
                {
                    suma += (1 / (2 * (float)i + 1));
                }
                else {
                    suma -= (1 / (2 * (float)i + 1));
                }
            }
            suma = suma * 4;
        }
        static void calculoip2(Object numero)
        {
            float suma2 = 0;
            int n = (int)numero;
            for (int i = 10000; i < n; i++)
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
        static void calculoip3(Object numero)
        {
            float suma2 = 0;
            int n = (int)numero;
            for (int i = 20000; i < n; i++)
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
            suma = suma + suma2 * 4;
        }
        static void calculoip4(Object numero)
        {
            float suma2 = 0;
            int n = (int)numero;
            for (int i = 30000; i < n; i++)
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
            suma = suma + suma2 * 4;
        }
        static void Main(string[] args)
        {
            Thread p1 = new Thread(calculoip)  { Name = "p1" };
            Thread p2 = new Thread(calculoip2) { Name = "p2" };
            Thread p3 = new Thread(calculoip3) { Name = "p3" };
            Thread p4 = new Thread(calculoip4) { Name= "p4" };
            p1.Start(10000);
            p2.Start(20000);
            p3.Start(30000);
            p4.Start(40000);
            Console.WriteLine("Calculo de numero pi con 4 hilos es: "+suma);
            Console.ReadKey();
        }
    }
    
}
