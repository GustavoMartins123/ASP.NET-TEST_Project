using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPersonController : ControllerBase
    {
        private readonly IRepository<JobPersonModel> _repository;
        public JobPersonController(IRepository<JobPersonModel> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<JobPersonModel>> GetAllCars()
        {
            List<JobPersonModel> jobs = await _repository.GetAll();
            return Ok(jobs);
        }

        [HttpGet("GetJobById/{id}")]
        public async Task<ActionResult<JobPersonModel>> GetCarById(int id)
        {
            JobPersonModel jobModel = await _repository.GetById(id);
            return Ok(jobModel);
        }

        [HttpPost("AddJob")]
        public async Task<ActionResult<JobPersonModel>> AddCar(JobPersonModel entity)
        {
            JobPersonModel jobModel = await _repository.Add(entity);
            return Ok(jobModel);
        }

        [HttpPut("UpdateJob/{id}")]
        public async Task<ActionResult<JobPersonModel>> UpdateCar(JobPersonModel entity, int id)
        {
            entity.Id = id;
            JobPersonModel jobModel = await _repository.Update(entity, id);
            return Ok(jobModel);
        }

        [HttpDelete("DeleteJob/{id}")]
        public async Task<ActionResult<bool>> DeleteCar(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
