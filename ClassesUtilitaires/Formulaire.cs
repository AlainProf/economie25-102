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
        static Entreprise eTmp = new();
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

            U.W("Cette entreprise est-elle cotée en bourse? (o/n)");
            char rep = U.RC();
            while (rep != 'o' && rep != 'n')
            {
                U.WL("Mauvais choix");
                rep = U.RC();
            }

            if (rep == 'o')
            {
                // Pour les entreprises publique faut aussi récupérer la
                // valeur de l'action et le nbre d'Actions

                U.W("Valeur unitaire de l'action:");
                double valAc = 0;
                string? va = U.RL();
                while (va == null)
                {
                    va = U.RL();
                }
                valAc = double.Parse(va);

                U.W("Nombre d'actions émises:");
                int nbAc = 0;
                string? na = U.RL();
                while (na == null)
                {
                    na = U.RL();
                }
                nbAc = int.Parse(na);

                EntreprisePublique ep = new(rs, dom, valAc, nbAc, af);
                Program.Producteurs.Add(ep);

            }
            else
            {
                Entreprise e = new(rs, dom, af);

                Program.Producteurs.Add(e);
            }

            U.WL($"\n{rs} a bien été ajoutée à ma liste d'entreprises");
            U.P();
        }

        public static void ModifierUneEntreprise()
        {
            U.Titre("Modifier une entreprise en mémoire");
            U.W("Quel est l'id de l'entreprise à modifier?");
            string? idAMod = U.RL();
            
            bool trouve = false;
            if (idAMod != null)
            {
                int ipAM = int.Parse(idAMod);
                foreach (Entreprise e in Program.Producteurs)
                {
                    if (e.Id == ipAM)
                    {
                        trouve = true;
                        eTmp = e;
                        break;
                    }
                }
                if (trouve)
                {
                    FormulaireMAJEntreprise(eTmp);
                }
            }
            U.P($"{eTmp.RaisonSociale} a été modifié en mémoire");
        }

        static void FormulaireMAJEntreprise(Entreprise e)
        {
            U.WL("\nInfos actuelles:");
            e.Afficher(false);
            U.WL("------------------------------------\n");
            Menu mmaj = new("Quel champ voulez vous modifier?");

            mmaj.AjouterOption(new MenuItem('1', "Raison sociale", MAJRaisonSociale));
            mmaj.AjouterOption(new MenuItem('2', "Domaine d'activité", MAJDomaine));
            mmaj.AjouterOption(new MenuItem('3', "Année fondation", MAJAnFondation));

            mmaj.Afficher(false);
            mmaj.SaisirOption();
        }

        static void MAJRaisonSociale()
        {
            U.Titre($"Raison sociale actuelle:{eTmp.RaisonSociale}");
            U.W("Nouvelle raison sociale: ");
            string? neoRS = U.RL();
            if ( neoRS != null ) 
            {
               Program.Producteurs.Remove(eTmp);
               eTmp.RaisonSociale = neoRS;
               Program.Producteurs.Add(eTmp);
            }
            U.P(" Modification de la raison social OK");
        }

        static void MAJDomaine()
        {
            U.Titre($"Domaine d'activités actuelle:{eTmp.Domaine}");
            U.W("Nouveau domaine: ");
            string? neoDom = U.RL();
            if (neoDom != null)
            {
                Program.Producteurs.Remove(eTmp);
                eTmp.Domaine = neoDom;
                Program.Producteurs.Add(eTmp);
            }
            U.P(" Modification du domaine OK");

        }

        static void MAJAnFondation()
        {
            U.Titre($"Année de fondation actuelle:{eTmp.AnneeFondation}");
            U.W("Nouvelle année de fondation: ");
            string? neoRS = U.RL();
            if (neoRS != null)
            {
                Program.Producteurs.Remove(eTmp);
                eTmp.AnneeFondation = neoRS;
                Program.Producteurs.Add(eTmp);
            }
            U.P(" Modification de l'année de fondation OK");
        }
    }
}
