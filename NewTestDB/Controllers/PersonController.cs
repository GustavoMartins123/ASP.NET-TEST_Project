﻿using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Models.Dto.Person;
using NewTestDB.Repositories.Interface;
using AutoMapper;

namespace NewTestDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<PersonModel> _repository;
        private readonly IMapper _mapper;

        public PersonController(IRepository<PersonModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAllPersons")]
        public async Task<ActionResult<PersonModel>> GetAllPersons()
        {
            List<PersonModel> persons = await _repository.GetAll();
            List<PersonReturnDto> personsDto = new();

            foreach (var personDto in persons)
            {
                personsDto.Add(_mapper.Map<PersonReturnDto>(personDto));
            }
            return Ok(personsDto);
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id)
        {
            PersonModel personModel = await _repository.GetById(id);
            PersonDetailDto personDto = _mapper.Map<PersonDetailDto>(personModel);
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
