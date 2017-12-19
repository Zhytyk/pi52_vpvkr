using LibraryReport.IOC;
using LibraryReport.Models;
using LibraryReport.Repositories;
using LibraryReport.Repositories.Interfaces;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Controllers
{
    class LibraryController : BaseController<LibraryRepository, ILibraryRepository, Library>
    {
        public LibraryController() : base() {}
    }
}
