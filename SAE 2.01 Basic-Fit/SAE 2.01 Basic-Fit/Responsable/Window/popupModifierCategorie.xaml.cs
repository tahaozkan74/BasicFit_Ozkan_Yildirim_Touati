using SAE_2._01_Basic_Fit.Models;
using System.Windows;

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    public partial class popupModifierCategorie : System.Windows.Window
    {
        public Categorie LaCategorie { get; set; }

        public popupModifierCategorie()
        {
            InitializeComponent();
        }

        // Constructeur qui reçoit la catégorie à modifier
        public popupModifierCategorie(Categorie uneCategorie)
        {
            InitializeComponent();
            LaCategorie = uneCategorie;

            txtNomCategorie.Text = uneCategorie.CategorieNom;
            txtDescription.Text = uneCategorie.CategorieDescription;
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
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LaCategorie.CategorieNom = txtNomCategorie.Text;
            LaCategorie.CategorieDescription = txtDescription.Text;

            this.DialogResult = true;
            this.Close();
        }
    }
}