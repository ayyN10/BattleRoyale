using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Personnage
    {
        private float pointVie;
        private int force;
        private string nom;
        private int degats;
        private bool mort;

        private int statsDegatInflige;

        public Personnage(int PointVie, int Force, string Nom, int Dégats)
        {
            this.nom = Nom;
            this.force = Force;
            this.pointVie = PointVie;
            this.degats = Dégats;

            this.mort = false;
            this.StatsDegatInflige = 0;

        }

        public float PointDeVie { get => pointVie; set => pointVie = value; }
        public string Nom { get => nom; set => nom = value; }
        public bool EstMort { get => mort; set => mort = value; }
        public int Force { get => force; set => force = value; }
        public int Degats { get => degats; set => degats = value; }
        public int StatsDegatInflige { get => statsDegatInflige; set => statsDegatInflige = value; }

        //Le personnage actif attaque le perso1 et lui inflige des dégâts dans une range entre 2 nombres définis que l’on augmente ou réduit d’un
        //certain pourcentage selon les résistances
        public void attaquer(Personnage persoAAttaquer)
        {
            Console.WriteLine(this.nom + " attaque " + persoAAttaquer.nom);
            string raceAttaquant = this.GetType().Name;
            string raceReceveur = this.GetType().Name;
            float modificateurDegats = 1;

            switch (raceAttaquant)
            {
                case "Demon":
                    if (raceReceveur == "Tueur-Dieux")
                    {
                        modificateurDegats = 1.2f;
                    }
                    else if (raceReceveur == "Dieux")
                    {
                        modificateurDegats = 0.8f;
                    }
                    break;

                case "Dieux":
                    if (raceReceveur == "Demon")
                    {
                        modificateurDegats = 1.2f;
                    }
                    else if (raceReceveur == "Tueur-Dieux")
                    {
                        modificateurDegats = 0.8f;
                    }
                    break;

                case "Tueur_Dieux":
                    if (raceReceveur == "Dieux")
                    {
                        modificateurDegats = 1.2f;
                    }
                    else if (raceReceveur == "Demon")
                    {
                        modificateurDegats = 0.8f;
                    }
                    break;
            }

            Random rand = new Random();
            float degatsInfliges = rand.Next(15, 35) * modificateurDegats;

            persoAAttaquer.pointVie -= degatsInfliges;
            Console.WriteLine(this.nom + " a infligé " + degatsInfliges + " points de dégats a " + persoAAttaquer.nom);
            Console.WriteLine("Il reste  à " + persoAAttaquer.nom + " " + persoAAttaquer.PointDeVie + " points de vie.");

            if (persoAAttaquer.PointDeVie <= 0)
            {
                Console.WriteLine(persoAAttaquer.Nom + " est mort !");
                persoAAttaquer.EstMort = true;
            }

        }

        //Le personnage actif se soigne d'une certaine quantité de points de vie
        public void seSoigner()
        {
            Random rand = new Random();
            float pdvAvant = this.PointDeVie;
            if (this.PointDeVie < 30)
            {
                this.PointDeVie += rand.Next(25, 45);
            }
            else
            {
                this.PointDeVie += rand.Next(20, 35);
            }
            Console.WriteLine(this.nom + " s'est soigné de " + (this.PointDeVie - pdvAvant) + ", il a désormais " + this.PointDeVie + " points de vie.");
        }

        public virtual void Coup(Personnage ennemi)
        {
            //Coup POUR LE BATTLE ROYALE
        }
    }
}
