using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class AuthorBookRepository : Repository<AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(DbEFContext context) : base(context) { }

        public override IList<AuthorBook> Get()
        {
            return _context.AuthorBooks.Include("Book").Include("Author").ToList();
        }
    }
}
