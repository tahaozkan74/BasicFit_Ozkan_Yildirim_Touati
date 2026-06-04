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
    public class Categorie
    {
        private int categorieId;
        private string categorieNom;
        private string categorieDescription;
        private List<Cours> listeCours;
        private int nbCours;
        public Categorie()
        {
        }
        public Categorie(int categorieId, string categorieNom, string categorieDescription)
        {
            CategorieId = categorieId;
            CategorieNom = categorieNom;
            CategorieDescription = categorieDescription;
        }
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
        public int NbCours
        {
            get => nbCours;
            set => nbCours = value;
        }
        public List<Categorie> FindAllAvecDetail()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            string sql = @"SELECT cat.categorie_id,
                                  cat.categorie_nom,
                                  cat.categorie_description,
                                  COUNT(c.cours_id) AS nb_cours
                           FROM categorie cat
                           LEFT JOIN cours c ON c.categorie_id = cat.categorie_id
                           GROUP BY cat.categorie_id, cat.categorie_nom, cat.categorie_description
                           ORDER BY cat.categorie_nom;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    Categorie cat = new Categorie(
                        (int)dr["categorie_id"],
                        (string)dr["categorie_nom"],
                        (string)dr["categorie_description"]);
                    cat.NbCours = Convert.ToInt32(dr["nb_cours"]);
                    lesCategories.Add(cat);
                }
            }
            return lesCategories;
        }
    }
}