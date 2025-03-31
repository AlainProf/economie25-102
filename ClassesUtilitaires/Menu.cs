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

        bool _top;

        public Menu(string nom, bool top=true)
        {
            Nom = nom;
            Items = new List<MenuItem>();
            _top = top;
        }   

        public void AjouterOption(MenuItem o)
        {
            Items.Add(o);   
        }

        public void Afficher()
        {
            U.Titre(Nom, _top);
            foreach(MenuItem mi in Items)
            {
                U.WL("\t" + mi.Cle + ": " + mi.Nom);
            }
            if (_top)
            {
                U.WL("\n\nEsc pour quitter...");
            }
        }

        public void SaisirOption()
        {
            ConsoleKeyInfo cle;
            Afficher();
            while ((cle = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                foreach (MenuItem mi in Items)
                {
                    if ((char)cle.Key == mi.Cle)
                    {
                        if (_top)
                        {
                            U.CLS();
                        }
                        mi.Execution();
                        if (_top)
                        {
                            Afficher();
                        }
                    }
                }
                if (!_top)
                    break;
            }
        }
    }
}
