using LibraryReport.Interfaces;
using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbEFContext context) : base(context) { }
        
        public int CountByLibraryId(int id)
        {
            return _context.Clients.Count(e => e.Library.Id == id);
        }
    }
}
