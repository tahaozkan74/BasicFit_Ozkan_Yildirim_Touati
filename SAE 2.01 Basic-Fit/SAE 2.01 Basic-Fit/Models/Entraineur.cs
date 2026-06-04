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
    public class Entraineur
    {
        private int entraineurId;
        private string entraineurNom;
        private string entraineurPrenom;

        public Entraineur(int entraineurId, string entraineurNom, string entraineurPrenom)
        {
            EntraineurId = entraineurId;
            EntraineurNom = entraineurNom;
            EntraineurPrenom = entraineurPrenom;
        }

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

        public List<Entraineur> FindAll()
        {
            List<Entraineur> lesEntraineur = new List<Entraineur>();
            using (NpgsqlCommand cmd = new NpgsqlCommand("select * from entraineur;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                    lesEntraineur.Add(new Entraineur(
                    (int)dr["entraineur_id"],
                    (string)dr["entraineur_nom"],
                    (string)dr["entraineur_prenom"]));
            }
            return lesEntraineur;
        }
    }
}
