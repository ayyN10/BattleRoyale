using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Dieux : Personnage
    {
        private int avantage;
        private int désavantage;

        public Dieux (int PointsDeVie, int Force, string Nom, string Arme, int Dégats, int Avantage, int Désavantage) : base(PointsDeVie, Force, Nom, Arme, Dégats)
        {
            this.avantage = Avantage;
            this.désavantage = Désavantage;
        }

        public override void Coup(Personnage ennemi)
        {
            int dégatsRecus = 0;

            if (ennemi is Demon)
            {
                Console.WriteLine(this.Nom + " bénéficie d'un avantage de : " + avantage);
                dégatsRecus = (Force + Degats + avantage);
                ennemi.PointDeVie -= dégatsRecus;
                
            }
            else if (ennemi is Tueur_Dieux)
            {
                Console.WriteLine(this.Nom + " bénéficie d'une faiblesse de : " + avantage);
                dégatsRecus = (Force + Degats) - avantage;
                ennemi.PointDeVie -= dégatsRecus;
            }

            Console.WriteLine(this.Nom + " à infligé " + dégatsRecus + " dégats à " + ennemi.Nom + " et il à maintenant " + ennemi.PointDeVie + " points de vie");
            if (ennemi.PointDeVie <= 0)
            {
                Console.WriteLine(ennemi.Nom + " est mort !");
                ennemi.EstMort = true;
            }
        }
    }
}
