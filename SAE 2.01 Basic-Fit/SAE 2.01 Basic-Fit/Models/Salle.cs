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
    public class Salle
    {
        private int salleId;
        private string salleNom;
        private int salleNbPlaces;

        public Salle()
        {
        }

        public Salle(int salleId, string salleNom, int salleNbPlaces)
        {
            SalleId = salleId;
            SalleNom = salleNom;
            SalleNbPlaces = salleNbPlaces;
        }

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
        public List<Salle> FindAll()
        {
            List<Salle> lesSalles = new List<Salle>();
            using (NpgsqlCommand cmd = new NpgsqlCommand("select * from salle;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                    lesSalles.Add(new Salle(
                    (int)dr["salle_id"],
                    (string)dr["salle_nom"],
                    (int)dr["salle_nb_places"]));
            }
            return lesSalles;
        }
    }
}
