using Microsoft.EntityFrameworkCore;
using PFClean.Contracts.Repositories;
using PFClean.Infrastructure.Persistence.DataContext;

namespace PFClean.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        
        public async Task<T?> GetByGuidAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
       
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task UpdateAsyc(T entity)
        {
            
            _context.Update<T>(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        
        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
   
    }
}
