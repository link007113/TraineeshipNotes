using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok2.HamelenTravelDocus.DAL
{
    public class ContextHelper
    {
        public static WegUitHamelenContext GetContext(DbContextOptions<WegUitHamelenContext> contextOptions)
        {
            var context = new WegUitHamelenContext(contextOptions);
            context.Database.EnsureCreated();
            return context;
        }

        public static DbContextOptions<WegUitHamelenContext> GetOptions(bool test = false)
        {
            if (test)
            {
                var connection = new SqliteConnection("Filename=:memory:");
                connection.Open();

                var contextOptions = new DbContextOptionsBuilder<WegUitHamelenContext>()
                .UseSqlite(connection)
                .Options;
                return contextOptions;
            }
            else
            {
                string connectionString = @$"Server=localhost;User=SA;Password=Geheim101!;Database=WegUitHamelen;TrustServerCertificate=true;MultipleActiveResultSets=True";
                var contextOptions = new DbContextOptionsBuilder<WegUitHamelenContext>()
                 .UseSqlServer(connectionString)
             .Options;
                return contextOptions;
            }
        }
    }
}