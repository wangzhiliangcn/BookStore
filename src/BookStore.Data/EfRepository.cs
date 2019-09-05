using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStore.Domain.Interfaces;
using BookStore.Domain.SharedKernel;

namespace BookStore.Data
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMSContext _dbContext;

        public EfRepository()
        {
            _dbContext = new IMSContext();
        }

        public EfRepository(IMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public List<T> ListAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public T Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
