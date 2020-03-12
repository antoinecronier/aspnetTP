using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(100);

            //on affiche le nombre d'éléments actuellement dans la liste
            Console.WriteLine(list.Count);

            list.Add(10);
            list.Add(5);
            list.Add(-200);


            //on affiche le nombre d'éléments actuellement dans la liste
            Console.WriteLine(list.Count);

            Console.WriteLine(list.Capacity);

            var result = list.Contains(3);
            var result2 = list.Contains(5);

            Console.WriteLine($"La liste contient le chiffre 3 ? {result}, le chiffre 5 ? {result2}");

            list.Remove(-200);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
