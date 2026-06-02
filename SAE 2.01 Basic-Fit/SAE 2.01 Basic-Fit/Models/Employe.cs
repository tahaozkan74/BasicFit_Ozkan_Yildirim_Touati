using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Employe
    {
        private int employeId;
        private string nom;
        private string prenom;
        private string role;

        public int EmployeId 
        { 
            get => employeId; 
            set => employeId = value;
        }
        public string Nom 
        { 
            get => nom;
            set => nom = value;
        }
        public string Prenom 
        { 
            get => prenom;
            set => prenom = value;
        }
        public string Role 
        { 
            get => role;
            set => role = value; 
        }
    }
}
