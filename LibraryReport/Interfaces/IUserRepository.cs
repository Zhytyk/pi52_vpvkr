using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
