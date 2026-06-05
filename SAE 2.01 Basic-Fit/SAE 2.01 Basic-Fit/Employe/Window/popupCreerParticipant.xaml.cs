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
    /// Logique d'interaction pour popupCreerParticipant.xaml
    /// </summary>
    public partial class popupCreerParticipant : System.Windows.Window
    {
        public Client LeClient { get; set; }

        public popupCreerParticipant()
        {
            InitializeComponent();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void butCreer_Click(object sender, RoutedEventArgs e)
        {
            // Vérification : tous les champs remplis (la date doit être choisie)
            if (string.IsNullOrWhiteSpace(txtNom.Text)
                || string.IsNullOrWhiteSpace(txtPrenom.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtTelephone.Text)
                || dpDateNaissance.SelectedDate == null
                || string.IsNullOrWhiteSpace(txtAdresse.Text)
                || string.IsNullOrWhiteSpace(txtCodePostal.Text)
                || string.IsNullOrWhiteSpace(txtVille.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Le DatePicker renvoie un DateTime?, on convertit en DateOnly
            DateOnly dateN = DateOnly.FromDateTime(dpDateNaissance.SelectedDate.Value);

            LeClient = new Client(
                0,                          // id donné par Create
                null,                       // abonnement (NULL)
                txtNom.Text,
                txtPrenom.Text,
                txtEmail.Text,
                txtTelephone.Text,
                dateN,
                txtAdresse.Text,
                txtCodePostal.Text,
                txtVille.Text);

            this.DialogResult = true;
            this.Close();
        }
    }
}
