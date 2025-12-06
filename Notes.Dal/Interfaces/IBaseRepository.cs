using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T> GetById(Guid id);

        bool Delete(T entity);

        Task<IEnumerable<T>> SelectAll();

        bool Update(T entity);

        Task SaveChanges();
    }
}
