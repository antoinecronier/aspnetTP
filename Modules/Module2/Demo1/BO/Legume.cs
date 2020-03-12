using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Legume : Aliment
    {
        public override void Conserver()
        {
            StockerDansLeRefrigerateur();
        }

        private void StockerDansLeRefrigerateur()
        {
            throw new NotImplementedException();
        }
    }
}
