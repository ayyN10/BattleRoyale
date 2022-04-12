using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Dieux : personnages
    {
        private int avantage = 50;

        public Dieux (int desPointVie, int uneForce, string unNomPerso, string uneArme, int desDegats, string unTypePerso) : base(desPointVie, uneForce, unNomPerso, uneArme, desDegats, unTypePerso)
        {
        }

        public override void Coup(personnages ennemi)
        {
            Console.WriteLine("WESHHHHHHHH");
            if(ennemi.TypePerso == "Demon")
            {
                Force = Force + avantage;
                Console.WriteLine(Force);
                ennemi.PointVie = ennemi.PointVie - (this.Force + Degat);
                Console.WriteLine(PointVie);
                Force = Force - avantage;
                Console.WriteLine(Force);
            }
            else if (ennemi.TypePerso == "Tueur-Dieux")
            {
                Force = Force - avantage;
                Console.WriteLine(Force);
                ennemi.PointVie = ennemi.PointVie - (this.Force + Degat);
                Console.WriteLine(PointVie);
                Force = Force + avantage;
                Console.WriteLine(Force);
            }
        }
    }
}
