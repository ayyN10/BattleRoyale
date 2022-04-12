using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace battlePerso
{
    class Program
    {
        static void Main(string[] args)
        {  
            menu();
        }

        public static void menu()
        {
            Console.WriteLine("Quels Personnage Choisi tu ?");
            List<personnages> lesPersonnages = new List<personnages>();
            Dieux Odin = new Dieux(100, 50, "Odin", "Lance de vériter", 1,"Dieux");
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", "Lance de vériter", 3,"Tueur_Dieux");
            Demon Hades = new Demon(100, 10, "Hades", "Flamme de l'enfer", 1, "Demon"); 
            lesPersonnages.Add(Odin);
            lesPersonnages.Add(Zeus);
            lesPersonnages.Add(Hades);
            ListPerso(lesPersonnages);
            switch (Console.ReadLine())
             {
                case "Odin":
                    Console.WriteLine("Vous avez choisi Odin");
                    Console.WriteLine();
                    break;
                case "Zeus":
                    Console.WriteLine("Vous avez choisi Zeus");
                    Console.WriteLine();
                    break;
                case "Hades":
                    Console.WriteLine("Vous avez choisi Hades");
                    Console.WriteLine();
                    break;
            }

            while (ListPersoEnVie(lesPersonnages) != 1) 
            {
                ListPersoMort(lesPersonnages);
                anarchie(lesPersonnages);

            }
            
        }

        public static void ListPerso(List<personnages> lesPersonnages)
        {
            foreach (personnages unPerso in lesPersonnages)
            {
                Console.WriteLine(unPerso.Nom);
            }
        }
        public static int ListPersoEnVie(List<personnages> lesPersonnages)
        {
            int lesPersoEnVie = 0;
            foreach (personnages unPerso in lesPersonnages)
            {
                if(unPerso.Mort == false)
                {
                    lesPersoEnVie++;
                }
            }
            return lesPersoEnVie;
        }

        public static void ListPersoMort(List<personnages> lesPersonnages)
        {
            List<personnages> lesPersonnagesMort = new List<personnages>();
            foreach (personnages unPerso in lesPersonnages.ToList())
            {
                if (unPerso.Mort == true)
                {
                    lesPersonnages.Remove(unPerso);
                    lesPersonnagesMort.Add(unPerso);
                }
            }
        }

        public static void anarchie(List<personnages> lesPersonnages)
        {
            Random rdn_index= new Random() ;
            int indexPerso_Rdn = rdn_index.Next(0, lesPersonnages.Count);

            Random rdn_ennemi = new Random();
            int indexEnnemi_Rdn = rdn_ennemi.Next(0, lesPersonnages.Count);

            while (indexPerso_Rdn == indexEnnemi_Rdn)
            {
                indexEnnemi_Rdn = rdn_ennemi.Next(0, lesPersonnages.Count);
            }
            lesPersonnages[indexPerso_Rdn].Coup(lesPersonnages[indexEnnemi_Rdn]);
        }

    }
}
