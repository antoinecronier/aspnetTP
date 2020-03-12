using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq2
{
    class Program
    {
        static void Main(string[] args)
        {
            var personnes = new List<Personne>
            {
                new Personne{Age=32,Prenom="Marc"},
                new Personne{Age=33,Prenom="Jean"},
                new Personne{Age=28,Prenom="Mélanie"},
                new Personne{Age=32,Prenom="Simon"},
                new Personne{Age=33,Prenom="Hélène"},
                new Personne{Age=28,Prenom="Francis"}
            };

            foreach (var personne in personnes)
            {
                Console.WriteLine($"Prenom={personne.Prenom}, Age={personne.Age}");
            }
            Console.WriteLine();

            Console.WriteLine("Les personnes ayant moins de trente ans");
            var moinsDeTrente = personnes.Where(p => p.Age < 30);
            foreach (var personne in moinsDeTrente)
            {
                Console.WriteLine($"Prenom={personne.Prenom}, Age={personne.Age}");
            }

            var agesUnique = personnes.Select(p => p.Age).Distinct();
            Console.WriteLine();
            Console.WriteLine("Ages uniques:");
            foreach (var age in agesUnique)
            {
                Console.WriteLine(age);
            }

            var troisPremiers = personnes.Take(3);
            Console.WriteLine();
            Console.WriteLine("Les trois premières personnes");
            foreach (var personne in troisPremiers)
            {
                Console.WriteLine($"Prenom={personne.Prenom}, Age={personne.Age}");
            }
            Console.ReadKey();
        }
    }

    public class Personne
    {
        public int Age { get; set; }
        public string Prenom { get; set; }
    }
}
