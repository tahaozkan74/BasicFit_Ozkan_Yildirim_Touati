using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Client
    {
        private int clientId;
        private string nom;
        private string prenom;
        private string mail;
        private string telephone;
        private DateTime dateNaissance;
        private string adresse;
        private string codePostal;
        private string ville;
        private Abonnement abonnement;
        private List<Inscription> inscriptions;

        public int ClientId 
        { 
            get => clientId; 
            set => clientId = value; 
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
        public string Mail 
        { 
            get => mail;
            set => mail = value; 
        }
        public string Telephone 
        { 
            get => telephone; 
            set => telephone = value; 
        }
        public DateTime DateNaissance 
        { 
            get => dateNaissance; 
            set => dateNaissance = value; 
        }
        public string Adresse 
        { 
            get => adresse; 
            set => adresse = value; 
        }
        public string CodePostal 
        { 
            get => codePostal;
            set => codePostal = value;
        }
        public string Ville 
        { 
            get => ville; 
            set => ville = value;
        }
        public Abonnement Abonnement 
        { 
            get => abonnement; 
            set => abonnement = value; 
        }
        public List<Inscription> Inscriptions
        { 
            get => inscriptions; 
            set => inscriptions = value; 
        }
    }
}
