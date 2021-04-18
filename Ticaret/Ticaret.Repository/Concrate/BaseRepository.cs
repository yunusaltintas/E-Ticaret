using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public class BaseRepository<T> : ICategoryRepository<T> where T : BaseEntity
    {
        private readonly TicaretDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(TicaretDbContext ticaretDbContext)
        {
            _context = ticaretDbContext;
            _db = _context.Set<T>();
        }
        public async Task<T> TAddAsync(T Entity)
        {
            await _db.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> TFetchSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _db.Where(predicate).FirstOrDefaultAsync();
            return result;
        }

        public List<T> TFind(Expression<Func<T, bool>> predicate)
        {
            return _db.Where(predicate).ToList();
        }

        public async Task<List<T>> TGetAllAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _db.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<T> TQuery()
        {
            return _db.AsQueryable();
        }

        public async Task<bool> TRemoveAsync(int id)
        {
            var result = await _db.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _db.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<T> TUpdateAsync(T Entity)
        {
            _db.Update(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }

}
