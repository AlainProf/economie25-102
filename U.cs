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
        public static void Titre(string t)
        {
            U.CLS();
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

    }
}
