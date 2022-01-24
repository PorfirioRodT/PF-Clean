using PFClean.Contracts.Repositories;
using PFClean.Contracts.Services;
using PFClean.Domain.Entities;
using PFClean.Infrastructure.Repositories;

namespace PFClean.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAll()
        {
            return (List<Car>) await _carRepository.GetAll();
        }

        public async Task<Car?> GetByGuid(Guid id)
        {
            return await _carRepository.GetByGuidAsync(id);
        }
        public async Task<Car> Add(Car entity)
        {
            return await _carRepository.AddAsync(entity);
        }

        public async Task Delete(Car entity)
        {
           await _carRepository.DeleteAsync(entity);
        }

        public async Task Update(Car entity)
        {
            await _carRepository.UpdateAsyc(entity);
        }
    }
}