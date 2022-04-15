using battlePerso.Classes;
using battlePerso.Classes.Personnages;
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
            AfficherMenu();
            /* TESTS Nathan
            Database db = new Database();
            string user = Console.ReadLine();
            int id = db.VérifUser(user);
            Console.WriteLine("ID: " + id);
            Console.ReadLine();
            */
        }

        public static void AfficherMenu()
        {
            bool bonChoix = false;
            while (bonChoix == false)
            {
                Console.WriteLine("Choisissez votre mode de jeux");
                Console.WriteLine("Tapez 1 si vous voulez jouer au Battle Royale");
                Console.WriteLine("Tapez 2 si vous voulez jouer au 1 vs 1");

                switch (Console.ReadLine())
                {
                    case "1":
                        bonChoix = true;
                        LancerBattleRoyal();
                        break;
                    case "2":
                        bonChoix = true;
                        Lancer1V1();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        break;
                }
            }
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


        private static void Lancer1V1()
        {
            List<Personnage> lesPersonnages = new List<Personnage>();
            List<Personnage> lesPersonnagesVivant = new List<Personnage>();
            List<Personnage> lesPersonnagesMort = new List<Personnage>();

            Dieux Odin = new Dieux(100, 50, "Odin", "Lance de vériter", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", "Lance de vériter", 3, 50, 50);
            Demon Hades = new Demon(100, 10, "Hades", "Flamme de l'enfer", 1, 50, 50);
            lesPersonnages.Add(Odin);
            lesPersonnages.Add(Zeus);
            lesPersonnages.Add(Hades);
            Console.WriteLine("Choisissez un personnage !");
            Personnage personnageChoisi1v1 = null;
            AfficherPersonnages(lesPersonnages);
            bool bonChoix = false;
            while (bonChoix == false)
            {
                switch (Console.ReadLine())
                {
                    case "Odin":
                        Console.WriteLine("Vous avez choisi Odin");
                        personnageChoisi1v1 = Odin;
                        lesPersonnagesVivant.Add(personnageChoisi1v1);
                        bonChoix = true;
                        break;
                    case "Zeus":
                        Console.WriteLine("Vous avez choisi Zeus");
                        personnageChoisi1v1 = Zeus;
                        lesPersonnagesVivant.Add(personnageChoisi1v1);
                        bonChoix = true;
                        break;
                    case "Hades":
                        Console.WriteLine("Vous avez choisi Hades");
                        personnageChoisi1v1 = Hades;
                        lesPersonnagesVivant.Add(personnageChoisi1v1);
                        bonChoix = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        Console.WriteLine("Choisissez un personnage !");
                        AfficherPersonnages(lesPersonnages);
                        break;
                }
            }

            lesPersonnages.Remove(personnageChoisi1v1);

            Console.WriteLine("Choisissez votre adversaire !");
            Personnage personnageChoisi1v1Adversaire = null;

            AfficherPersonnages(lesPersonnages);
            bonChoix = false;
            while (bonChoix == false)
            {
                switch (Console.ReadLine())
                {
                    case "Odin":
                        if (personnageChoisi1v1 == personnageChoisi1v1Adversaire)
                        {
                            Console.WriteLine("Vous pouvez pas choisir vous même en tant que adversaire ! ");
                            Lancer1V1();
                        }
                        Console.WriteLine("Vous avez choisi Odin comme adversaire");
                        personnageChoisi1v1Adversaire = Odin;
                        lesPersonnagesVivant.Add(personnageChoisi1v1Adversaire);
                        bonChoix = true;
                        break;
                    case "Zeus":
                        if (personnageChoisi1v1 == personnageChoisi1v1Adversaire)
                        {
                            Console.WriteLine("Vous pouvez pas choisir vous même en tant que adversaire ! ");
                            Lancer1V1();
                        }
                        Console.WriteLine("Vous avez choisi Zeus comme adversaire");
                        personnageChoisi1v1Adversaire = Zeus;
                        lesPersonnagesVivant.Add(personnageChoisi1v1Adversaire);
                        bonChoix = true;
                        break;
                    case "Hades":
                        if (personnageChoisi1v1 == personnageChoisi1v1Adversaire)
                        {
                            Console.WriteLine("Vous pouvez pas choisir vous même en tant que adversaire ! ");
                            Lancer1V1();
                        }
                        Console.WriteLine("Vous avez choisi Hades comme adversaire");
                        personnageChoisi1v1Adversaire = Hades;
                        lesPersonnagesVivant.Add(personnageChoisi1v1Adversaire);
                        bonChoix = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        Console.WriteLine("Choisissez votre adversaire !");
                        AfficherPersonnages(lesPersonnages);
                        break;
                }
            }

            while (lesPersonnagesVivant.Count > 1)
            {
                LancerCombat1v1(lesPersonnagesVivant);
                ListerPersonnagesMorts(lesPersonnagesVivant, lesPersonnagesMort); //Recompte les personnages morts
                Console.ReadLine();

            }
            if (lesPersonnagesVivant[0] == personnageChoisi1v1)
            {
                Console.WriteLine("Bravo ! Vous avez gagnez !");
            }
            else
            {
                Console.WriteLine("Dommage ! Vous avez perdu...");
            }
            Console.WriteLine("le vainqueur est " + lesPersonnagesVivant[0].Nom);
            Console.ReadLine();
        }

        public static void LancerBattleRoyal()
        {
            List<Personnage> lesPersonnages = new List<Personnage>();
            List<Personnage> lesPersonnagesMort = new List<Personnage>();

            Dieux Odin = new Dieux(100, 50, "Odin", "Lance de vériter", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", "Lance de vériter", 3, 50, 50);
            Demon Hades = new Demon(100, 10, "Hades", "Flamme de l'enfer", 1, 50, 50);
            lesPersonnages.Add(Odin);
            lesPersonnages.Add(Zeus);
            lesPersonnages.Add(Hades);

            Console.WriteLine("Choisissez un personnage !");
            Personnage personnageChoisi = null;
            AfficherPersonnages(lesPersonnages);
            bool bonChoix = false;
            while (bonChoix == false)
            {
                switch (Console.ReadLine())
                {
                    case "Odin":
                        Console.WriteLine("Vous avez choisi Odin");
                        personnageChoisi = Odin;
                        bonChoix = true;
                        break;
                    case "Zeus":
                        Console.WriteLine("Vous avez choisi Zeus");
                        personnageChoisi = Zeus;
                        bonChoix = true;
                        break;
                    case "Hades":
                        Console.WriteLine("Vous avez choisi Hades");
                        personnageChoisi = Hades;
                        bonChoix = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        Console.WriteLine("Choisissez un personnage !");
                        AfficherPersonnages(lesPersonnages);
                        break;
                }
            }

            while (lesPersonnages.Count > 1)
            {
                LancerCombatBattleRoyal(lesPersonnages);
                ListerPersonnagesMorts(lesPersonnages, lesPersonnagesMort); //Recompte les personnages morts
                Console.ReadLine();

            }
            if (lesPersonnages[0] == personnageChoisi)
            {
                Console.WriteLine("Bravo ! Vous avez gagnez !");
            }
            else
            {
                Console.WriteLine("Dommage ! Vous avez perdu...");
            }
            Console.WriteLine("le vainqueur est " + lesPersonnages[0].Nom);
            Console.ReadLine();
        }

        public static void LancerCombat1v1(List<Personnage> lesPersonnages)
        {
            Random rdn_Personnage = new Random();
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

        public static void LancerCombatBattleRoyal(List<Personnage> lesPersonnages)
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
