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

        public string Poste { get; set; }   
    }
}
