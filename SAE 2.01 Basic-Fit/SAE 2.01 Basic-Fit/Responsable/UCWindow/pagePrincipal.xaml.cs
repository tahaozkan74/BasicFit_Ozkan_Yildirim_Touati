using SAE_2._01_Basic_Fit.Employe.UCWindow;
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
    /// Logique d'interaction pour pagePrincipal.xaml
    /// </summary>
    public partial class pagePrincipal : UserControl
    {
        public pagePrincipal()
        {
            InitializeComponent();
        }

        private void butGererCours_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageGererCours();
        }

        private void butGererSeance_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageGererSeance();
        }

        private void butCategorie_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageCategorie();
        }

        private void butLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Window fenetre = System.Windows.Window.GetWindow(this);
            fenetre.Close();
        }
    }
}