using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class BookClientBaseRepository<T> : Repository<T>, IBookClientBaseRepository<T> where T : BookClientBase
    {
        public BookClientBaseRepository(DbEFContext context) : base(context) { }

        public override IList<T> Get()
        {
            return _context.Set<T>().Include("Book").Include("Client").ToList();
        }
    }
}
