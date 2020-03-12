using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialisation();
            using (var context = new Context())
            {
                var parent = context.Personnes.FirstOrDefault();

                // Explicit Loading
                context.Entry(parent).Collection(p => p.Enfants).Load();
            }

            using (var context = new Context())
            {
                // Eager loading
                var parent = context.Personnes.Include(p => p.Enfants.Select(e => e.Enfants)).FirstOrDefault();
            }

        }

        static void Initialisation()
        {
            using (var context = new Context())
            {
                var parent = new Personne { Nom = "Taplane", Prenom = "Adèle" };
                var enfant1 = new Personne { Nom = "Khan", Prenom = "Jerry" };
                var enfant2 = new Personne { Nom = "Aire", Prenom = "Axel" };
                var petitEnfant1 = new Personne { Nom = "Clette", Prenom = "Lara" };
                var petitEnfant2 = new Personne { Nom = "Joute", Prenom = "Sarah" };
                var petitEnfant3 = new Personne { Nom = "Atomie", Prenom = "Anne" };
                var petitEnfant4 = new Personne { Nom = "Ibou", Prenom = "oscar" };

                parent.Enfants.Add(enfant1);
                parent.Enfants.Add(enfant2);

                enfant1.Enfants.Add(petitEnfant1);
                enfant1.Enfants.Add(petitEnfant2);
                enfant2.Enfants.Add(petitEnfant3);
                enfant2.Enfants.Add(petitEnfant4);

                context.Personnes.Add(parent);
                context.SaveChanges();
            }
        }
    }
}
