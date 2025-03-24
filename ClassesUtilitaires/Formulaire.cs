using Economie102.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.ClassesUtilitaires
{
    internal class Formulaire
    {
        public static void AjouterEntreprise()
        {
            U.Titre("Ajouter une entreprise");

            U.W("Raison sociale:");
            string? rs = U.RL();
            while (rs == null)
            {
                rs = U.RL();
            }

            U.W("Domaine d'activités:");
            string? dom = U.RL();
            while (dom == null)
            {
                dom = U.RL();
            }

            U.W("Fondée en :");
            string? af = U.RL();
            while (af == null)
            {
                af = U.RL();
            }

            // Pour les entreprises publique faut aussi récupérer la
            // valeur de l'action et le nbre d'Actions


            Entreprise e = new(rs, dom, af);

            Program.Producteurs.Add(e);

            U.WL($"{rs} a bien été ajoutée à ma liste d'entreprises");

            U.P();
        }
    }
}
