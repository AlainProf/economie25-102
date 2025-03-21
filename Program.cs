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
            mp.AjouterOption(new MenuItem('P', "Calcul du PNB ", Chargement.ChargerEntreprises));
            mp.AjouterOption(new MenuItem('J', "Ajouter une entreprise", Chargement.ChargerEntreprises));

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



    }
}
