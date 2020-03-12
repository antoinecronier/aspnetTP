using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var nombres = new List<int> { 1, 2, 3, 4, 5, 5, 6 };
                var listeVide = new List<int>();

                //var premier = nombres.First();
                //Console.WriteLine($"First sur nombres a retourné {premier}");

                //premier = listeVide.First();
                //Console.WriteLine($"First sur listeVide a retourné {premier}");

                var premierFirstOrDefault = nombres.FirstOrDefault();
                Console.WriteLine($"FirstOrDefault sur nombres a retourné {premierFirstOrDefault}");

                premierFirstOrDefault = listeVide.FirstOrDefault();
                Console.WriteLine($"FirstOrDefault sur listeVide a retourné {premierFirstOrDefault}");

                //var cinq = nombres.Single(n => n == 5);
                //Console.WriteLine(cinq);

                var trois = nombres.Single(n => n == 3);
                Console.WriteLine(trois);

                var zero = listeVide.SingleOrDefault();
                Console.WriteLine(zero);

                var six = nombres.Last();
                Console.WriteLine(six);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
