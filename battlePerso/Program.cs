﻿using System;
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
            AfficherMenu();
        }

        public static void AfficherMenu()
        {

            Console.WriteLine("Choisi un personnage !");

            List<Personnage> lesPersonnages = new List<Personnage>();
            List<Personnage> lesPersonnagesMort = new List<Personnage>();

            Dieux Odin = new Dieux(100, 50, "Odin", "Lance de vériter", 1);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", "Lance de vériter", 3);
            Demon Hades = new Demon(100, 10, "Hades", "Flamme de l'enfer", 1);

            Personnage personnageCHoisi = null;
            

            lesPersonnages.Add(Odin);
            lesPersonnages.Add(Zeus);
            lesPersonnages.Add(Hades);

            AfficherPersonnages(lesPersonnages);

            switch (Console.ReadLine())
             {
                case "Odin":
                    Console.WriteLine("Vous avez choisi Odin");
                    personnageCHoisi = Odin;
                    break;
                case "Zeus":
                    Console.WriteLine("Vous avez choisi Zeus");
                    personnageCHoisi = Zeus;
                    break;
                case "Hades":
                    Console.WriteLine("Vous avez choisi Hades");
                    personnageCHoisi = Hades;
                    break;
            }

            while (lesPersonnages.Count > 1) 
            {
                LancerBattleRoyal(lesPersonnages);
                ListerPersonnagesMorts(lesPersonnages, lesPersonnagesMort); //Recompte les personnages morts
                Console.ReadLine();

            }
            if(lesPersonnages[0] == personnageCHoisi)
            {
                Console.WriteLine("Bravo ! Vous avez gagnez !");
            }
            else
            {
                Console.WriteLine("Dommage ! Vous avez perdu...");
            }
            Console.WriteLine("le vainqueur est "+ lesPersonnages[0].Nom);
            Console.ReadLine();
                

        }

        public static void AfficherPersonnages(List<Personnage> lesPersonnages)
        {
            foreach (Personnage unPerso in lesPersonnages)
            {
                Console.Write(unPerso.Nom + " ");
            }
            Console.WriteLine();
        }


        public static void ListerPersonnagesMorts(List<Personnage> lesPersonnages, List<Personnage> lesPersonnagesMorts)
        {
            foreach (Personnage unPerso in lesPersonnages.ToList())
            {
                if (unPerso.EstMort == true)
                {
                    lesPersonnages.Remove(unPerso);
                    lesPersonnagesMorts.Add(unPerso);
                }
            }
        }

        public static void LancerBattleRoyal(List<Personnage> lesPersonnages)
        {
            Random rdn_Personnage = new Random() ; 
            int choixPersonnage = rdn_Personnage.Next(0, lesPersonnages.Count); //Choix d'un personnage
            Random rdn_Adversaire = new Random(); 
            int choixAdversaire = rdn_Adversaire.Next(0, lesPersonnages.Count); //Choix de son adversaire

            while (choixPersonnage == choixAdversaire)
            {
                choixAdversaire = rdn_Adversaire.Next(0, lesPersonnages.Count);
            }

            Console.WriteLine(lesPersonnages[choixPersonnage].Nom + " combat contre " + lesPersonnages[choixAdversaire].Nom);

            lesPersonnages[choixPersonnage].Coup(lesPersonnages[choixAdversaire]);
        }

    }
}
