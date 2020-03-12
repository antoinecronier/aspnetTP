using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Personne
    {
        // attributs privés
        private int age;
        private string prenom;

        // Propriété auto-implémentée
        public string Nom { get; set; }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Personne()
        {

        }

        public Personne(string prenom)
        {
            this.prenom = prenom;
        }
    }
}
