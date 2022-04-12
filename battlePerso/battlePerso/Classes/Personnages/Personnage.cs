using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Personnage : Arme
    {
        private int pointVie;
        private int force;
        private string nom;
        public bool mort = false;
        
        public Personnage(int desPointVie, int uneForce, string unNomPerso, string uneArme, int desDegats) : base (desDegats, uneArme)
        {
            Nom = unNomPerso;
            Force = uneForce;
            PointVie = desPointVie;
        }

        public int PointVie { get => pointVie; set => pointVie = value; }
        public string Nom { get => nom; set => nom = value; }
        public bool Mort { get => mort; set => mort = value; }
        public int Force { get => force; set => force = value; }

        public virtual void Coup(Personnage ennemi)
        {
            Console.WriteLine(this.Nom + " attaque " + ennemi.Nom);
            ennemi.PointVie = ennemi.PointVie - (this.Force + Degat);
            Console.WriteLine("Il lui reste " + ennemi.PointVie + " HP");
            if (ennemi.PointVie<=0)
            {
                ennemi.Mort = true;
                Console.WriteLine(ennemi.Nom + " est Mort");
            }
        }
    }
}
