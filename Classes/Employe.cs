using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class Employe: Humain
    {
        public int id {  get; set; }    
        public int idEntreprise { get; set; }   

        public string? Poste { get; set; }

        public Employe()
        {
            Nom = "incognito";
            Naissance = DateTime.MaxValue;
            Genre = "m";
            id = 0;
            idEntreprise = 0;
        }
        public Employe(string n, DateTime nais, string g, int idEmp, int idEntrep): base(n, nais, g)
        {
            id = idEmp;
            idEntreprise = idEntrep;
        }
    }
}
