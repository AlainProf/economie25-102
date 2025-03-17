using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.Classes
{
    internal class Entreprise
    {
        public int Id { get; set; } 
        public string RaisonSociale { get; set; }
        public string Domaine { get; set; }
        public List<Employe> Personnel { get; set; }


        public Entreprise(int i, string rs, string d)
        {
            Id = i;
            RaisonSociale = rs; 
            Domaine = d;
            Personnel = new List<Employe>();
        }

        public void Afficher()
        {
            U.WL($"{RaisonSociale}, emploie {Personnel.Count} travaileurs");
        }
    }
}
