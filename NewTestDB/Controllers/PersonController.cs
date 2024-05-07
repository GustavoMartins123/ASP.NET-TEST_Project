using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

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
            return Ok(persons);
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id)
        {
            PersonModel personModel = await _repository.GetById(id);
            return Ok(personModel);
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
