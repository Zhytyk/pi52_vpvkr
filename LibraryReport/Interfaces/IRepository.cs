using LibraryReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Interfaces
{
    public interface IRepository<T> 
    {
        int Count();

        IList<T> Get();

        T GetById(int id);

        void Add(T entity);

        void Remove(int id);

        void Edit(T entity);
    }
}
