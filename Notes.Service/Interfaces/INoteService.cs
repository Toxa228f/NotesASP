using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Service.Interfaces
{
    public interface INoteService : IBaseService<Note>
    {
        Task<IBaseResponse<IEnumerable<Note>>> GetAllByUserIdAsync(Guid id);
    }
}
