using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso.Classes.Personnages
{
    class Tueur_Dieux : Personnage
    {
        private int avantage;
        private int désavantage;

        public Tueur_Dieux(int PointsDeVie, int Force, string Nom, string Arme, int Dégats, int avantage, int désavantage) : base(PointsDeVie, Force, Nom, Arme, Dégats)
        {
            Avantage = avantage;
            Désavantage = désavantage;
        }

        public int Avantage { get => avantage; set => avantage = value; }
        public int Désavantage { get => désavantage; set => désavantage = value; }

        public override void Coup(Personnage ennemi)
        {
            int dégatsRecus = 0;
            if (ennemi is Dieux)
            {
                Console.WriteLine(Nom + " bénéficie d'un avantage de : " + Avantage);
                dégatsRecus = Force + Degats + Avantage;
                ennemi.PointDeVie -= dégatsRecus;

            }
            else if (ennemi is Demon)
            {
                Console.WriteLine(Nom + " bénéficie d'une faiblesse de : " + Désavantage);
                dégatsRecus = Force + Degats - Désavantage;
                ennemi.PointDeVie -= dégatsRecus;
            }

            Console.WriteLine(Nom + " à infligé " + dégatsRecus + " dégats à " + ennemi.Nom + " et il à maintenant " + ennemi.PointDeVie + " points de vie");
            if (ennemi.PointDeVie <= 0)
            {
                Console.WriteLine(ennemi.Nom + " est mort !");
                ennemi.EstMort = true;
            }

            //this.degatInflige = this.degatInflige + dégatsRecus;


        }
    }
}
