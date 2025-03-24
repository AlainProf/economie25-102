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
                sw.WriteLine(e.Id.ToString() + ";" + e.RaisonSociale + ";" + e.Domaine + ";" + e.AnneeFondation);
            }
            sw.Close();
            U.P($"{Program.Producteurs.Count} entreprises sauvegardées en BD");
        }
    }
}
