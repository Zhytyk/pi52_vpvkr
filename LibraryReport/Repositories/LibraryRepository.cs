using LibraryReport.Models;
using LibraryReport.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        public LibraryRepository(DbEFContext context) : base(context) {}
    }
}
