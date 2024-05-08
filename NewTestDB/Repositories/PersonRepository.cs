using Microsoft.EntityFrameworkCore;
using NewTestDB.Context;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Repositories
{
    public class PersonRepository : IRepository<PersonModel>
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PersonModel>> GetAll()
        {
            return await _context.PersonModels.Select(p => new PersonModel
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                Age = p.Age
            }).OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<PersonModel> GetById(int id)
        {
            PersonModel personModel = await _context.PersonModels.Include(p => p.Cars).Include(p => p.Job).FirstOrDefaultAsync(p => p.Id == id);
            if(personModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            return personModel;
        }


        public async Task<PersonModel> Add(PersonModel entity)
        {
            await _context.PersonModels.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PersonModel> Update(PersonModel entity, int id)
        {
            PersonModel personModel = await GetById(id);
            if(personModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            _context.Entry(personModel).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return personModel;
        }
        public async Task<bool> Delete(int id)
        {
            PersonModel personModel = await GetById(id);
            if (personModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            _context.PersonModels.Remove(personModel);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
