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
    }
}
