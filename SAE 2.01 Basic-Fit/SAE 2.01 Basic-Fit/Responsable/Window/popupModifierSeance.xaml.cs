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

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    /// <summary>
    /// Logique d'interaction pour popupModifierSeance.xaml
    /// </summary>
    public partial class popupModifierSeance : System.Windows.Window
    {
        public Seance LaSeance { get; set; }

        public popupModifierSeance()
        {
            InitializeComponent();
        }

        public popupModifierSeance(Seance uneSeance)
        {
            InitializeComponent();
            LaSeance = uneSeance;

            List<Cours> lesCours = new Cours().FindAll();
            List<Entraineur> lesEntraineurs = new Entraineur().FindAll();
            List<Salle> lesSalles = new Salle().FindAll();
            cbxCours.ItemsSource = lesCours;
            cbxEntraineur.ItemsSource = lesEntraineurs;
            cbxSalle.ItemsSource = lesSalles;

            foreach (Cours c in lesCours)
                if (c.CoursId == uneSeance.Cours.CoursId) { cbxCours.SelectedItem = c; break; }

            foreach (Entraineur en in lesEntraineurs)
                if (en.EntraineurId == uneSeance.Entraineur.EntraineurId) { cbxEntraineur.SelectedItem = en; break; }

            foreach (Salle sa in lesSalles)
                if (sa.SalleId == uneSeance.Salle.SalleId) { cbxSalle.SelectedItem = sa; break; }

            cbxJour.SelectedIndex = uneSeance.Jour - 1;

            txtHeureDebut.Text = uneSeance.HeureDebut.ToString("HH\\:mm");
            txtNbPlaces.Text = uneSeance.NbPlaces.ToString();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Cours c = (Cours)cbxCours.SelectedItem;
            Entraineur en = (Entraineur)cbxEntraineur.SelectedItem;
            Salle sa = (Salle)cbxSalle.SelectedItem;

            if (c == null || en == null || sa == null
                || string.IsNullOrWhiteSpace(txtHeureDebut.Text)
                || string.IsNullOrWhiteSpace(txtNbPlaces.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LaSeance.Cours = c;
            LaSeance.Entraineur = en;
            LaSeance.Salle = sa;
            LaSeance.Jour = cbxJour.SelectedIndex + 1;   
            LaSeance.HeureDebut = TimeOnly.Parse(txtHeureDebut.Text);
            LaSeance.HeureFin = LaSeance.HeureDebut.AddHours(1); 
            LaSeance.NbPlaces = int.Parse(txtNbPlaces.Text);

            this.DialogResult = true;
            this.Close();
        }
    }
}
