using LibraryReport.Interfaces;
using LibraryReport.IOC;
using LibraryReport.Models;
using LibraryReport.Repositories;
using LibraryReport.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Controllers
{
    public abstract class BaseController<TRepo, ITRepo, TEntity> where TRepo : Repository<TEntity> where ITRepo : IRepository<TEntity> where TEntity : Entity
    {
        protected IUnitOfWork _work;
        protected ITRepo _repository;

        public BaseController()
        {
            ITRepo repo = (ITRepo) IOCContainer.Injector.Inject(typeof(TRepo));

            _repository = repo;
            _work = repo as IUnitOfWork;
        }

        public int Count()
        {
            return _repository.Count();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IList<TEntity> Get()
        {
            return _repository.Get();
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
            _work.Save();
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
            _work.Save();
        }

        public virtual void Edit(TEntity entity)
        {
            _repository.Edit(entity);
            _work.Save();
        }
    }
}
