using LibraryReport.Utils;
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        public AddUser(string login, string email, string password, string role) : this()
        {
            Login.Text = login;
            Email.Text = email;
            Password.Text = password;
            Role.Text = role;

            addBtn.Content = Constants.EDIT;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            convertRole();
            DialogResult = true;
            Close();
        }

        private void convertRole()
        {
            switch (Role.Text)
            {
                case Constants.ADMIN:
                    Role.Text = Models.Role.Admin.ToString();
                    return;
                case Constants.USER:
                    Role.Text = Models.Role.User.ToString();
                    return;
            }

            Role.Text = Models.Role.User.ToString();
        }
    }
}
