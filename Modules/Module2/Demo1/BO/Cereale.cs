using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Cereale : Aliment, Emballage
    {
        public override void Conserver()
        {
            throw new NotImplementedException();
        }

        public void Fermer()
        {
            throw new NotImplementedException();
        }

        public void Ouvrir()
        {
            throw new NotImplementedException();
        }
    }
}
