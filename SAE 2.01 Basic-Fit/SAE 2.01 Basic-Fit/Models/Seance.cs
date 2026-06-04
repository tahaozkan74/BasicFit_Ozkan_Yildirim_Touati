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
    public class Seance
    {
        private int seanceId;
        private TimeOnly heureDebut;
        private TimeOnly heureFin;
        private int nbPlaces;
        private Cours cours;
        private Salle salle;
        private Entraineur entraineur;
        private int jour;
        public Seance() { }
        public Seance(int seanceId, TimeOnly heureDebut, TimeOnly heureFin, int nbPlaces, Cours cours, Salle salle, Entraineur entraineur)
        {
            SeanceId = seanceId;
            HeureDebut = heureDebut;
            HeureFin = heureFin;
            NbPlaces = nbPlaces;
            Cours = cours;
            Salle = salle;
            Entraineur = entraineur;
        }
        public int SeanceId { get => seanceId; set => seanceId = value; }
        public TimeOnly HeureDebut { get => heureDebut; set => heureDebut = value; }
        public TimeOnly HeureFin { get => heureFin; set => heureFin = value; }
        public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
        public Cours Cours { get => cours; set => cours = value; }
        public Salle Salle { get => salle; set => salle = value; }
        public Entraineur Entraineur { get => entraineur; set => entraineur = value; }
        public int Jour { get => jour; set => jour = value; }
        public string JourNom
        {
            get
            {
                string[] jours = { "", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
                return (jour >= 1 && jour <= 7) ? jours[jour] : "";
            }
        }
        public List<Seance> FindAll()
        {
            List<Seance> lesSeances = new List<Seance>();
            string sql = @"SELECT s.seance_id, s.heure_debut, s.heure_fin, s.nb_places,
                                  c.cours_id, c.cours_nom,
                                  sa.salle_id, sa.salle_nom,
                                  e.entraineur_id, e.entraineur_nom, e.entraineur_prenom
                           FROM seance s
                           JOIN cours c       ON s.cours_id = c.cours_id
                           JOIN salle sa      ON s.salle_id = sa.salle_id
                           JOIN entraineur e  ON s.entraineur_id = e.entraineur_id
                           WHERE s.jour = 1
                           ORDER BY s.heure_debut;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    Cours c = new Cours((int)dr["cours_id"], 0, (string)dr["cours_nom"], "");
                    Salle sa = new Salle((int)dr["salle_id"], (string)dr["salle_nom"], 0);
                    Entraineur e = new Entraineur((int)dr["entraineur_id"], (string)dr["entraineur_nom"], (string)dr["entraineur_prenom"]);
                    lesSeances.Add(new Seance(
                        (int)dr["seance_id"],
                        (TimeOnly)dr["heure_debut"],
                        (TimeOnly)dr["heure_fin"],
                        (int)dr["nb_places"],
                        c, sa, e));
                }
            }
            return lesSeances;
        }
        public List<Seance> FindAllSeances()
        {
            List<Seance> lesSeances = new List<Seance>();
            string sql = @"SELECT s.seance_id, s.jour, s.heure_debut, s.heure_fin, s.nb_places,
                                  c.cours_id, c.cours_nom,
                                  sa.salle_id, sa.salle_nom,
                                  e.entraineur_id, e.entraineur_nom, e.entraineur_prenom
                           FROM seance s
                           JOIN cours c       ON s.cours_id = c.cours_id
                           JOIN salle sa      ON s.salle_id = sa.salle_id
                           JOIN entraineur e  ON s.entraineur_id = e.entraineur_id
                           ORDER BY s.jour, s.heure_debut;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    Cours c = new Cours((int)dr["cours_id"], 0, (string)dr["cours_nom"], "");
                    Salle sa = new Salle((int)dr["salle_id"], (string)dr["salle_nom"], 0);
                    Entraineur e = new Entraineur((int)dr["entraineur_id"], (string)dr["entraineur_nom"], (string)dr["entraineur_prenom"]);
                    Seance se = new Seance(
                        (int)dr["seance_id"],
                        (TimeOnly)dr["heure_debut"],
                        (TimeOnly)dr["heure_fin"],
                        (int)dr["nb_places"],
                        c, sa, e);
                    se.Jour = (int)dr["jour"];
                    lesSeances.Add(se);
                }
            }
            return lesSeances;
        }
        public string Horaire => $"{heureDebut:HH\\:mm} - {HeureFin:HH\\:mm}";
    }
}