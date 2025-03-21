using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.ClassesUtilitaires
{
    internal class Menu
    {
        public string Nom {  get; set; }    
        public List<MenuItem> Items { get; set; }

        public Menu(string nom)
        {
            Nom = nom;
            Items = new List<MenuItem>();
        }   

        public void AjouterOption(MenuItem o)
        {
            Items.Add(o);   
        }

        public void Afficher()
        {
            U.Titre(Nom);
            foreach(MenuItem mi in Items)
            {
                U.WL("\t" + mi.Cle + ": " + mi.Nom);
            }

            U.WL("\n\nEsc pour quitter...");
        }

        public void SaisirOption()
        {
            ConsoleKeyInfo cle;
            while ((cle = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                foreach (MenuItem mi in Items)
                {
                    if ((char)cle.Key == mi.Cle)
                    {
                        U.CLS();
                        mi.Execution();
                        Afficher();
                    }
                }
            }
        }
    }
}
