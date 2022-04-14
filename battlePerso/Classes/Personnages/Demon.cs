using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Demon : Personnage
    {
        private string nom;
        private int avantage = 50;

        public Demon(int desPointVie, int uneForce, string unNomPerso, string uneArme, int desDegats ) : base(desPointVie, uneForce, unNomPerso, uneArme, desDegats)
        {
         
        }

        public override void Coup(Personnage ennemi)
        {

            int dégatsRecus = 0;

            if (ennemi is Tueur_Dieux)
            {
                Console.WriteLine(this.Nom + " bénéficie d'un avantage de : " + avantage);
                dégatsRecus = (Force + Degat + avantage);
                ennemi.PointVie -= dégatsRecus;

            }
            else if (ennemi is Dieux)
            {
                Console.WriteLine(this.Nom + " bénéficie d'une faiblesse de : " + avantage);
                dégatsRecus = (Force + Degat) - avantage;
                ennemi.PointVie -= dégatsRecus;
            }

            Console.WriteLine(this.Nom + " à infligé " + dégatsRecus + " dégats à " + ennemi.Nom + " et il à maintenant " + ennemi.PointVie + " points de vie");
            if (ennemi.PointVie <= 0)
            {
                Console.WriteLine(ennemi.Nom + " est mort !");
                ennemi.mort = true;
            }

        }
    }
}
