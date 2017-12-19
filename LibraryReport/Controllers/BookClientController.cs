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
    public class BookClientController : BaseController<BookClientRepository, IBookClientRepository, BookClient>
    {
        public BookClientController() : base() { }

        public int CountInUseByLibraryId(int id)
        {
            return _repository.CountInUseByLibraryId(id);
        }
    }
}
