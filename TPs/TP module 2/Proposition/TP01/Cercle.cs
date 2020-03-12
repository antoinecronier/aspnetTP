using System;

namespace TP01
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire => Math.PI * Rayon * Rayon;

        public override double Perimetre => 2 * Math.PI * Rayon;

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}" + Environment.NewLine + base.ToString();
        }
    }
}