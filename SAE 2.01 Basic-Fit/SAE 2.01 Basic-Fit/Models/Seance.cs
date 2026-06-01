using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Seance
    {
        private int seanceId;
        private string jour;
        private TimeSpan heureDebut;
        private TimeSpan heureFin;
        private int nbPlaces;
        private bool complet;
        private Cours cours;                        
        private Salle salle;                       
        private Entraineur entraineur;              
        private List<Inscription> inscriptions;

        public int SeanceId 
        { 
            get => seanceId;
            set => seanceId = value;
        }
        public string Jour 
        {
            get => jour; 
            set => jour = value; 
        }
        public TimeSpan HeureDebut 
        { 
            get => heureDebut; 
            set => heureDebut = value;
        }
        public TimeSpan HeureFin {
            get => heureFin;
            set => heureFin = value;
        }
        public int NbPlaces 
        { 
            get => nbPlaces; 
            set => nbPlaces = value;
        }
        public bool Complet 
        { 
            get => complet;
            set => complet = value;
        }
        public Cours Cours 
        { 
            get => cours; 
            set => cours = value;
        }
        public Salle Salle
        {
            get => salle;
            set => salle = value;
        }
        public Entraineur Entraineur
        { 
            get => entraineur;
            set => entraineur = value;
        }
        public List<Inscription> Inscriptions 
        {
            get => inscriptions; 
            set => inscriptions = value; 
        }
    }
}
