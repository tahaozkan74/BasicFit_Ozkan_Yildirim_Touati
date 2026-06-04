using SAE_2._01_Basic_Fit.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    public partial class popupAjouterSeance : System.Windows.Window
    {
        public Seance LaSeance { get; set; }

        public popupAjouterSeance()
        {
            InitializeComponent();

            cbxCours.ItemsSource = new Cours().FindAll();
            cbxEntraineur.ItemsSource = new Entraineur().FindAll();
            cbxSalle.ItemsSource = new Salle().FindAll();
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
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TimeOnly hDebut = TimeOnly.Parse(txtHeureDebut.Text);
            LaSeance = new Seance(
                0,                         
                hDebut,
                hDebut.AddHours(1),        
                int.Parse(txtNbPlaces.Text),
                c, sa, en);
            LaSeance.Jour = cbxJour.SelectedIndex + 1;

            this.DialogResult = true;
            this.Close();
        }
    }
}