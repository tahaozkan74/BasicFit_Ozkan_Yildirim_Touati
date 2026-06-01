using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Cours
    {
        private int coursId;
        private string coursNom;
        private string coursDescription;
        private bool disponible;                 
        private Categorie categorie;        
        private List<Seance> seances;

        public int CoursId 
        { 
            get => coursId; 
            set => coursId = value; 
        }
        public string CoursNom 
        { 
            get => coursNom;
            set => coursNom = value; 
        }
        public string CoursDescription
        { 
            get => coursDescription; 
            set => coursDescription = value; 
        }
        public bool Disponible 
        { 
            get => disponible;
            set => disponible = value;
        }
        public Categorie Categorie 
        { 
            get => categorie;
            set => categorie = value;
        }
        public List<Seance> Seances 
        {
            get => seances; 
            set => seances = value;
        }
    }
}
