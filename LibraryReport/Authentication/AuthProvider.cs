using LibraryReport.Interfaces;
using LibraryReport.IOC;
using LibraryReport.Models;
using LibraryReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Authentication
{
    public class AuthProvider
    {
        private IUserRepository userRepository;
        
        public string Login { get; set; }

        public Role UserRole { get; set; }

        public bool IsAuthenticated { get; set; }
        
        public static AuthProvider NewAuthProvider(string login, string password)
        {
            return new AuthProvider(login, password);
        }

        public AuthProvider(string login, string password)
        {
            userRepository = IOCContainer.Injector.Inject(typeof(UserRepository)) as IUserRepository;

            User user = userRepository.GetByLoginAndPassword(login, password);

            if (user != null)
            {
                UserRole = user.Role;
                Login = user.Login;
                IsAuthenticated = true;
            }
        }
    }
}
