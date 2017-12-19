using LibraryReport.Interfaces;
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
    public class SectionController : BaseController<SectionRepository, ISectionRepository, Section>
    {
        public SectionController() : base() {}

        public int CountByLibraryId(int id)
        {
            return _repository.CountByLibraryId(id);
        }
    }
}
