using SAE_2._01_Basic_Fit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE_2._01_Basic_Fit.Employe.Window
{
    /// <summary>
    /// Logique d'interaction pour popupDetailCours.xaml
    /// </summary>
    public partial class popupDetailCours : System.Windows.Window
    {
        public popupDetailCours()
        {
            InitializeComponent();
        }

        public popupDetailCours(Seance uneSeance)
        {
            InitializeComponent();

            txtTitre.Text = uneSeance.Cours.CoursNom + " - " + uneSeance.HeureDebut.ToString("HH\\:mm");

            txtCategorie.Text = uneSeance.Cours.Categorie != null ? uneSeance.Cours.Categorie.CategorieNom : "";
            txtDescription.Text = uneSeance.Cours.CoursDescription;
            txtSalle.Text = uneSeance.Salle.SalleNom;
            txtEntraineur.Text = uneSeance.Entraineur.EntraineurPrenom + " " + uneSeance.Entraineur.EntraineurNom;
            txtPlaces.Text = uneSeance.NbPlaces.ToString();

            List<Client> participants = new Client().FindParticipants(uneSeance.SeanceId);
            dgParticipants.ItemsSource = participants;
            txtNbParticipants.Text = "👥 Participants (" + participants.Count + ")";
        }
        private void butFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
