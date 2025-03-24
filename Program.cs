using Economie102.Classes;
using Economie102.ClassesUtilitaires;


namespace Economie102
{
    internal class Program
    {
        static public List<Entreprise> Producteurs { get; set; } = new List<Entreprise>();  
        static void Main(string[] args)
        {
            U.Titre("Analyse économique gr 102");
            Menu mp = new("Menu principal");
            mp.AjouterOption(new MenuItem('C', "Charger les entreprises en mémoire", Chargement.ChargerEntreprises));
            mp.AjouterOption(new MenuItem('A', "Afficher les entreprises", AfficherEntreprises));
            mp.AjouterOption(new MenuItem('V', "Valeurs des capitalisations boursières ", ValeurEnBourse));
            mp.AjouterOption(new MenuItem('T', "Trier les valeurs des capitalisations boursières ", TriValeurEnBourse));
            mp.AjouterOption(new MenuItem('J', "Ajouter une entreprise", Formulaire.AjouterEntreprise));
            mp.AjouterOption(new MenuItem('S', "Sauvergarder la liste en BD", GestionnaireBD.EnregistrerListeEntreprises));

            mp.Afficher();
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
                U.WL($"{"ID".PadRight(6)}{"Nom".PadRight(45)}{"Domaine acti".PadRight(15)}{"An Fo".PadLeft(6)}\n" +
                    "______________________________________________________________________");


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



    }
}
