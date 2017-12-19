using LibraryReport.Interfaces;
using LibraryReport.Models;
using LibraryReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Controllers
{
    public class AuthorBookController : BaseController<AuthorBookRepository, IAuthorBookRepository, AuthorBook>
    {
        public AuthorBookController() : base() { }
    }
}
