﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Interfaces
{
    public interface Injector
    {
        object Inject(Type type);
    }
}
