using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    class Arme
    {
        private int degat;
        private string name;

        public Arme(int Degat, string Nom)
        {
            this.Degat = Degat;
            this.name = Nom;
        }

        public int Degat { get => degat; set => degat = value; }
        public string Name { get => name; set => name = value; }
    }
}
