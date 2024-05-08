using Microsoft.EntityFrameworkCore;
using NewTestDB.Context;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Repositories
{
    public class JobPersonRepository : IRepository<JobPersonModel>
    {
        private readonly DataContext _context;

        public JobPersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<JobPersonModel>> GetAll()
        {
            return await _context.JobModels.Select(j => new JobPersonModel
            {
                Id = j.Id,
                Status = j.Status
            }).OrderBy(j => j.Id).ToListAsync();
        }

        public async Task<JobPersonModel> GetById(int id)
        {
            JobPersonModel jobModel = await _context.JobModels.FindAsync(id);
            if(jobModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            return jobModel;
        }


        public async Task<JobPersonModel> Add(JobPersonModel entity)
        {
            await _context.JobModels.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<JobPersonModel> Update(JobPersonModel entity, int id)
        {
            JobPersonModel jobModel = await GetById(id);
            if(jobModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            _context.Entry(jobModel).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return jobModel;
        }
        public async Task<bool> Delete(int id)
        {
            JobPersonModel jobModel = await GetById(id);
            if (jobModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            _context.JobModels.Remove(jobModel);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
