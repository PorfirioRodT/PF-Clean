using Microsoft.EntityFrameworkCore;
using PFClean.Contracts.Repositories;
using PFClean.Domain.Entities;
using PFClean.Infrastructure.Persistence.DataContext;

namespace PFClean.Infrastructure.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(DataContext context) : base(context)
        {
        }

        public async Task UpdateAsyc(Car entity)
        {
            _context.Cars.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}