using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Categorie
    {
        private int categorieId;
        private string categorieNom;
        private string categorieDescription;
        private List<Cours> listeCours;

        public int CategorieId 
        { 
            get => categorieId;
            set => categorieId = value; 
        }
        public string CategorieNom 
        { 
            get => categorieNom;
            set => categorieNom = value;
        }
        public string CategorieDescription 
        { 
            get => categorieDescription; 
            set => categorieDescription = value; 
        }
        public List<Cours> ListeCours 
        { 
            get => listeCours; 
            set => listeCours = value;
        }
    }
}
