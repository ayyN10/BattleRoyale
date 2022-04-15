using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso.Classes.Personnages
{
    class Personnage
    {
        private int pointVie;
        private int force;
        private string nom;
        private int degats;
        private bool mort;

        private int statsDegatInflige;

        public Personnage(int PointVie, int Force, string Nom, string uneArme, int Dégats)
        {
            nom = Nom;
            force = Force;
            pointVie = PointVie;
            degats = Dégats;

            mort = false;
            StatsDegatInflige = 0;

        }

        public int PointDeVie { get => pointVie; set => pointVie = value; }
        public string Nom { get => nom; set => nom = value; }
        public bool EstMort { get => mort; set => mort = value; }
        public int Force { get => force; set => force = value; }
        public int Degats { get => degats; set => degats = value; }
        public int StatsDegatInflige { get => statsDegatInflige; set => statsDegatInflige = value; }

        public virtual void Coup(Personnage ennemi)
        {
            /*
            Console.WriteLine(this.Nom + " attaque " + ennemi.Nom);
            ennemi.PointDeVie = ennemi.PointDeVie - (this.Force + Degats);
            this.degats += this.Force + Degats;
            Console.WriteLine("Il lui reste " + ennemi.PointVie + " HP");
            if (ennemi.PointVie<=0)
            {
                Console.WriteLine("il a enleve " + this.degatInflige + " HP au total");
                ennemi.Mort = true;
                Console.WriteLine(ennemi.Nom + " est Mort");
            }           
            
            INUTILE -> virtual
            */
        }
    }
}
