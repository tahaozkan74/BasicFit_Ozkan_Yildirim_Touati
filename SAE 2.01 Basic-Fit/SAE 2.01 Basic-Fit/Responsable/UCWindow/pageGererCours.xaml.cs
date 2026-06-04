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
            popup.ShowDialog();
        }

        private void butVoir_Click(object sender, RoutedEventArgs e)
        {
            popupModifierCours popup = new popupModifierCours();
            popup.ShowDialog();
        }
    }
}
