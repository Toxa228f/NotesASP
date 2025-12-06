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
    public class TagRepository : ITagRepository
    {
        private ApplicationDBContext dbContext;

        public TagRepository(ApplicationDBContext dbContext) => this.dbContext = dbContext;

        public async Task<bool> Create(Tag entity)
        {
            if (entity != null)
            {
                await dbContext.Tags.AddAsync(entity);
                return true;
            }
            else return false;
        }

        public bool Delete(Tag entity)
        {
            if (entity != null)
            {
                dbContext.Tags.Remove(entity);
                return true;
            }
            else return false;
        }

        public async Task<Tag> GetById(Guid id) => await dbContext.Tags.FirstOrDefaultAsync(x=> x.Id == id);

        public async Task<Tag> GetTagByName(string name) => await dbContext.Tags.FirstOrDefaultAsync(x => x.Name == name);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();


        public async Task<IEnumerable<Tag>> SelectAll() => await dbContext.Tags.ToListAsync();

        public bool Update(Tag entity)
        {
            if (entity != null)
            {
                dbContext.Tags.Update(entity);
                return true;
            }
            else return false;
        }
    }
}
