using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Service.Interfaces
{
    public interface IBaseService<T>
    {
        public Task<IBaseResponse<IEnumerable<T>>> SelectAllAsync();

        public Task<IBaseResponse<T>> SelectByIdAsync(Guid id);
        public Task<IBaseResponse<bool>> CreateAsync(T entity);
        public Task<IBaseResponse<bool>> DeleteAsync(T entity);
        public Task<IBaseResponse<bool>> UpdateAsync(T entity);
    }
}
