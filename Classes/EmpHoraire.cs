using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class EmpHoraire: Employe
    {
        public double TauxHoraire {  get; set; }   
        
        public EmpHoraire()
        {
            Nom = "inconnu";
            Naissance = DateTime.MinValue;
            Genre = "f";
            id = 0;
            idEntreprise = 0;   
            TauxHoraire = 0;    
        }

        public EmpHoraire(string n, DateTime nais, string g, int idEmp, int idEntrep, double th):
               base(n, nais, g, idEmp, idEntrep)
        {
            TauxHoraire = th ;
        }

        public override void Afficher()
        {
            U.WL($"{id} {Nom} {TauxHoraire}$");
        }
    }
}
