using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public abstract class Aliment
    {
        public DateTime DatePeremption { get; set; }

        public bool EstPerime()
        {
            return DateTime.Now > DatePeremption;
        }

        public abstract void Conserver();

    }
}
