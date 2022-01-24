using Microsoft.AspNetCore.Mvc;
using PFClean.Contracts.Services;
using PFClean.Domain.Entities;

namespace PFClean.API.Controllers
{
    public class CarsController : BaseApiController
    {
        private readonly ICarService _carService;

        public CarsController(ICarService service)
        {
            _carService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars() 
        {
            return await _carService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Car>> GetCarsById(Guid id)
        {
            var car = await _carService.GetByGuid(id);

            if (car == null) return NotFound("Manito no se encontro el carro");
            
            return Ok(car);
            
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car carData)
        {
            var car = await _carService.Add(carData);
            return Ok(car);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Car>> UpdateCar(Guid id, Car carData)
        {
            var car = await _carService.GetByGuid(id);

            await _carService.Update(car);

            if (car == null) return BadRequest("Manito no deje las casillas vacias");

            return Ok(car);

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Car>> DeleteCarsById(Guid id, [FromBody] Car carData)
        {
            var car = await _carService.GetByGuid(id);

            await _carService.Delete(car);

            return Ok(car);

        }

    }
}
