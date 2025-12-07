using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Service.Interfaces
{
    public interface IUsersService : IBaseService<User>
    {
        public Task<IBaseResponse<User>> GetByLoginAndPasswordAsync(string login,string password);

    }
}
