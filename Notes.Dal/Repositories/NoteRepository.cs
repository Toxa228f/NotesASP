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
    public class NoteRepository : INoteRepository
    {
        private ApplicationDBContext dbContext;

        public NoteRepository(ApplicationDBContext dbContext) => this.dbContext = dbContext;

        public async Task<bool> Create(Note entity)
        {
            if (entity != null)
            {
                await dbContext.Notes.AddAsync(entity);
                return true;
            }
            else return false;
        }

        public bool Delete(Note entity)
        {
            if (entity != null)
            {
                dbContext.Notes.Remove(entity);
                return true;
            }
            else return false;
        }

        public async Task<IEnumerable<Note>> GetAllByUserId(Guid id) => await dbContext.Notes.Where(x => x.UserId == id).ToListAsync();

        public async Task<Note> GetById(Guid id) => await dbContext.Notes.FirstOrDefaultAsync(x => x.UserId == id);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();

        public async Task<IEnumerable<Note>> SelectAll() => await dbContext.Notes.ToListAsync();

        public bool Update(Note entity)
        {
            if (entity != null)
            {
                dbContext.Notes.Update(entity);
                return true;
            }
            else return false;
        }
    }
}
