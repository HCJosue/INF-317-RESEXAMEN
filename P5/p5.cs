using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ConsoleApplication7
{
    class Program
    {
        public static String guardar = "";
        static void serieP(object numero)
        {
            String serie = "";
            int n = (int)numero;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    serie = serie + (Math.Pow((i / 2 + 1), 2) + 1) + ",";
                }
                else
                {
                    serie = serie + (i + 1) + ",";
                }
            }
            guardar = guardar+serie;

        }
        static void serieP2(object numero)
        {
            int n = (int)numero;
            String serie = "";
            for (int i = 5000; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    serie =serie + (Math.Pow((i / 2 + 1), 2) + 1) + ",";
                }
                else
                {
                    serie = serie + (i + 1) + ",";
                }
            }
            guardar = guardar + serie;
        }
        static void Main(string[] args)
        {
            Thread p1 = new Thread(serieP)  { Name = "p1" };
            Thread p2 = new Thread(serieP2) { Name = "p2" };
            p1.Start(5000);
            p2.Start(10000);
            p1.Join();
            p2.Join();
            Console.WriteLine(guardar);
            Console.ReadKey();
        }
    }
}
