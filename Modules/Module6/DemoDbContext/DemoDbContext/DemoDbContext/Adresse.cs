using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbContext
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Numero { get; set; }

        public override string ToString()
        {
            return $"{Numero} {Nom}";
        }
    }
}
