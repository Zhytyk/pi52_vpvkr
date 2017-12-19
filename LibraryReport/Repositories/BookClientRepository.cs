using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class BookClientRepository : BookClientBaseRepository<BookClient>, IBookClientRepository
    {
        public BookClientRepository(DbEFContext context) : base(context) { }

        public int CountInUseByLibraryId(int id)
        {
            return _context.BookClients.Count(bc => bc.Client.Library.Id == id);
        }
    }
}
