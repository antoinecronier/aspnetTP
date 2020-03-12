using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    public class Chat : Animal<Pate>
    {
        public bool SeNourrir(Pate aliment)
        {
            if (aliment.EstPerime())
            {
                return false;
            }
            Console.WriteLine("Le chat mange le delicieux paté");
            return true;
        }
    }
}
