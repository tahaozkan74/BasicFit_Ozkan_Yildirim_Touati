using Npgsql;
using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_Basic_Fit.Models
{
    public class Client
    {
        private int clientId;
        private Abonnement abonnement;
        private string nom;
        private string prenom;
        private string mail;
        private string telephone;
        private DateOnly dateNaissance;
        private string adresse;
        private string codePostal;
        private string ville;

        public Client() { }

        public Client(int clientId, Abonnement abonnement, string nom, string prenom, string mail, string telephone, DateOnly dateNaissance, string adresse, string codePostal, string ville)
        {
            ClientId = clientId;
            Abonnement = abonnement;
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            Telephone = telephone;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
        }

        public int ClientId { get => clientId; set => clientId = value; }
        public Abonnement Abonnement { get => abonnement; set => abonnement = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateOnly DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }

        public int Age
        {
            get
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - dateNaissance.Year;
                if (dateNaissance > today.AddYears(-age))
                    age--;
                return age;
            }
        }

        public string AgeAffiche => $"{this.Age} ans ({CategorieAge()})";

        public List<Client> FindAll()
        {
            List<Client> lesClients = new List<Client>();
            using (NpgsqlCommand cmd = new NpgsqlCommand("select * from client order by nom;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    lesClients.Add(new Client(
                        (int)dr["client_id"],
                        null,
                        (string)dr["nom"],
                        (string)dr["prenom"],
                        (string)dr["mail"],
                        (string)dr["telephone"],
                        (DateOnly)dr["date_naissance"],
                        dr["adresse"] == DBNull.Value ? "" : (string)dr["adresse"],
                        dr["code_postal"] == DBNull.Value ? "" : (string)dr["code_postal"],
                        dr["ville"] == DBNull.Value ? "" : (string)dr["ville"]));
                }
            }
            return lesClients;
        }
    
        public string CategorieAge()
        {
            if (this.Age <= 25)
            {
                return "Jeune";
            }
            else if (this.Age > 26 && this.Age <= 65)
            {
                return "Adulte";
            }
            else 
            {
                return "Senior";
            }
            
        }

        public List<Client> FindParticipants(int seanceId)
        {
            List<Client> lesClients = new List<Client>();
            string sql = @"SELECT c.client_id, c.nom, c.prenom, c.mail, c.telephone, c.date_naissance,
                          c.adresse, c.code_postal, c.ville
                   FROM client c
                   JOIN inscription i ON i.client_id = c.client_id
                   WHERE i.seance_id = @seanceId
                   ORDER BY c.nom;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("seanceId", seanceId);
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    lesClients.Add(new Client(
                        (int)dr["client_id"],
                        null,
                        (string)dr["nom"],
                        (string)dr["prenom"],
                        (string)dr["mail"],
                        (string)dr["telephone"],
                        (DateOnly)dr["date_naissance"],
                        dr["adresse"] == DBNull.Value ? "" : (string)dr["adresse"],
                        dr["code_postal"] == DBNull.Value ? "" : (string)dr["code_postal"],
                        dr["ville"] == DBNull.Value ? "" : (string)dr["ville"]));
                }
            }
            return lesClients;
        }

        public int Create()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(
                "insert into client (nom, prenom, mail, telephone, date_naissance, adresse, code_postal, ville) values (@nom, @prenom, @mail, @tel, @dateN, @adr, @cp, @ville) returning client_id;"))
            {
                cmd.Parameters.AddWithValue("nom", this.Nom);
                cmd.Parameters.AddWithValue("prenom", this.Prenom);
                cmd.Parameters.AddWithValue("mail", this.Mail);
                cmd.Parameters.AddWithValue("tel", this.Telephone);
                cmd.Parameters.AddWithValue("dateN", this.DateNaissance);
                cmd.Parameters.AddWithValue("adr", this.Adresse);
                cmd.Parameters.AddWithValue("cp", this.CodePostal);
                cmd.Parameters.AddWithValue("ville", this.Ville);
                return Convert.ToInt32(DataAccess.ExecuteSelectUneValeur(cmd));
            }
        }
    }       
}
