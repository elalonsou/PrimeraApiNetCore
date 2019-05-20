using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace DAL.Services
{
    public class ApplicationDbContext: DbContext
    {
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Usamos una instancia de SqlServer localDb que es suficiente para realizar este demo.
            //Tambien configuramos para que las consultas que se realicen se muestren por consola.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=PrimeraApiNetCore;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(GetLoggerFactory());
          }

        //Con este metodo conseguimos que las querys a BBDD se registren en la consola.
        // El uso del Logger Factory es nuevo en Entity Framework core 2.2
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                   builder.AddConsole()
                          .AddFilter(DbLoggerCategory.Database.Command.Name,
                                     LogLevel.Information));
                       
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

        }

     
    }
}