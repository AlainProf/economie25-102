using Economie102.Classes;
using System;
using System.Collections.Generic;
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
            string FICHIER_ENTREPRISE = "d:\\alino\\atelier\\economie\\entreprises.csv";
            if (File.Exists(FICHIER_ENTREPRISE))
            {
                //Console.WriteLine("Fichier OK");
                StreamReader reader = new StreamReader(FICHIER_ENTREPRISE);
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
                Console.WriteLine($"Erreur le fichier {FICHIER_ENTREPRISE} n'existe pas...");
            }
            U.P();
        }

        static bool ParsingEntreprise(string? infoBrute, out Entreprise e, out string msgErr)
        {

            e = new Entreprise();
            msgErr = "";

            if (infoBrute == null)
                return false;   

            int nbChamps = CompterNbChamps(infoBrute);
            //   Stagiaire (13 info)
            if (nbChamps == 6)
            {
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEntreprisePublique(tabInfo, out string contexte))
                {
                    e = new EntreprisePublique(int.Parse(tabInfo[0]),
                           tabInfo[1],
                           tabInfo[2],
                           tabInfo[5],
                           double.Parse(tabInfo[3]),
                           long.Parse(tabInfo[4]));
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

        static bool ValiderEntreprisePublique(string[] info, out string contexte )
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

    }
}
