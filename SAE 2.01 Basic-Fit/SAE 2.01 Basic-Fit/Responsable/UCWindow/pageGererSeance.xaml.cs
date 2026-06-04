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
    /// Logique d'interaction pour pageGererSeance.xaml
    /// </summary>
    public partial class pageGererSeance : UserControl
    {
        public pageGererSeance()
        {
            InitializeComponent();
            dgSeance.ItemsSource = new Seance().FindAllSeances();
        }

        private void butAjouterSeance_Click(object sender, RoutedEventArgs e)
        {
            popupAjouterSeance popup = new popupAjouterSeance();
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    popup.LaSeance.SeanceId = popup.LaSeance.Create(); 

                    List<Seance> liste = (List<Seance>)dgSeance.ItemsSource;
                    liste.Add(popup.LaSeance);
                    dgSeance.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La séance n'a pas pu être créée.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            Seance seanceSelectionnee = (Seance)bouton.DataContext;

            Seance copie = new Seance(
                seanceSelectionnee.SeanceId,
                seanceSelectionnee.HeureDebut,
                seanceSelectionnee.HeureFin,
                seanceSelectionnee.NbPlaces,
                seanceSelectionnee.Cours,
                seanceSelectionnee.Salle,
                seanceSelectionnee.Entraineur);
            copie.Jour = seanceSelectionnee.Jour;

            popupModifierSeance popup = new popupModifierSeance(copie);
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                try
                {
                    copie.Update();

                    seanceSelectionnee.Cours = copie.Cours;
                    seanceSelectionnee.Salle = copie.Salle;
                    seanceSelectionnee.Entraineur = copie.Entraineur;
                    seanceSelectionnee.Jour = copie.Jour;
                    seanceSelectionnee.HeureDebut = copie.HeureDebut;
                    seanceSelectionnee.HeureFin = copie.HeureFin;
                    seanceSelectionnee.NbPlaces = copie.NbPlaces;

                    dgSeance.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La séance n'a pas pu être modifiée.", "Attention",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
