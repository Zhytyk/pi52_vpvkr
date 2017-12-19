using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DbEFContext context) : base(context) {}

        public int CountByLibraryId(int id)
        {
            return _context.Sections.Count(s => s.Library.Id == id);
        }
    }
}
