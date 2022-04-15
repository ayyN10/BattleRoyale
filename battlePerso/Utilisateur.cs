using System;
using System.Collections.Generic;
using System.Text;

namespace battlePerso
{
    static class Utilisateur
    {
        private static int idUtilisateur = -1;

        public static int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
    }
}
