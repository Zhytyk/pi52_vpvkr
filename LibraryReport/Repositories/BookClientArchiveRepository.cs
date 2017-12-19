using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class BookClientArchiveRepository : BookClientBaseRepository<BookClientArchive>, IBookClientArchiveRepository
    {
        public BookClientArchiveRepository(DbEFContext context) : base(context) { }
    }
}
