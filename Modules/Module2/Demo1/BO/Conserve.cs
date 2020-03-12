using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Conserve : Aliment
    {
        public override void Conserver()
        {
            StockerDansLePlacard();
        }

        private void StockerDansLePlacard()
        {
            throw new NotImplementedException();
        }
    }
}
