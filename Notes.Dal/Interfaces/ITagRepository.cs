using Notes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Dal.Interfaces
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<Tag> GetTagByName(string name);
    }
}
