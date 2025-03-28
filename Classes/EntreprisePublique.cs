using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class EntreprisePublique : Entreprise
    {
        public double ValeurUnitaire;
        public long NbActionsEmises;

        public EntreprisePublique(int i, string rs, string d, double valA, long nbA,string af) : base(i, rs, d, af)
        {
            ValeurUnitaire = valA;
            NbActionsEmises = nbA;
        }
        public EntreprisePublique(string rs, string d, double valA, long nbA, string af) : base(rs, d, af)
        {
            ValeurUnitaire = valA;
            NbActionsEmises = nbA;
        }

        public double ValeurBoursiere()
        {
            return ValeurUnitaire * NbActionsEmises;  
        }

    }
}
