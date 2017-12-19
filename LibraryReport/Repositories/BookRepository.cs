using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbEFContext context) : base(context) { }

        public override IList<Book> Get()
        {
            return _context.Books.Include("Section").Include("Publisher").ToList();
        }

        public int CountByLibraryId(int id)
        {
            return _context.Books.Count(b => b.Section.Library.Id == id);
        }
    }
}
