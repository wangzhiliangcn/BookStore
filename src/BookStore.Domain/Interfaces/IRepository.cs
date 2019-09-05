using BookStore.Domain.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(long id);
        List<T> ListAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
