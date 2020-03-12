using System;

namespace DemoGenerique
{
    public class Pate : Nourriture
    {
        public DateTime DatePeremption { get; set; }
        public bool EstPerime()
        {
            return DatePeremption < DateTime.Now;
        }
    }
}