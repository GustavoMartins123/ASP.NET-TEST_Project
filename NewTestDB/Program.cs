using NewTestDB.Extensions;

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
