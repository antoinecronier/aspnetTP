using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            //Afficher la liste des prenoms des auteurs dont le nom commence par "G"
            var prenomsG = ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine("Afficher la liste des prenoms des auteurs dont le nom commence par \"G\"");
            foreach (var prenom in prenomsG)
            {
                Console.WriteLine(prenom);
            }
            Console.WriteLine();

            //Quel auteur a écrit le plus de livres
            var auteurPlusDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            Console.WriteLine("Quel auteur a écrit le plus de livres");
            Console.WriteLine($"{auteurPlusDeLivres.Prenom} {auteurPlusDeLivres.Nom}");
            Console.WriteLine();

            //Quel est le nombre moyen de pages par livre par auteur
            var livresparAuteur = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine("Quel est le nombre moyen de pages par livre par auteur");
            foreach (var item in livresparAuteur)
            {
                Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} moyennes des pages={item.Average(l => l.NbPages)}");
            }
            Console.WriteLine();

            //Quel est le titre du livre avec le plus de pages
            var livreMaxPage = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine("Quel est le titre du livre avec le plus de pages");
            Console.WriteLine(livreMaxPage.Titre);
            Console.WriteLine();

            //Combien ont gagné les auteurs en moyenne
            var moyenne = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine("Combien ont gagné les auteurs en moyenne");
            Console.WriteLine(moyenne);
            Console.WriteLine();

            //Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("Afficher les auteurs et la liste de leurs livres");

            var livresparAuteur2 = ListeLivres.GroupBy(l => l.Auteur);
            foreach (var livres in livresparAuteur2)
            {
                Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom} ");
                foreach (var livre in livres)
                {
                    Console.WriteLine($" - {livre.Titre}");
                }
            }
            Console.WriteLine();

            //  Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine(" Afficher les titres de tous les livres triés par ordre alphabétique");
            ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            // Afficher la liste des livres dont le nombre de page est > à la moyenne
            Console.WriteLine("- Afficher la liste des livres dont le nombre de page est > à la moyenne");
            var moyennePages = ListeLivres.Average(l => l.NbPages);
            var livresPagesSupMoy = ListeLivres.Where(l => l.NbPages > moyennePages);
            foreach (var livre in livresPagesSupMoy)
            {
                Console.WriteLine($" - {livre.Titre}");
            }
            Console.WriteLine();

            //- Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("- Afficher l'auteur ayant écrit le moins de livres");
            //   var auteurMoinsDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderBy(g => g.Count()).FirstOrDefault().Key;

            var auteurMoinsDeLivres = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
            Console.WriteLine($"{auteurMoinsDeLivres.Prenom} {auteurMoinsDeLivres.Nom}");
            Console.ReadKey();
        }

        private static readonly List<Auteur> ListeAuteurs = new List<Auteur>();
        private static readonly List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

    }
}
