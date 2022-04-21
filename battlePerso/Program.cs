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
            AfficherConnexion();

            /*
            // TESTS Nathan
            Database db = new Database();
            int user = int.Parse(Console.ReadLine());
            string perso = Console.ReadLine();
            bool marche = db.InsertStatistique(user, perso, 5000, true);

            Console.WriteLine(marche.ToString());
            Console.ReadLine();
            */
            
        }
        public static void AfficherConnexion(){
            bool bonChoix = false;
            Database db = new Database();
            while (bonChoix == false)
            {
                Console.WriteLine("vous devez vous connecter, entrez votre identifiant :");
                int idUtil = db.VérifUser(Console.ReadLine());
                if (idUtil != -1)
                {
                    Console.Clear();
                    Console.WriteLine("Vous etes maintenant connecté\n");
                    Utilisateur.IdUtilisateur = idUtil;
                    bonChoix = true;
                    AfficherMenu();                
                }
            } 
        }

        public static void AfficherMenu()
        {
            bool bonChoix = false;
            while (bonChoix == false)
            {
                
                Console.WriteLine("Que souhaitez-vous faire ?");
                Console.WriteLine("1 - Jouer une partie");
                Console.WriteLine("2 - Voir vos statistiques");
                Console.WriteLine("3 - Quitter l'application");

                switch (Console.ReadLine())
                {
                    case "1":
                        bonChoix = true;
                        Console.Clear();
                        ChoixModeDeJeu();
                        break;
                    case "2":
                        bonChoix = true;
                        Console.Clear();
                        AfficherStatistiques();
                        break;
                    case "3":
                        bonChoix = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        break;
                }
            }
        }
        public static void ChoixModeDeJeu()
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
                        Console.Clear();
                        LancerBattleRoyal();
                        break;
                    case "2":
                        bonChoix = true;
                        Console.Clear();
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

        public static void AfficherStatistiques()
        {
            bool bonChoix = false;
            Database db = new Database();
            while (bonChoix == false)
            {
                Console.WriteLine("Quel statistique souhaitez-vous voir ?");
                Console.WriteLine("1 - Voir votre nombre de victoire");
                Console.WriteLine("2 - Voir vos dégats infligé ");
                Console.WriteLine("3 - Retourner au menu principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        int nbVictoires = db.GetNbVictoires(Utilisateur.IdUtilisateur);
                        Console.WriteLine("Vous avez comptabilisé " + nbVictoires + " victoires.\n");
                        break;

                    case "2":
                        Console.Clear();
                        int totalDégatsInfligés = db.GetTotalDégatsInfligés(Utilisateur.IdUtilisateur);
                        Console.WriteLine("Vous avez comptabilisé un total de " + totalDégatsInfligés + " dégats sur l'ensemble vos parties.\n");
                        break;

                    case "3":
                        bonChoix = true;
                        Console.Clear();
                        AfficherMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        break;
                }
            }
        }
        private static void Lancer1V1()
        {
            Console.WriteLine("Vous lancez une partie de 1 vs 1 :\n");
            List<Personnage> lesPersonnages = new List<Personnage>();
            List<Personnage> lesPersonnagesVivant = new List<Personnage>();
            List<Personnage> lesPersonnagesMort = new List<Personnage>();

            Dieux Odin = new Dieux(100, 50, "Odin", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Demon Hades = new Demon(100, 10, "Hades", 1, 50, 50);
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
                        Console.WriteLine("\nVous avez choisi Odin\n");
                        personnageChoisi1v1 = Odin;
                        lesPersonnagesVivant.Add(personnageChoisi1v1);
                        bonChoix = true;
                        break;
                    case "Zeus":
                        Console.WriteLine("\nVous avez choisi Zeus\n");
                        personnageChoisi1v1 = Zeus;
                        lesPersonnagesVivant.Add(personnageChoisi1v1);
                        bonChoix = true;
                        break;
                    case "Hades":
                        Console.WriteLine("\nVous avez choisi Hades\n");
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
                        Console.WriteLine("\nVous avez choisi Odin comme adversaire\n");
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
                        Console.WriteLine("\nVous avez choisi Zeus comme adversaire\n");
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
                        Console.WriteLine("\nVous avez choisi Hades comme adversaire\n");
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
                LancerCombat1v1(lesPersonnagesVivant, personnageChoisi1v1, personnageChoisi1v1Adversaire);
                ListerPersonnagesMorts(lesPersonnagesVivant, lesPersonnagesMort); //Recompte les personnages morts
                Console.ReadLine();

            }
            Database db = new Database();
            if (lesPersonnagesVivant[0] == personnageChoisi1v1)
            {
                Console.WriteLine("Bravo ! Vous avez gagnez !");
                if(!db.InsertStatistique(Utilisateur.IdUtilisateur, personnageChoisi1v1.Nom, personnageChoisi1v1.StatsDegatInflige, true))
                {
                    Console.WriteLine("Une erreur à eut lieu pour enregistrer ce combat dans la base de donnée");
                }
                
            }
            else
            {
                Console.WriteLine("Dommage ! Vous avez perdu...");
                if (!db.InsertStatistique(Utilisateur.IdUtilisateur, personnageChoisi1v1.Nom, personnageChoisi1v1.StatsDegatInflige, false))
                {
                    
                }


            }
            Console.WriteLine("le vainqueur est " + lesPersonnagesVivant[0].Nom);
            Console.ReadLine();

            Console.Clear();
            AfficherMenu();
        }

        public static void LancerBattleRoyal()
        {
            Console.WriteLine("Vous lancez une partie de Battle Royal :\n");
            List<Personnage> lesPersonnages = new List<Personnage>();
            List<Personnage> lesPersonnagesMort = new List<Personnage>();

            Dieux Odin = new Dieux(100, 50, "Odin", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Demon Hades = new Demon(100, 10, "Hades", 1, 50, 50);
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
                        Console.WriteLine("\nVous avez choisi Odin\n");
                        personnageChoisi = Odin;
                        bonChoix = true;
                        break;
                    case "Zeus":
                        Console.WriteLine("\nVous avez choisi Zeus\n");
                        personnageChoisi = Zeus;
                        bonChoix = true;
                        break;
                    case "Hades":
                        Console.WriteLine("\nVous avez choisi Hades\n");
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
            Database db = new Database();
            if (lesPersonnages[0] == personnageChoisi)
            {
                Console.WriteLine("Bravo ! Vous avez gagnez !");
                if (!db.InsertStatistique(Utilisateur.IdUtilisateur, personnageChoisi.Nom, personnageChoisi.StatsDegatInflige, true))
                {
                    Console.WriteLine("Une erreur à eut lieu pour enregistrer ce combat dans la base de donnée");
                }
            }
            else
            {
                Console.WriteLine("Dommage ! Vous avez perdu...");
                if (!db.InsertStatistique(Utilisateur.IdUtilisateur, personnageChoisi.Nom, personnageChoisi.StatsDegatInflige, false))
                {
                    Console.WriteLine("Une erreur à eut lieu pour enregistrer ce combat dans la base de donnée");
                }
            }
            Console.WriteLine("le vainqueur est " + lesPersonnages[0].Nom);
            Console.ReadLine();

            Console.Clear();
            AfficherMenu();
        }

        public static void LancerCombat1v1(List<Personnage> personnageVivant, Personnage personnageChoisi1v1, Personnage personnageChoisi1v1Adversaire)
        {
            Console.WriteLine("Quels action souhaitez vous effectuer ?");
            Console.WriteLine("Attaquer = 1");
            Console.WriteLine("Soigner = 2");

            bool bonChoix = false;
            while (bonChoix == false)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Vous avez choisi d'attaquer");
                        personnageChoisi1v1.attaquer(personnageChoisi1v1Adversaire);
                        bonChoix = true;
                        break;
                    case "2":
                        Console.WriteLine("Vous avez choisi de vous soigner");
                        personnageChoisi1v1.seSoigner();
                        bonChoix = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choix incorrect\n");
                        Console.WriteLine("Choisissez uune bonne action !\n");
                        Console.WriteLine("Quels action souhaitez vous effectuer ?");
                        Console.WriteLine("Attaquer = 1");
                        Console.WriteLine("Soigner = 2");
                        break;
                }
            }

            Random rand = new Random();
            int choix = rand.Next(100);
            if (choix <= 75)
            {
                personnageChoisi1v1Adversaire.attaquer(personnageChoisi1v1);
            }
            else
            {
                personnageChoisi1v1Adversaire.seSoigner();
            }
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
