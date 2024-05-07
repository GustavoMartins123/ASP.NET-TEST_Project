using NewTestDB.Extensions;
using NewTestDB.Models;
using NewTestDB.Repositories.Interface;
using NewTestDB.Repositories;

namespace NewTestDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddConfiguration();
            var app = builder.Build();

            app
                .UseConfiguration()
                .Run();
        }
    }
}
