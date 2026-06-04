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
using SAE_2._01_Basic_Fit.Models;

namespace SAE_2._01_Basic_Fit.Responsable.Window
{
    public partial class popupModifierCours : System.Windows.Window
    {
        public Cours LeCours { get; set; }

        public popupModifierCours()
        {
            InitializeComponent();
        }

        public popupModifierCours(Cours unCours)
        {
            InitializeComponent();
            LeCours = unCours;

            txtNomCours.Text = unCours.CoursNom;
            txtDescription.Text = unCours.CoursDescription;

            List<Categorie> lesCategories = new Categorie().FindAllAvecDetail();
            cbxCategorie.ItemsSource = lesCategories;

            foreach (Categorie cat in lesCategories)
            {
                if (cat.CategorieId == unCours.CategorieId)
                {
                    cbxCategorie.SelectedItem = cat;
                    break;
                }
            }
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            LeCours.CoursNom = txtNomCours.Text;
            LeCours.CoursDescription = txtDescription.Text;

            Categorie catChoisie = (Categorie)cbxCategorie.SelectedItem;
            if (catChoisie != null)
            {
                LeCours.CategorieId = catChoisie.CategorieId;
                LeCours.Categorie = catChoisie;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
