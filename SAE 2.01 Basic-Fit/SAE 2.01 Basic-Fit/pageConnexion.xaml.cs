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
using System.Windows.Shapes;

namespace SAE_2._01_Basic_Fit
{
    /// <summary>
    /// Logique d'interaction pour pageConnexion.xaml
    /// </summary>
    public partial class pageConnexion : Window
    {
        public pageConnexion()
        {
            InitializeComponent();
        }

        private void butConnecter_Click(object sender, RoutedEventArgs e)
        {
            Employe.UCWindow.pagePrincipal pagePrincipal = new Employe.UCWindow.pagePrincipal();
            this.Content = pagePrincipal;

            Height = 750;
            Width = 1250;
        }
    }
}
