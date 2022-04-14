using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Arme
    {
        private int degats;
        private string nom;

        public Arme(int Dégats, string Nom)
        {
            this.degats = Dégats;
            this.nom = Nom;
        }

        public int Degat { get => degats; set => degats = value; }
        public string Name { get => nom; set => nom = value; }
    }
}
