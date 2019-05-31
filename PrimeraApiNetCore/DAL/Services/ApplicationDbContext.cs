using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using DAL.Models;


namespace DAL.Services
{
    public class ApplicationDbContext: DbContext
    {
        public string CurrentUserId { get; set; }

        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Planificacion> Planificaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<CalendarioUsuario> CalendariosUsuarios { get; set; }

        public DbSet<RecetaUsuario> RecetasUsuarios { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        /* 
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
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder
               .Entity<Planificacion>()
               .Property(e => e.TipoPlanificacion)
               .HasConversion<string>();

            modelBuilder.Entity<CalendarioUsuario>().HasKey(p => new { p.CalendarioId, p.UsuarioId });
            modelBuilder.Entity<RecetaUsuario>().HasKey(p => new { p.RecetaId, p.UsuarioId });
            modelBuilder.Entity<PlanificacionReceta>().HasKey(p => new { p.RecetaId, p.PlanificacionId });
        }

     
    }
}