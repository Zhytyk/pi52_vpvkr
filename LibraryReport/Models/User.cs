using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.users")]
    public class User : Entity
    {
        [Column("Login")]
        public string Login { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Role")]
        public Role Role { get; set; }


        public User()
        {

        }

        public User(string login, string email, string password, string role)
        {
            Login = login;
            Email = email;
            Password = password;
            Role = (Role) Enum.Parse(typeof(Role), role);
        }
    }
}
