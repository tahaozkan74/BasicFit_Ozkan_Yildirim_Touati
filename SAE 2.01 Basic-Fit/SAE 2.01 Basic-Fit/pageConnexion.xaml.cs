using System;
using System.Windows;
using System.Windows.Controls;

namespace SAE_2._01_Basic_Fit
{
    public partial class pageConnexion : Window
    {
        public pageConnexion()
        {
            InitializeComponent();
        }

        private void butConnecter_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Password;

            if (username == "ozkant" && password == "Oxto08")
            {
                this.Content = new Employe.UCWindow.pagePrincipal();

                this.Height = 750;
                this.Width = 1250;
            }
            else if (username == "yildirfa" && password == "le4pUV")
            {
                this.Content = new Responsable.UCWindow.pagePrincipal();
                this.Height = 750;
                this.Width = 1250;
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Connexion échouée", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}