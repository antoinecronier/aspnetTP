using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    class Program
    {
        static void Main(string[] args)
        {
            Fourmi fourmi = new Fourmi();
            Fruit fruit = new Fruit { DateCueilette = DateTime.Now.AddDays(-5) };
            Zoo.NourrirAnimal(fourmi, fruit);

            Chat chat = new Chat();
            Pate pate = new Pate { DatePeremption = DateTime.Now.AddYears(1) };
            Zoo.NourrirAnimal(chat, pate);

            Console.ReadKey();
        }
    }
}
