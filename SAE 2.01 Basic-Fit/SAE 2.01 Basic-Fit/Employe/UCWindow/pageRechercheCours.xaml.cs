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
    public partial class pageRechercheCours : UserControl
    {
        public pageRechercheCours()
        {
            InitializeComponent();
            dgRechercheCours.ItemsSource = new Seance().FindAll();
            dgRechercheCours.Items.Filter = FiltreSeance;
        }

        private bool FiltreSeance(object obj)
        {
            Seance laSeance = obj as Seance;

            
            bool Cours = String.IsNullOrEmpty(filtreCours.Text) || laSeance.Cours.CoursNom.StartsWith(filtreCours.Text, StringComparison.OrdinalIgnoreCase);

            
            bool Horaire = String.IsNullOrEmpty(filtreHoraire.Text) || laSeance.Horaire.StartsWith(filtreHoraire.Text, StringComparison.OrdinalIgnoreCase);

            
            return Cours && Horaire;
        }

        private void filtreCours_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgRechercheCours.ItemsSource).Refresh();
        }

        private void filtreHoraire_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgRechercheCours.ItemsSource).Refresh();
        }

        //private void filtreHoraire_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(dgRechercheCours.ItemsSource).Refresh();
        //}

        //private bool FiltreHoraire(object obj)
        //{
        //    if (String.IsNullOrEmpty(filtreHoraire.Text))
        //        return true;

        //    Seance laSeance = obj as Seance;
        //    return laSeance.Horaire.StartsWith(filtreHoraire.Text, StringComparison.OrdinalIgnoreCase);
        //}
    }
}
