using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class Humain
    {
        public DateTime Naissance { get; set; }

        public string Genre { get; set; }
        public string Nom { get; set; }

    
        //---------------------------------------------
        //
        //---------------------------------------------
        public Humain()
        {
            Nom = "inconnu";
            Naissance = new DateTime(1, 1, 1);
            Genre = "F";
         }

        //---------------------------------------------
        //
        //---------------------------------------------
        public Humain(string n)
        {
            Nom = n;
            Naissance = DateTime.Now;
            Genre = "F";
        }
        //---------------------------------------------
        //
        //---------------------------------------------
        public Humain(string n, DateTime nais)
        {
            Nom = n;
            Naissance = nais;
            Genre = "F";
        }
        //---------------------------------------------
        //
        //---------------------------------------------
        public Humain(string n, DateTime nais, string g)
        {
            //_u.Sep("Cons Humain 3 param");
            Nom = n;
            Naissance = nais;
            Genre = g;
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public virtual void Afficher()
        {
            Console.Write($"{Nom}, {Age()} ans");
        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public long Age()
        {
            DateTime mtn = DateTime.Now;
            long ndSec = (mtn.Ticks - Naissance.Ticks) / (10000000);
            long an = ndSec / (long)(60 * 60 * 24 * 365.24);
            return an;

        }

        //---------------------------------------------
        //
        //---------------------------------------------
        public static int ComparerNom(Humain a, Humain b)
        {
            return (a.Nom.CompareTo(b.Nom));
        }

        public static int ComparerAge(Humain a, Humain b)
        {
            if (a.Age() > b.Age())
                return 1;
            if (a.Age() < b.Age())
                return -1;
            return 0;
        }
    }
}
