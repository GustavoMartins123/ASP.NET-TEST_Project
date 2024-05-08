using Microsoft.AspNetCore.Mvc;
using NewTestDB.Models;
using NewTestDB.Models.Dto;
using NewTestDB.Models.Dto.JobPerson;
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
        public async Task<ActionResult<JobPersonModel>> GetAllJobs()
        {
            List<JobPersonModel> jobs = await _repository.GetAll();

            List<JobPersonReturnDto> jobsDto = new();

            foreach (var job in jobs)
            {
                jobsDto.Add(new JobPersonReturnDto
                {
                    Id = job.Id,
                    Status = job.Status
                });
            }
            return Ok(jobsDto);
        }

        [HttpGet("GetJobById/{id}")]
        public async Task<ActionResult<JobPersonModel>> GetJobById(int id)
        {
            JobPersonModel jobModel = await _repository.GetById(id);
            var jobDetail = new JobPersonDetailDto{
                Id = jobModel.Id,
                Company = jobModel.Company,
                Title = jobModel.Title,
                Description = jobModel.Description,
                Salary = jobModel.Salary,
                Status = jobModel.Status
            };
            return Ok(jobDetail);
        }

        [HttpPost("AddJob")]
        public async Task<ActionResult<JobPersonModel>> AddJob(JobPersonModel entity)
        {
            JobPersonModel jobModel = await _repository.Add(entity);
            return Ok(jobModel);
        }

        [HttpPut("UpdateJob/{id}")]
        public async Task<ActionResult<JobPersonModel>> UpdateJob(JobPersonModel entity, int id)
        {
            entity.Id = id;
            JobPersonModel jobModel = await _repository.Update(entity, id);
            return Ok(jobModel);
        }

        [HttpDelete("DeleteJob/{id}")]
        public async Task<ActionResult<bool>> DeleteJob(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
