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
        public string AnneeFondation { get; set; }
        public List<Employe> Personnel { get; set; }

        static int _maxIdEnCours = 0;


        public Entreprise(int i = 0, string rs = "inconnu", string d = "inconnu", string af = "1608")
        {
            Id = i;
            if (Id > _maxIdEnCours)
            {
                _maxIdEnCours = Id;
            }
            RaisonSociale = rs;
            Domaine = d;
            AnneeFondation = af;
            Personnel = new List<Employe>();
        }
        public Entreprise(string rs, string d, string af)
        {
            _maxIdEnCours++;
            Id = _maxIdEnCours;
            RaisonSociale = rs;
            Domaine = d;
            AnneeFondation = af;
            Personnel = new List<Employe>();
        }

        public void Afficher(bool tabulaire = true)
        {
            if (tabulaire)
            {
                StringBuilder sb = new StringBuilder();
                U.WL($"{Id.ToString().PadLeft(6)} {RaisonSociale.PadRight(45)}{Domaine.PadRight(15)}{AnneeFondation.PadLeft(6)}");
            }
            else
            {
                U.WL("Raison sociale:" + RaisonSociale);
                U.WL("Domaine       :" + Domaine);
                U.WL("Fondée en     :" + AnneeFondation);
            }
        }
    }
}
