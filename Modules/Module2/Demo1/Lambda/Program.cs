using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var joursAvantNoel = new Func<DateTime, int>(date =>
              {
                  var noel = new DateTime(date.Year, 12, 25);
                  return (noel - date).Days;
              });

            Console.WriteLine($"Nombres de jours avant noël : {joursAvantNoel(DateTime.Now)}");


            var actionJoursAvantNoel = new Action<DateTime>(date =>
            {
                var noel = new DateTime(date.Year, 12, 25);
                var days = (noel - date).Days;
                Console.WriteLine($"Nombres de jours avant noël : {days}");
            });
            actionJoursAvantNoel(new DateTime(2018, 1, 1));
            Console.ReadKey();
        }
    }
}
