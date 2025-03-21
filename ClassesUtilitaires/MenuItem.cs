using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie102.ClassesUtilitaires
{
    internal class MenuItem
    {
        public char Cle {  get; set; }  
        public string Nom {  get; set; }   
        public Action Execution {  get; set; }  

        public MenuItem(char c, string n, Action exe)
        {
            Cle = c;
            Nom = n;
            Execution = exe;
        }   
    }
}
