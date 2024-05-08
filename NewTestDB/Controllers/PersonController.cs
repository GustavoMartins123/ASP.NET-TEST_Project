using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Models.Dto.Person;
using NewTestDB.Repositories.Interface;
using NewTestDB.Models.Dto.JobPerson;
using NewTestDB.Models.Dto.Car;

namespace NewTestDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<PersonModel> _repository;
        public PersonController(IRepository<PersonModel> repository)
        {
            _repository = repository;
        }
        [HttpGet("GetAllPersons")]
        public async Task<ActionResult<PersonModel>> GetAllPersons()
        {
            List<PersonModel> persons = await _repository.GetAll();
            List<PersonReturnDto> personsDto = new();

            foreach (var personDto in persons)
            {
                personsDto.Add(new PersonReturnDto
                {
                    Id = personDto.Id,
                    Name = personDto.Name,
                    LastName = personDto.LastName,
                    Age = personDto.Age
                });
            }
            return Ok(personsDto);
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id)
        {
            PersonModel personModel = await _repository.GetById(id);
            var personDto = new PersonDetailDto {
                Id = personModel.Id,
                Name = personModel.Name,
                LastName = personModel.LastName,
                Age = personModel.Age,
                Cars = personModel.Cars.Select(c => new CarDetailDto
                {
                    Id = c.Id,
                    Manufacturer = c.Manufacturer,
                    Name = c.Name,
                    Description = c.Description,
                    LicensePlate = c.LicensePlate
                }).ToList(),
            };
            if (personModel.Job != null)
            {
                personDto.Job = new JobPersonDetailDto
                {
                    Id = personModel.Job.Id,
                    Company = personModel.Job.Company,
                    Title = personModel.Job.Title,
                    Description = personModel.Job.Description,
                    Salary = personModel.Job.Salary,
                    Status = personModel.Job.Status
                };
            }
            return Ok(personDto);
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<PersonModel>> AddPerson(PersonModel entity)
        {
            PersonModel personModel = await _repository.Add(entity);
            return Ok(personModel);
        }

        [HttpPut("UpdatePerson/{id}")]
        public async Task<ActionResult<PersonModel>> UpdatePerson(PersonModel entity, int id)
        {
            entity.Id = id;
            PersonModel personModel = await _repository.Update(entity, id);
            return Ok(personModel);
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
