using Economie102.Classes;
using Economie102.ClassesUtilitaires;


namespace Economie102
{
    internal class Program
    {
        static public List<Entreprise> Producteurs { get; set; } = new List<Entreprise>();
        static public List<EmpHoraire> Travailleurs { get; set; } = new();
        static public List<FeuilleTemps> Horodateurs { get; set; } = new();


        static void Main(string[] args)
        {
            Chargement.ChargerEntreprises();
            Chargement.ChargerEmployes();
            RecupEmpEntrep();
            Chargement.ChargerFeuillesTemps();

            U.Titre("Analyse économique gr 102");
            Menu mp = new("Menu principal");
            /*            mp.AjouterOption(new MenuItem('C', "Charger les entreprises", Chargement.ChargerEntreprises));
                        mp.AjouterOption(new MenuItem('P', "Charger les employés", Chargement.ChargerEmployes));
                        mp.AjouterOption(new MenuItem('R', "Récuperation des employés par leurs entreprises", RecupEmpEntrep));
             */
            mp.AjouterOption(new MenuItem('C', "Calculer la paye d'une entreprise", CalculerPaye));
            mp.AjouterOption(new MenuItem('U', "Afficher Une entreprise", AfficherUneEntreprise));
            mp.AjouterOption(new MenuItem('A', "Afficher les entreprises", AfficherEntreprises));
            mp.AjouterOption(new MenuItem('V', "Valeurs des capitalisations boursières ", ValeurEnBourse));
            mp.AjouterOption(new MenuItem('T', "Trier les valeurs des capitalisations boursières ", TriValeurEnBourse));
            mp.AjouterOption(new MenuItem('J', "Ajouter une entreprise", Formulaire.AjouterEntreprise));
            mp.AjouterOption(new MenuItem('S', "Sauvergarder la liste en BD", GestionnaireBD.EnregistrerListeEntreprises));
            mp.AjouterOption(new MenuItem('E', "Effacer la liste des entreprises en mémoire", GestionnaireBD.EffacerListeEntreprises));
            mp.AjouterOption(new MenuItem('D', "Effacer une entreprise de la liste en mémoire", GestionnaireBD.EffacerUneEntreprise));
            mp.AjouterOption(new MenuItem('M', "Modifier une entreprise de la liste en mémoire", Formulaire.ModifierUneEntreprise));

            mp.SaisirOption();


        }

        static void AfficherEntreprises()
        {
           U.Titre("Entreprise du Québec");

           if (Producteurs.Count == 0)
           {
                U.WL("Aucune entreprises n'est chargée");
           }
           else
           {
                U.WL($"Id Raison Sociale Domaine An F");
                U.WL($"{"ID".PadRight(6)}{"Nom".PadRight(45)}{"Domaine acti".PadRight(15)}{"An Fo".PadLeft(6)}{"Nb Trav".PadLeft(8)}\n" +
                    "___________________________________________________________________________________________________");

              foreach (Entreprise e in Producteurs)
              {
                 e.Afficher();
              }
           }
           U.P();
        }

        static void ValeurEnBourse()
        {
            U.Titre("Capitalisation boursière des entreprises");
            if (Producteurs.Count == 0)
            {
                U.WL("Aucune entreprise dans cette économie...");
                U.P();
                return;
            }
            
            U.Titre($"{"Raison sociale".PadRight(31)} {"Valeur (en million$)".PadLeft(21)}");
            foreach (Entreprise? e in Producteurs)
            {
                if (e is EntreprisePublique)
                {
                    EntreprisePublique? ep = e as EntreprisePublique;
                    if (ep is null)
                        continue;
                    double capBours = ep.ValeurUnitaire * ep.NbActionsEmises;
                    U.WL($"{ep.RaisonSociale.PadRight(31)} {(capBours/1000000).ToString("N2").PadLeft(21)}$");
                }
            }
            U.P();
        }

        
        static void TriValeurEnBourse()
        {
            U.Titre("Tri des capitalisations boursières");
            if (Producteurs.Count == 0)
            {
                U.WL("Aucune entreprise dans cette économie...");
                U.P();
                return;
            }

            List<EntreprisePublique> listeEP = new();
            foreach (Entreprise? e in Producteurs)
            {
                if (e is EntreprisePublique)
                {
                    EntreprisePublique? ep = e as EntreprisePublique;
                    if (ep is null) 
                        continue;   
                    listeEP.Add(ep);    
                }
            }

            listeEP.Sort(ComparerValeurBours); 

            U.Titre($"{"Raison sociale".PadRight(31)} {"Valeur (en million$)".PadLeft(21)}");
            foreach (EntreprisePublique e in listeEP)
            {
                  U.WL($"{e.RaisonSociale.PadRight(31)} {(e.ValeurBoursiere() / 1000000).ToString("N2").PadLeft(21)}$");
            }
            U.P();
        }

        static int ComparerValeurBours(EntreprisePublique e1, EntreprisePublique e2)
        {
            if (e1.ValeurBoursiere() > e2.ValeurBoursiere())
                return -1;
            if (e1.ValeurBoursiere() < e2.ValeurBoursiere())
                return 1;
            return 0;
        }

        static void RecupEmpEntrep()
        {
            U.Titre("chargement en mémoire des employés par leurs entreprises");
            foreach(Entreprise entrep in Producteurs)
            {
                entrep.RecupererPersonnel();    
            }
            U.P($"{"Chargements de la BD effectué"}");
        }

        static void AfficherUneEntreprise()
        {
            U.Titre("Info sur une entreprise");

            U.W("ID:");
            string? idStr = U.RL();
            int idEntrep = 0;


            if (idStr != null ) 
                idEntrep = int.Parse(idStr);

            foreach (Entreprise entrep in Producteurs)
            {
                if (idEntrep == entrep.Id)
                {
                    entrep.Afficher(false);
                }
            }
            U.P();
        }

        static void CalculerPaye()
        {
            U.Titre("Calcule de la paye d'une entreprise");

            U.W("Id de l'entrep:");
            string? idEntrepStr = U.RL();
            int idEntrep = 0;
            if (idEntrepStr != null)
            {
                idEntrep = int.Parse(idEntrepStr);
            }

            U.W("Période visée:");
            string?  perStr = U.RL();
            int periode = 0;
            if (perStr != null)
            {
                periode = int.Parse(perStr);
            }

            foreach(Entreprise e  in Producteurs)
            {
                if (e.Id == idEntrep)
                {
                    foreach (Employe emp in e.Personnel)
                    {
                        if (emp is EmpHoraire)
                        {
                            foreach (FeuilleTemps fdt in Horodateurs)
                            {
                                if (fdt.Periode == periode)
                                {
                                    if (fdt.IdEmploye == emp.id)
                                    {
                                        EmpHoraire? ep = emp as EmpHoraire;
                                        double sal = 0;
                                        if (ep != null)
                                        {
                                            sal = fdt.NbHeure * ep.TauxHoraire;
                                            U.WL($"{ep.id.ToString().PadLeft(6)} {ep.Nom.PadRight(40)} {sal.ToString("N2").PadLeft(10)}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            U.P();
        }

    }
}
