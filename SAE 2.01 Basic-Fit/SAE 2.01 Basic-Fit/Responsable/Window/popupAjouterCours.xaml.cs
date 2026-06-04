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
    /// Logique d'interaction pour popupAjouterCours.xaml
    /// </summary>
    public partial class popupAjouterCours : System.Windows.Window
    {
        public Cours LeCours { get; set; }

        public popupAjouterCours()
        {
            InitializeComponent();
            cbxCategorie.ItemsSource = new Categorie().FindAllAvecDetail();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Categorie catChoisie = (Categorie)cbxCategorie.SelectedItem;
            if (string.IsNullOrWhiteSpace(txtNomCours.Text)
                || catChoisie == null
                || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LeCours = new Cours(
                0,                       
                catChoisie.CategorieId,
                txtNomCours.Text,
                txtDescription.Text);
            LeCours.Categorie = catChoisie;

            this.DialogResult = true;
            this.Close();
        }
    }
}
