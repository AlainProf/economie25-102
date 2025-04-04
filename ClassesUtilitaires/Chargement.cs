using Economie102.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.ClassesUtilitaires
{
    internal class Chargement
    {
        public static void ChargerEntreprises()
        {
            U.Titre("Chargement des entreprises du Québec");
            if (File.Exists(U.FICHIER_ENTREPRISE))
            {
                //Console.WriteLine("Fichier OK");
                StreamReader reader = new StreamReader(U.FICHIER_ENTREPRISE);
                string? ligneCourante;
                int numLigne = 0;

                while (reader.Peek() > -1)
                {
                    numLigne++;
                    ligneCourante = reader.ReadLine();

                    if (ParsingEntreprise(ligneCourante, out Entreprise e, out string msgErr))
                    {
                        Program.Producteurs.Add(e);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur à la ligne {numLigne}, {msgErr}");
                    }
                }
                Console.WriteLine($"Chargement de {Program.Producteurs.Count} entreprises");
                reader.Close();
            }
            else
            {
                Console.WriteLine($"Erreur le fichier {U.FICHIER_ENTREPRISE} n'existe pas...");
            }
            //U.P();
        }

        static bool ParsingEntreprise(string? infoBrute, out Entreprise e, out string msgErr)
        {

            e = new Entreprise();
            msgErr = "";

            if (infoBrute == null)
                return false;   

            int nbChamps = CompterNbChamps(infoBrute);
            
            // Entreprise cotée en bourse
            if (nbChamps == 6)
            {
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEntreprisePublique(tabInfo, out string contexte))
                {
                    e = new EntreprisePublique(int.Parse(tabInfo[0]),
                           tabInfo[1],
                           tabInfo[2],
                           double.Parse(tabInfo[3]),
                           long.Parse(tabInfo[4]), 
                           tabInfo[5]);
                    return true;
                }
                else
                {
                    msgErr = $"{contexte}";
                    return false;
                }
            }

            // Entreprise générale
            if (nbChamps == 4)
            {
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEntreprise(tabInfo, out string contexte))
                {
                    e = new Entreprise(int.Parse(tabInfo[0]),
                           tabInfo[1],
                           tabInfo[2],
                           tabInfo[3]);
                    return true;
                }
                else
                {
                    msgErr = $"{contexte}";
                    return false;
                }
            }
            return false;
        }

        static bool ValiderEntreprisePublique(string[] info, out string contexte)
        {
            contexte = "";
            return true;
        }
        static bool ValiderEntreprise(string[] info, out string contexte)
        {
            contexte = "";
            return true;
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        private static int CompterNbChamps(string info)
        {
            if (info.Length == 0)
                return 0;

            int nbChamps = 1;
            foreach (char c in info)
            {
                if (c == ';')
                {
                    nbChamps++;
                }
            }
            return nbChamps;
        }

        
        public static void ChargerEmployes()
        {
            U.Titre("Chargement des travailleurs salariés du Québec");
            if (File.Exists(U.FICHIER_EMPLOYES))
            {
                //Console.WriteLine("Fichier OK");
                StreamReader reader = new StreamReader(U.FICHIER_EMPLOYES);
                string? ligneCourante;
                int numLigne = 0;

                while (reader.Peek() > -1)
                {
                    numLigne++;
                    ligneCourante = reader.ReadLine();

                    if (ParsingEmployeHoraire(ligneCourante, out EmpHoraire e, out string msgErr))
                    {
                        Program.Travailleurs.Add(e);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur à la ligne {numLigne}, {msgErr}");
                    }
                }
                Console.WriteLine($"Chargement de {Program.Travailleurs.Count} travailleurs");
                reader.Close();
            }
            else
            {
                Console.WriteLine($"Erreur le fichier {U.FICHIER_EMPLOYES} n'existe pas...");
            }
            //U.P();
        }

        static bool ParsingEmployeHoraire(string? infoBrute, out EmpHoraire e, out string msgErr)
        {
            e = new EmpHoraire();
            msgErr = "";

            if (infoBrute == null)
                return false;

            int nbChamps = CompterNbChamps(infoBrute);

            // Entreprise cotée en bourse
            if (nbChamps == 6)
            {
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEmployeHoraire(tabInfo, out string contexte))
                {
                    string pattern = "yyyy-MM-dd";
                    DateTime parsedDate = DateTime.Now;
                    if (DateTime.TryParseExact(tabInfo[4], pattern, null,DateTimeStyles.None, out parsedDate))
                    e = new EmpHoraire(tabInfo[2],
                                       parsedDate,
                                       tabInfo[3],
                                       int.Parse(tabInfo[0]),
                                       int.Parse(tabInfo[1]),
                                       double.Parse(tabInfo[5]));
                    return true;
                }
                else
                {
                    msgErr = $"{contexte}";
                    return false;
                }
            }
            return false;
        }

        static bool ValiderEmployeHoraire(string[] info, out string contexte)
        {
            contexte = "";
            return true;
        }
        static bool ValiderFDT(string[] info, out string contexte)
        {
            contexte = "";
            return true;
        }


        public static void ChargerFeuillesTemps()
        {
            if (File.Exists(U.FICHIER_FEUILLESTEMPS))
            {
                //Console.WriteLine("Fichier OK");
                StreamReader reader = new StreamReader(U.FICHIER_FEUILLESTEMPS);
                string? ligneCourante;
                int numLigne = 0;

                while (reader.Peek() > -1)
                {
                    numLigne++;
                    ligneCourante = reader.ReadLine();

                    if (ParsingFDT(ligneCourante, out FeuilleTemps ft, out string msgErr))
                    {
                        Program.Horodateurs.Add(ft);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur à la ligne {numLigne}, {msgErr}");
                    }
                }
                Console.WriteLine($"Chargement de {Program.Horodateurs.Count} feuilles de temps");
                reader.Close();
            }
            else
            {
                Console.WriteLine($"Erreur le fichier {U.FICHIER_EMPLOYES} n'existe pas...");
            }
            //U.P();
        }

        static bool ParsingFDT(string? infoBrute, out FeuilleTemps ft, out string msgErr)
        {
            ft = new FeuilleTemps();
            msgErr = "";

            if (infoBrute == null)
                return false;

            int nbChamps = CompterNbChamps(infoBrute);

            // Entreprise cotée en bourse
            if (nbChamps == 4)
            {
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderFDT(tabInfo, out string contexte))
                {
                    ft = new FeuilleTemps(int.Parse(tabInfo[0]),
                                          int.Parse(tabInfo[1]),
                                          int.Parse(tabInfo[2]),
                                          int.Parse(tabInfo[3]));
                    return true;
                }
                else
                {
                    msgErr = $"{contexte}";
                    return false;
                }
            }
            return false;
        }
    }
}
