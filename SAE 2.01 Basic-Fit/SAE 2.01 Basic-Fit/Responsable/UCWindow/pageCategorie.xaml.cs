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
            popup.ShowDialog();
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            popupModifierCategorie popup = new popupModifierCategorie();
            popup.ShowDialog();
        }
    }
}
