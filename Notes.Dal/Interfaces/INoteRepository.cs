using Notes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Dal.Interfaces
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<IEnumerable<Note>> GetAllByUserId(Guid id);
    }
}
