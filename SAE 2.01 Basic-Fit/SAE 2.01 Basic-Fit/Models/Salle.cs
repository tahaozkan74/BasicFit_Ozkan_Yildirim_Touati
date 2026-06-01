using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Salle
    {
        private int salleId;
        private string salleNom;
        private int salleNbPlaces;
        private List<Seance> seances;

        public int SalleId 
        { 
            get => salleId; 
            set => salleId = value;
        }
        public string SalleNom 
        {
            get => salleNom;
            set => salleNom = value; 
        }
        public int SalleNbPlaces 
        { 
            get => salleNbPlaces; 
            set => salleNbPlaces = value;
        }
        public List<Seance> Seances 
        { 
            get => seances;
            set => seances = value; 
        }
    }
}
