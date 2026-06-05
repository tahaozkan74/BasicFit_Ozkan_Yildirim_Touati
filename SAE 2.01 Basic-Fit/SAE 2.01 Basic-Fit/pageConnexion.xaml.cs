using SAE201.Models;
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

            // On teste la connexion PostgreSQL avec ces identifiants
            if (DataAccess.TesterConnexion(username, password))
            {
                // Connexion OK : on détermine l'espace selon l'utilisateur
                if (username == "ozkant")
                {
                    this.Content = new Employe.UCWindow.pagePrincipal();
                    this.Height = 750;
                    this.Width = 1250;
                }
                else if (username == "yildirfa")
                {
                    this.Content = new Responsable.UCWindow.pagePrincipal();
                    this.Height = 750;
                    this.Width = 1250;
                }
                else
                {
                    MessageBox.Show("Utilisateur inconnu.", "Connexion",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                    "Connexion échouée", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}