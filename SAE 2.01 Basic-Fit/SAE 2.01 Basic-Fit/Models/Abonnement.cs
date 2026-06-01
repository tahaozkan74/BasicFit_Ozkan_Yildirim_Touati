using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Abonnement
    {
        private int abonnementId;
        private string abonnementDescription;
        private decimal tarif;
        private List<Client> clients;

        public int AbonnementId 
        { 
            get => abonnementId; 
            set => abonnementId = value;
        }
        public string AbonnementDescription 
        {
            get => abonnementDescription;
            set => abonnementDescription = value;
        }
        public decimal Tarif 
        {
            get => tarif;
            set => tarif = value;
        }
        public List<Client> Clients 
        { 
            get => clients;
            set => clients = value;
        }
    }
}
