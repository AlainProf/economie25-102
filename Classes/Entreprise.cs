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
                U.WL($"{Id.ToString().PadLeft(6)} {RaisonSociale.PadRight(45)}{Domaine.PadRight(15)}{AnneeFondation.PadLeft(6)}{Personnel.Count.ToString().PadLeft(8)}");
            }
            else
            {
                U.WL( "Raison sociale : " + RaisonSociale);
                U.WL( "Domaine        : " + Domaine);
                U.WL( "Fondée en      : " + AnneeFondation);
                U.WL($"Emploie        : {Personnel.Count} travaileurs");
                U.WL($"Salaire/h moyen: {CalculerSalMoy().ToString("N2")}");

                U.W("Voulez voir les employés? (o/n)");
                char option = U.RC();
                if (option == 'o')
                {
                    foreach(Employe emp in Personnel)
                    {
                        emp.Afficher();
                    }
                }
            }
        }

        double CalculerSalMoy()
        {
            double salCum = 0;
            int nbEmp = 0;
            foreach(Employe e in Personnel)
            {
                if (e is EmpHoraire)
                {
                    nbEmp++;
                    EmpHoraire? eh = e as EmpHoraire;
                    if (eh != null)
                    {
                        salCum += eh.TauxHoraire;
                    }
                }
            }
            if (nbEmp > 0)
            {
                return salCum / nbEmp;
            }
            return 0;   
        }

        public void RecupererPersonnel()
        {
            foreach(Employe e in Program.Travailleurs)
            {
                if (e.idEntreprise == Id)
                {
                    Personnel.Add(e);
                }
            }
        }
    }
}
