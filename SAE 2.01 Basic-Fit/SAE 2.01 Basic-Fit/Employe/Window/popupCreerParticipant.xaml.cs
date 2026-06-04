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

namespace SAE_2._01_Basic_Fit.Employe.Window
{
    /// <summary>
    /// Logique d'interaction pour popupCreerParticipant.xaml
    /// </summary>
    public partial class popupCreerParticipant : System.Windows.Window
    {
        public popupCreerParticipant()
        {
            InitializeComponent();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butCreer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
