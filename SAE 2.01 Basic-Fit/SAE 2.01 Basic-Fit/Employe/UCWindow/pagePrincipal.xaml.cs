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
 
    public partial class pagePrincipal : UserControl
    {
        public pagePrincipal()
        {
            InitializeComponent();
        }

        private void butCoursJour_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageCours();
        }

        private void butRechercheCours_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageRechercheCours();
        }

        private void butParticipant_Click(object sender, RoutedEventArgs e)
        {
            ZoneContenu.Content = new pageParticipant();
        }
    }
}
