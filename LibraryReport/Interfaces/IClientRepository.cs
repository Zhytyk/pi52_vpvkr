﻿using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        int CountByLibraryId(int id);
    }
}