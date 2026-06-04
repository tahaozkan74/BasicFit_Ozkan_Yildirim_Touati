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

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    /// <summary>
    /// Logique d'interaction pour popupModifierCours.xaml
    /// </summary>
    public partial class popupModifierCours : System.Windows.Window
    {
        public popupModifierCours()
        {
            InitializeComponent();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
            this.Close();
        }
    }
}
