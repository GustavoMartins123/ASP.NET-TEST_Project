using Microsoft.EntityFrameworkCore;
using NewTestDB.Mapping;
using NewTestDB.Models;

namespace NewTestDB.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PersonModel> PersonModels { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new CarMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
