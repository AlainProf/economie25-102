using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102
{
    internal class U
    {
        public const string FICHIER_ENTREPRISE = "d:\\alino\\atelier\\economie\\entreprises.csv";
        public const string FICHIER_EMPLOYES = "d:\\alino\\atelier\\economie\\employes.csv";
        
        public static void WL(string s= "")
        {
            Console.WriteLine(s);
        }
        public static void W(string s)
        {
            Console.Write(s);
        }
        public static void P(string msg="")
        {
            WL("\n\n" + msg);
            W("Appuyez sur une touche...");
            Console.ReadLine();
        }

        public static void CLS()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
        public static void Titre(string t, bool cls=true)
        {
            if (cls)
            {
                U.CLS();
            }
            foreach (Char c in t)
            {
                W("-");
            }
            WL("\n" + t);
            foreach (Char c in t)
            {
                W("-");
            }
            WL();
        }

        public static string? RL()
        {
            return Console.ReadLine();
        }
        public static char RC()
        {
            ConsoleKeyInfo cle = Console.ReadKey();
            return cle.KeyChar;
        }

    }
}
