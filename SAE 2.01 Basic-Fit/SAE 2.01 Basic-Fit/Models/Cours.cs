using Npgsql;
using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Cours
    {
        private int coursId;
        private int categorieId;
        private string coursNom;
        private string coursDescription;

        public Cours()
        {

        }
        public Cours(int coursId, int categorieId, string coursNom, string coursDescription)
        {
            CoursId = coursId;
            CategorieId = categorieId;
            CoursNom = coursNom;
            CoursDescription = coursDescription;
        }

        public List<Cours> FindAll()
        {
            List<Cours> lesCours = new List<Cours>();
            using (NpgsqlCommand cmd = new NpgsqlCommand("select * from cours;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                    lesCours.Add(new Cours(
                        (int)dr["cours_id"],
                        (int)dr["categorie_id"],
                        (string)dr["cours_nom"],
                        (string)dr["cours_description"]));
            }
            return lesCours;
        }

        public int CoursId 
        { 
            get => coursId; 
            set => coursId = value;
        }
        public int CategorieId 
        { 
            get => categorieId; 
            set => categorieId = value;
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
    }
}
