using Economie102.Classes;

namespace Economie102
{
    internal class Program
    {
        static void Main(string[] args)
        {
            U.Titre("Analyse économique gr 102");

            Entreprise e1 = new Entreprise(1, "Microsoft", "Informatique");
            e1.Afficher();
            U.P();
        }
    }
}
