using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Refrigerateur<T> where T : Aliment
    {
        private readonly Aliment[] aliments = new Aliment[100];

        public Aliment[] Aliments => aliments;

        public void Stocker(T aliment)
        {
            for (int i = 0; i < aliments.Length; i++)
            {
                if (aliments[i] == null)
                {
                    aliments[i] = aliment;
                    break;
                }
            }
        }

        public void Nettoyer()
        {
            for (int i = 0; i < aliments.Length; i++)
            {
                if (aliments[i] != null)
                {
                    if (aliments[i].EstPerime())
                    {
                        aliments[i] = null;
                    }
                }
            }
        }

    }
}
