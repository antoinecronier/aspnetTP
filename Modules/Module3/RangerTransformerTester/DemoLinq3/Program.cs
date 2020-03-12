using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq3
{
    public class Rue
    {
        public string Nom { get; set; }
        public int Numero { get; set; }
    }

    public class Appartement
    {
        public int Numero { get; set; }
        public List<Piece> Pieces { get; set; }
    }

    public class Piece
    {
        public string TypePiece { get; set; }
        public int Surface { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listeDeRues = new List<Rue>
            {
                new Rue{Nom="Rue des lilas",Numero=1},
                new Rue{Nom="Rue des monts",Numero=3},
                new Rue{Nom="Rue des lilas",Numero=50},
                new Rue{Nom="Rue des lilas",Numero=110},
                new Rue{Nom="Rue des monts",Numero=24},
                new Rue{Nom="Rue des asperges",Numero=5},
                new Rue{Nom="Rue des xylophones",Numero=48},
            };

            var orderedByNames = listeDeRues.OrderBy(r => r.Nom);
            Console.WriteLine("Liste des rues triée sur le nom");
            foreach (var rue in orderedByNames)
            {
                Console.WriteLine($"Nom={rue.Nom}, numéro={rue.Numero}");
            }

            var orderedByNumberDescending = listeDeRues.OrderByDescending(r => r.Numero);

            Console.WriteLine();
            Console.WriteLine("Liste des rues triée sur le numéro en décroissant");
            foreach (var rue in orderedByNumberDescending)
            {
                Console.WriteLine($"Nom={rue.Nom}, numéro={rue.Numero}");
            }

            var orderedStreet = listeDeRues.OrderBy(r => r.Nom).ThenBy(r => r.Numero);
            Console.WriteLine();
            Console.WriteLine("Liste des rues triée sur le nom, puis sur le numéro");
            foreach (var rue in orderedStreet)
            {
                Console.WriteLine($"Nom={rue.Nom}, numéro={rue.Numero}");
            }

            Console.WriteLine();
            if (listeDeRues.All(r => r.Numero < 200))
            {
                Console.WriteLine("Les numéros des rues sont tous inférieurs à 200");
            }

            Console.WriteLine();
            if (listeDeRues.Any(r => r.Numero < 100 && r.Numero > 50))
            {
                Console.WriteLine("Il existe des rues entre 50 et 100");
            }

            var ruesUniques = listeDeRues.Select(r => r.Nom).Distinct().OrderBy(s => s);
            Console.WriteLine();
            Console.WriteLine("Les noms de rues uniques sont:");
            foreach (var nom in ruesUniques)
            {
                Console.WriteLine(nom);
            }

            var appartements = new List<Appartement>
            {
                new Appartement
                {
                    Numero=1,
                    Pieces=new List<Piece>
                    {
                        new Piece{ Surface=5,TypePiece="Cuisine"},
                        new Piece { Surface=15,TypePiece="Salon"},
                        new Piece { Surface=10,TypePiece="Chambre"},
                    }
                },
                 new Appartement
                {
                    Numero=2,
                    Pieces=new List<Piece>
                    {
                        new Piece{ Surface=4,TypePiece="Cuisine"},
                        new Piece { Surface=21,TypePiece="Salon"},
                        new Piece { Surface=9,TypePiece="Chambre"},
                    }
                },
                 new Appartement
                {
                    Numero=3,
                    Pieces=new List<Piece>
                    {
                        new Piece{ Surface=6,TypePiece="Cuisine"},
                        new Piece { Surface=19,TypePiece="Salon"},
                        new Piece { Surface=8,TypePiece="Chambre"},
                    }
                },
                 new Appartement
                {
                    Numero=4,
                    Pieces=new List<Piece>
                    {
                        new Piece{ Surface=8,TypePiece="Cuisine"},
                        new Piece { Surface=30,TypePiece="Salon"},
                        new Piece { Surface=12,TypePiece="Chambre"},
                    }
                }
            };

            var pieces = appartements.SelectMany(a => a.Pieces);
            Console.WriteLine();
            Console.WriteLine("Voici la liste de toutes les pieces des appartements");
            foreach (var piece in pieces)
            {
                Console.WriteLine($"Pièce de type {piece.TypePiece} et de surface {piece.Surface}");
            }


            Console.ReadKey();
        }
    }
}
