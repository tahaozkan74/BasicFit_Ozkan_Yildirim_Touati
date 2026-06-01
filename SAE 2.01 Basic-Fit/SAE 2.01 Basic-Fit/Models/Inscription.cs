using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Inscription
    {
        private DateTime dateInscription;
        private Client client;                     
        private Seance seance;

        public DateTime DateInscription 
        {
            get => dateInscription; 
            set => dateInscription = value;
        }
        public Client Client 
        { 
            get => client;
            set => client = value;
        }
        public Seance Seance 
        { 
            get => seance; 
            set => seance = value;
        }
    }
}
