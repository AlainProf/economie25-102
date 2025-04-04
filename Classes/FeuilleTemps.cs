using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class FeuilleTemps
    {
        public int Id { get; set; } 
        public int IdEmploye { get; set; }  
        public int Periode {  get; set; }   
        public int NbHeure {  get; set; }

        public FeuilleTemps()
        {
            Id = 0;
            IdEmploye = 0;
            Periode = -1;
            NbHeure = 0;
        }
        public FeuilleTemps(int i, int idEmp, int p, int nbH)
        {
            Id = i;
            IdEmploye = idEmp;
            Periode = p;
            NbHeure = nbH;
        }
    }
}
