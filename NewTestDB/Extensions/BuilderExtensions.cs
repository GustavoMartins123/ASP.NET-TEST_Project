using Microsoft.EntityFrameworkCore;
using NewTestDB.Context;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;
using NewTestDB.Repositories;

namespace NewTestDB.Extensions
{
    public static class BuilderExtensions
    {
        public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IRepository<PersonModel>, PersonRepository>();
            builder.Services.AddScoped<IRepository<CarModel>, CarRepository>();
builder.Services.AddScoped<IRepository<JobPersonModel>, JobPersonRepository>();


            return builder;
        }
    }
}
