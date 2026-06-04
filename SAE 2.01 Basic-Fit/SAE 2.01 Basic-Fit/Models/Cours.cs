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
        private Categorie categorie;
        private int nbSeances;

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

        public Cours(int coursId, int categorieId, string coursNom, string coursDescription, Categorie categorie, int nbSeances)
        {
            CoursId = coursId;
            CategorieId = categorieId;
            CoursNom = coursNom;
            CoursDescription = coursDescription;
            Categorie = categorie;
            NbSeances = nbSeances;
        }

        public int CoursId { get => coursId; set => coursId = value; }
        public int CategorieId { get => categorieId; set => categorieId = value; }
        public string CoursNom { get => coursNom; set => coursNom = value; }
        public string CoursDescription { get => coursDescription; set => coursDescription = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }
        public int NbSeances { get => nbSeances; set => nbSeances = value; }

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

        public List<Cours> FindAllAvecDetail()
        {
            List<Cours> lesCours = new List<Cours>();
            string sql = @"SELECT c.cours_id,
                          c.cours_nom,
                          c.cours_description,
                          cat.categorie_id,
                          cat.categorie_nom,
                          cat.categorie_description,
                          COUNT(s.seance_id) AS nb_seances
                   FROM cours c
                   JOIN categorie cat ON c.categorie_id = cat.categorie_id
                   LEFT JOIN seance s ON s.cours_id = c.cours_id
                   GROUP BY c.cours_id, c.cours_nom, c.cours_description,
                            cat.categorie_id, cat.categorie_nom, cat.categorie_description
                   ORDER BY c.cours_nom;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    Cours c = new Cours(
                        (int)dr["cours_id"],
                        (int)dr["categorie_id"],
                        (string)dr["cours_nom"],
                        (string)dr["cours_description"]);
                    c.Categorie = new Categorie(
                        (int)dr["categorie_id"],
                        (string)dr["categorie_nom"],
                        (string)dr["categorie_description"]);
                    c.NbSeances = Convert.ToInt32(dr["nb_seances"]);
                    lesCours.Add(c);
                }
            }
            return lesCours;
        }
    }
}