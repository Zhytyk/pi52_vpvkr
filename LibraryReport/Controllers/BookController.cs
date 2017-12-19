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
    public class BookController : BaseController<BookRepository, IBookRepository, Book>
    {
        public BookController() : base() { }

        public int CountByLibraryId(int id)
        {
            return _repository.CountByLibraryId(id);
        }
    }
}
