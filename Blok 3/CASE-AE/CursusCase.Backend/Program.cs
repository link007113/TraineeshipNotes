using CursusCase.Backend.DAL.Context;
using CursusCase.Backend.DAL.Repositories;
using CursusCase.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CursusCase.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            builder.Services
                .AddControllers()
                .AddJsonOptions(
                    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                );
            builder.Services.AddTransient<ICursusInstanceRepo, CursusInstanceRepo>();
            builder.Services.AddDbContext<CursusContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionStrings:SQL"])
            );

            WebApplication app = builder.Build();
            var context = app.Services.GetRequiredService<CursusContext>();
            context.Database.Migrate();

            app.MapControllers();

            app.Run();
        }
    }
}