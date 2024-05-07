using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IRepository<CarModel> _repository;
        public CarController(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllCars")]
        public async Task<ActionResult<CarModel>> GetAllCars()
        {
            List<CarModel> cars = await _repository.GetAll();
            return Ok(cars);
        }

        [HttpGet("GetCarById/{id}")]
        public async Task<ActionResult<CarModel>> GetCarById(int id)
        {
            CarModel carModel = await _repository.GetById(id);
            return carModel;
        }

        [HttpPost("AddCar")]
        public async Task<ActionResult<CarModel>> AddCar(CarModel entity)
        {
            CarModel carModel = await _repository.Add(entity);
            return Ok(carModel);
        }

        [HttpPut("UpdateCar/{id}")]
        public async Task<ActionResult<CarModel>> UpdateCar(CarModel entity, int id)
        {
            entity.Id = id;
            CarModel carModel = await _repository.Update(entity, id);
            return Ok(carModel);
        }

        [HttpDelete("DeleteCar/{id}")]
        public async Task<ActionResult<bool>> DeleteCar(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
