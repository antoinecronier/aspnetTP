using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            //var adresse1 = new Adresse { Nom = "Rue des Lilas", Numero = 1 };
            //var adresse2 = new Adresse { Nom = "Rue des Monts", Numero = 5 };

            //context.Personnes.FirstOrDefault(p => p.Id == 1).Adresse = adresse1;
            //context.Personnes.FirstOrDefault(p => p.Id == 2).Adresse = adresse2;
            //context.SaveChanges();


            foreach (var personne in context.Personnes)
            {
                Console.WriteLine($"Nom:{personne.Nom}, Prenom:{personne.Prenom}, Adresse:{personne.Adresse}");
            }

            if (!context.Personnes.Any())
            {
                context.Personnes.Add(new Personne { Nom = "PACCIO", Prenom = "Oscar" });
                context.SaveChanges();
                Console.WriteLine("Une personne ajoutée");
            }
            Console.ReadKey();
        }
    }
}
