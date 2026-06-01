using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Entraineur
    {
        private int entraineurId;
        private string entraineurNom;
        private string entraineurPrenom;
        private List<Seance> seances;

        public int EntraineurId 
        {
            get => entraineurId; 
            set => entraineurId = value; 
        }
        public string EntraineurNom 
        {
            get => entraineurNom;
            set => entraineurNom = value;
        }
        public string EntraineurPrenom
        {
            get => entraineurPrenom;
            set => entraineurPrenom = value; 
        }
        public List<Seance> Seances
        {
            get => seances; 
            set => seances = value; 
        }
    }
}
