using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodeExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            Console.WriteLine($"Est ce que {a} est pair ?{a.EstPair()}");


            var chaine = "iL FAIT beAu aUjourd'hUI";
            Console.WriteLine(chaine.PremiereLettreMaj());
            Console.ReadKey();
        }
    }
}
