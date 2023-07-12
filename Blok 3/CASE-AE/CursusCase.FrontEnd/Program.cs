using CursusCase.FrontEnd.Repositories;
using CursusCase.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CursusCase.FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddRazorPages()
                .AddRazorPagesOptions(o =>
                {
                    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
                });
            builder.Services.AddTransient<ICursusInstanceRepo, CursusInstanceRepo>();
            WebApplication app = builder.Build();
            app.MapRazorPages();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
// testje