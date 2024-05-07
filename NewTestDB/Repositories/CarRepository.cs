using Microsoft.EntityFrameworkCore;
using NewTestDB.Context;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;

namespace NewTestDB.Repositories
{
    public class CarRepository : IRepository<CarModel>
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CarModel>> GetAll()
        {
            return await _context.CarModels.ToListAsync();
        }

        public async Task<CarModel> GetById(int id)
        {
            CarModel carModel = await _context.CarModels.FindAsync(id);
            if(carModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            return carModel;
        }

        public async Task<CarModel> Add(CarModel entity)
        {
            await _context.CarModels.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CarModel> Update(CarModel entity, int id)
        {
            CarModel carModel = await GetById(id);
            if (carModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            carModel.Id = entity.Id;
            carModel.Name = entity.Name;
            carModel.Description = entity.Description;
            carModel.LicensePlate = entity.LicensePlate;
            carModel.PersonId = entity.PersonId;

            _context.CarModels.Update(carModel);
            await _context.SaveChangesAsync();
            return carModel;
        }
        public async Task<bool> Delete(int id)
        {
            CarModel carModel = await GetById(id);
            if (carModel == null)
            {
                throw new Exception($"Entity with this Id: {id} cannot be found");
            }
            _context.CarModels.Remove(carModel);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
