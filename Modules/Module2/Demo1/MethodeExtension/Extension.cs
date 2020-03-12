using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodeExtension
{
    public static class Extension
    {
        public static bool EstPair(this int entier)
        {
            return entier % 2 == 0;
        }

        public static string PremiereLettreMaj(this string chaine)
        {
            return Char.ToUpper(chaine[0]).ToString() + chaine.ToLower().Substring(1);
        }

    }
}
