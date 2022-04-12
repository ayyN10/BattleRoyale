using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Tueur_Dieux : personnages
    {
        private string nom;
        private int avantage = 50;

        public Tueur_Dieux(int desPointVie, int uneForce, string unNomPerso, string uneArme, int desDegats, string unTypePerso) : base(desPointVie, uneForce, unNomPerso, uneArme, desDegats, unTypePerso)
        {
            nom = unTypePerso;
        }
        public override void Coup(personnages ennemi)
        {
            if (ennemi.TypePerso == "Dieux")
            {
                Force = Force + avantage;
                Console.WriteLine(Force);
                ennemi.PointVie = ennemi.PointVie - (this.Force + Degat);
                Console.WriteLine(PointVie);
                Force = Force - avantage;
                Console.WriteLine(Force);
            }
            else if (ennemi.Nom == "Demon")
            {
                Force = Force - avantage;
                ennemi.PointVie = ennemi.PointVie - (this.Force + Degat);
                Force = Force + avantage;
            }
        }
    }
}
