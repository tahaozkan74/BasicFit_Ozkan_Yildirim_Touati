using SAE_2._01_Basic_Fit.Employe.Window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_2._01_Basic_Fit.Employe.UCWindow
{
    /// <summary>
    /// Logique d'interaction pour pageParticipant.xaml
    /// </summary>
    public partial class pageParticipant : UserControl
    {
        public pageParticipant()
        {
            InitializeComponent();
            dgClient.ItemsSource = new Client().FindAll();
            dgClient.Items.Filter = FiltreClient;
        }
        private bool FiltreClient(object obj)
        {
            Client leClient = obj as Client;


            bool Nom = String.IsNullOrEmpty(filtreNom.Text) || leClient.Nom.StartsWith(filtreNom.Text, StringComparison.OrdinalIgnoreCase);

            bool Prenom = String.IsNullOrEmpty(filtrePrenom.Text) || leClient.Prenom.StartsWith(filtrePrenom.Text, StringComparison.OrdinalIgnoreCase);

            bool Tel = String.IsNullOrEmpty(filtreTel.Text) || leClient.Telephone.StartsWith(filtreTel.Text, StringComparison.OrdinalIgnoreCase);

            return Nom && Prenom && Tel;
        }
        private void filtreNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClient.ItemsSource).Refresh();
        }

        private void filtrePrenom_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClient.ItemsSource).Refresh();
        }

        private void filtreTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClient.ItemsSource).Refresh();
        }

        private void butNouveauParticipant_Click(object sender, RoutedEventArgs e)
        {
            popupCreerParticipant popup = new popupCreerParticipant();
            popup.ShowDialog();
        }

       
    }
}
