using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var joursAvantNoel = new Func<DateTime, int>(date =>
              {
                  var noel = new DateTime(date.Year, 12, 25);
                  if (noel < date)
                  {
                      noel = noel.AddYears(1);
                  }

                  return (noel - date).Days;
              });

            var days = joursAvantNoel(DateTime.Now);
            var dateFinAnnee = new DateTime(DateTime.Now.Year, 12, 31);
            Console.WriteLine($"Le nombre de jours avant noël à partir d'aujourd'hui est de {days}");
            Console.WriteLine($"Le nombre de jours avant noël à partir du 31 décembre {joursAvantNoel(dateFinAnnee)}");

            var actionJoursAvantNoel = new Action<DateTime>(date =>
              {

                  var noel = new DateTime(date.Year, 12, 25);
                  if (noel < date)
                  {
                      noel = noel.AddYears(1);
                  }
                  Console.WriteLine($"Le nombre de jours avant noël à partir du {date.ToShortDateString()} est de {(noel - date).Days} jours");
              });

            actionJoursAvantNoel(DateTime.Now);
            actionJoursAvantNoel(dateFinAnnee);
            Console.ReadKey();
        }
    }
}
