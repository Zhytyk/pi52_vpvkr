using LibraryReport.Authentication;
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

namespace LibraryReport.Views.Users
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public AuthProvider AuthProvider { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Password;

            AuthProvider = new AuthProvider(login, password);
            
            if (AuthProvider.IsAuthenticated)
            {
                DialogResult = true;
                Close();
            } 
            else
            {
                MessageBox.Show("Invalid login or password...");
            }
        }
    }
}
