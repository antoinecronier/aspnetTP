using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    public static class Zoo
    {
        public static bool NourrirAnimal<A, N>(A animal, N aliment) where N : Nourriture where A : Animal<N>
        {
            return animal.SeNourrir(aliment);
        }
    }
}
