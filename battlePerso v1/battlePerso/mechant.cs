using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class mechant : armes
    {
        private int pointVie;
        private int force;
        private string nom;
        private bool mort = false;

        public mechant(int desPointVie, int uneForce, string unNom, string uneArme, int desDegats, int uneDurabilite) : base(desPointVie, uneForce, unNom)
        {
            Nom = unNom;
            force = uneForce;
            PointVie = desPointVie;
        }

        public int PointVie { get => pointVie; set => pointVie = value; }
        public string Nom { get => nom; set => nom = value; }
        public bool Mort { get => mort; set => mort = value; }

        public void Coup(personnages ennemi)
        {
            ennemi.PointVie = ennemi.PointVie - (this.force + Degat);
            if (ennemi.PointVie <= 0)
            {
                Mort = true;
                Console.WriteLine(ennemi.Nom + " est Mort");
            }
        }
    }
}
