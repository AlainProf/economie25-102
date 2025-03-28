using Economie102.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.ClassesUtilitaires
{
    internal class GestionnaireBD
    {
        public static void EnregistrerListeEntreprises()
        {
            U.Titre("Sauvegarder la liste des entreprises en BD");
            StreamWriter sw = new StreamWriter(U.FICHIER_ENTREPRISE);
            foreach (Entreprise e in Program.Producteurs)
            {
                if (e is EntreprisePublique)
                {
                    EntreprisePublique? ep = e as EntreprisePublique;
                    if (ep != null)
                    {
                        sw.WriteLine(ep.Id.ToString() + ";" + ep.RaisonSociale + ";"
                                                         + ep.Domaine + ";"
                                                         + ep.ValeurUnitaire + ";"
                                                         + ep.NbActionsEmises + ";"
                                                         + ep.AnneeFondation);
                    }
                }
                else
                {
                    sw.WriteLine(e.Id.ToString() + ";" + e.RaisonSociale + ";" + e.Domaine + ";" + e.AnneeFondation);
                }
            }
            sw.Close();
            U.P($"{Program.Producteurs.Count} entreprises sauvegardées en BD");
        }

        public static void EffacerListeEntreprises()
        {
            int nbEntrep = Program.Producteurs.Count;
            U.Titre("Effacement de la liste des entreprises en mémoire");
            Program.Producteurs.Clear();
            U.P($"{nbEntrep} entreprises effacées, la liste est maintenant vide");
        }

        public static void EffacerUneEntreprise()
        {
            U.Titre("Effacement d'une entreprise en mémoire");
            U.W("Quel est l'id de l'entreprise à effacer?");
            string? idASupp = U.RL();
            string rsTmp = "";
            if (idASupp != null)
            {
                int ipAS = int.Parse(idASupp);
                foreach(Entreprise e in Program.Producteurs)
                {
                    if (e.Id == ipAS)
                    {
                        rsTmp = e.RaisonSociale;
                        Program.Producteurs.Remove(e);
                        break;
                    }
                }
            }
            U.P($"{rsTmp} a été supprimée en mémoire");
        }
    }
}
