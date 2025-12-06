using Microsoft.EntityFrameworkCore;
using Notes.Dal.Interfaces;
using Notes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDBContext dbContext;

        public UserRepository(ApplicationDBContext dbContext) => this.dbContext = dbContext;

        public async Task<bool> Create(User entity)
        {
            if (entity != null)
            {
                await dbContext.Users.AddAsync(entity);
                return true;
            }
            else return false;
        }

        public bool Delete(User entity)
        {
            if (entity != null)
            {
                dbContext.Users.Remove(entity);
                return true;
            }
            else return false;
        }

        public async Task<User> GetById(Guid id) => await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByLogin(string login) => await dbContext.Users.FirstOrDefaultAsync(x => x.Login == login);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();

        public async Task<IEnumerable<User>> SelectAll() => await dbContext.Users.ToListAsync();

        public bool Update(User entity)
        {
            if (entity != null)
            {
                dbContext.Users.Update(entity);
                return true;
            }
            else return false;
        }
    }
}
