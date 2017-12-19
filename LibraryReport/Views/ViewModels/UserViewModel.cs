using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class UserViewModel : EntityViewModel
    {
        private string login;
        public string Login {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(Constants.LOGIN);
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(Constants.PASSWORD);
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(Constants.EMAIL);
            }
        }

        private Role role;
        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                OnPropertyChanged(Constants.ROLE);
            }
        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Password = user.Password;
            Role = user.Role;
        }

        public static bool GetSearchPredicate(UserViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Login.Contains(SearchPredicate.searchPredicate)
                || model.Email.Contains(SearchPredicate.searchPredicate)
                || model.Password.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Role.ToString().Contains(SearchPredicate.searchPredicate);
        }

    }
}
