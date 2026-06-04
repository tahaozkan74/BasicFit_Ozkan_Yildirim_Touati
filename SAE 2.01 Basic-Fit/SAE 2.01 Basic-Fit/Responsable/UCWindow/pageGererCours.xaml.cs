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
    /// Logique d'interaction pour pageGererCours.xaml
    /// </summary>
    public partial class pageGererCours : UserControl
    {
        public pageGererCours()
        {
            InitializeComponent();
            dgCours.ItemsSource = new Cours().FindAllAvecDetail();
        }

        private void butNouveauCours_Click(object sender, RoutedEventArgs e)
        {
            popupAjouterCours popup = new popupAjouterCours();
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    popup.LeCours.CoursId = popup.LeCours.Create(); 

                    
                    List<Cours> liste = (List<Cours>)dgCours.ItemsSource;
                    liste.Add(popup.LeCours);
                    dgCours.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le cours n'a pas pu être créé.", "Attention",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            Cours coursSelectionne = (Cours)bouton.DataContext;

            Cours copie = new Cours(
                coursSelectionne.CoursId,
                coursSelectionne.CategorieId,
                coursSelectionne.CoursNom,
                coursSelectionne.CoursDescription);

            popupModifierCours popup = new popupModifierCours(copie);
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    copie.Update();

                    coursSelectionne.CoursNom = copie.CoursNom;
                    coursSelectionne.CoursDescription = copie.CoursDescription;
                    coursSelectionne.CategorieId = copie.CategorieId;
                    coursSelectionne.Categorie = copie.Categorie;  

                    dgCours.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le cours n'a pas pu être modifié.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
