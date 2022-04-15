using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso.Classes.Armes
{
    class Arme
    {
        private int degats;
        private string nom;

        public Arme(int Dégats, string Nom)
        {
            degats = Dégats;
            nom = Nom;
        }

        public int Degat { get => degats; set => degats = value; }
        public string Name { get => nom; set => nom = value; }
    }
}
