using SAE_2._01_Basic_Fit.Models;
using System.Windows;

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    public partial class popupAjouterCategorie : System.Windows.Window
    {
        public Categorie LaCategorie { get; set; }

        public popupAjouterCategorie()
        {
            InitializeComponent();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomCategorie.Text)
                || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            LaCategorie = new Categorie(
                0,                      
                txtNomCategorie.Text,
                txtDescription.Text);

            this.DialogResult = true;
            this.Close();
        }
    }
}