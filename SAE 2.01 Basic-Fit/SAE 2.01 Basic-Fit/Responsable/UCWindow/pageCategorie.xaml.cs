using SAE_2._01_Basic_Fit.Models;
using SAE_2._01_Basic_Fit.Responsable.Window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_2._01_Basic_Fit.Responsable.UCWindow
{
    /// <summary>
    /// Logique d'interaction pour pageCategorie.xaml
    /// </summary>
    public partial class pageCategorie : UserControl
    {
        public pageCategorie()
        {
            InitializeComponent();
            dgCategorie.ItemsSource = new Categorie().FindAllAvecDetail();
        }

        private void butNouvelleCategorie_Click(object sender, RoutedEventArgs e)
        {
            popupAjouterCategorie popup = new popupAjouterCategorie();
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    popup.LaCategorie.CategorieId = popup.LaCategorie.Create();  

                    List<Categorie> liste = (List<Categorie>)dgCategorie.ItemsSource;
                    liste.Add(popup.LaCategorie);
                    dgCategorie.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La catégorie n'a pas pu être créée.", "Attention",  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            Categorie categorieSelectionnee = (Categorie)bouton.DataContext;

            // Copie (on ne modifie pas l'original tant que pas validé)
            Categorie copie = new Categorie(
                categorieSelectionnee.CategorieId,
                categorieSelectionnee.CategorieNom,
                categorieSelectionnee.CategorieDescription);

            popupModifierCategorie popup = new popupModifierCategorie(copie);
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    copie.Update();  

                    categorieSelectionnee.CategorieNom = copie.CategorieNom;
                    categorieSelectionnee.CategorieDescription = copie.CategorieDescription;

                    dgCategorie.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La catégorie n'a pas pu être modifiée.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
