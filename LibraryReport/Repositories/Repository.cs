using LibraryReport.Interfaces;
using LibraryReport.Models;
using LibraryReport.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Repositories
{
    public class Repository<T> : IRepository<T>, IUnitOfWork where T : Entity 
    {
        protected DbEFContext _context;

        public Repository(DbEFContext context)
        {
            _context = context;
        }

        public virtual int Count() => _context.Set<T>().Count();

        public virtual T GetById(int id) => _context.Set<T>().Find(id);

        public virtual IList<T> Get() => _context.Set<T>().ToList();

        public virtual void Add(T entity) => _context.Set<T>().Add(entity);

        public virtual void Remove(int id) => _context.Set<T>().Remove(GetById(id));

        public virtual void Edit(T editedLibrary)
        {
            T current = GetById(editedLibrary.Id);
            _context.Entry(current).CurrentValues.SetValues(editedLibrary);
        }

        public virtual void Save() => _context.SaveChanges();
    }
}
