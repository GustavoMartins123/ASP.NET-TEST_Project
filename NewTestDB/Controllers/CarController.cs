using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Models.Dto.Car;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IRepository<CarModel> _repository;
        private readonly IMapper _mapper;

        public CarController(IRepository<CarModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCars")]
        public async Task<ActionResult<CarModel>> GetAllCars()
        {
            List<CarModel> cars = await _repository.GetAll();
            List<CarReturnDto> carsDto = new();

            foreach (var carDto in cars)
            {
                carsDto.Add(_mapper.Map<CarReturnDto>(carDto));
            }
            return Ok(carsDto);
        }

        [HttpGet("GetCarById/{id}")]
        public async Task<ActionResult<CarModel>> GetCarById(int id)
        {
            CarModel carModel = await _repository.GetById(id);

            CarDetailDto carDto = _mapper.Map<CarDetailDto>(carModel);

            return Ok(carDto);
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
