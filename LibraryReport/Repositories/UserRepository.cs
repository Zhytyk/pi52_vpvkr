using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbEFContext context) : base(context) { }


        public User GetByLoginAndPassword(string login, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
