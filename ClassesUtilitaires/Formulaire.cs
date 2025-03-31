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
            U.Titre("Modifier une entreprise en mémoire", false);
            U.W("ID: ");
            string? idAMod = U.RL();
            
            bool trouve = false;
            if (idAMod != null)
            {

                if (int.TryParse(idAMod, out int ipAM))
                {
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
                    else
                    {
                        U.P($"L'entreprise {idAMod} n'existe pas en mémoire");
                    }
                }
                else
                {
                    U.P($"L'id fourni ({idAMod}) n'est pas un entier");
                }
            }
        }

        static void FormulaireMAJEntreprise(Entreprise e)
        {
            e.Afficher(false);
            U.WL("------------------------------------\n");
            Menu mmaj = new("Quel champ voulez vous modifier?", false);

            mmaj.AjouterOption(new MenuItem('1', "Raison sociale", MAJRaisonSociale));
            mmaj.AjouterOption(new MenuItem('2', "Domaine d'activité", MAJDomaine));
            mmaj.AjouterOption(new MenuItem('3', "Année fondation", MAJAnFondation));
            mmaj.AjouterOption(new MenuItem('q', "Quitter la modifcation", Quitter));

            mmaj.SaisirOption();
        }

        static void MAJRaisonSociale()
        {
            U.W("Nouvelle raison sociale: ");
            string? neoRS = U.RL();
            if ( neoRS != null ) 
            {
               Program.Producteurs.Remove(eTmp);
               eTmp.RaisonSociale = neoRS;
               Program.Producteurs.Add(eTmp);
            }
            U.P($"Nouvelle raison sociale: {eTmp.RaisonSociale}");
        }

        static void MAJDomaine()
        {
            U.W("Nouveau domaine: ");
            string? neoDom = U.RL();
            if (neoDom != null)
            {
                Program.Producteurs.Remove(eTmp);
                eTmp.Domaine = neoDom;
                Program.Producteurs.Add(eTmp);
            }
            U.P($"Nouveau domaine d'activité: {eTmp.Domaine}");
        }

        static void MAJAnFondation()
        {
            U.W("Nouvelle année de fondation: ");
            string? neoRS = U.RL();
            if (neoRS != null)
            {
                Program.Producteurs.Remove(eTmp);
                eTmp.AnneeFondation = neoRS;
                Program.Producteurs.Add(eTmp);
            }
            U.P($"Nouvelle année de fondation : {eTmp.AnneeFondation}");
        }


        static void Quitter()
        {
        }
    }
}
