using DAL.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Services
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }


    public class DatabaseInitializer: IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;

        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

          
                Usuario user_1 = new Usuario
                {
                    Nombre = "Sergio",
                    Apellidos = "Diaz Martinez",
                    Alias = "SergioAlias",
                    Email = "pruebaSergio@email.com"
                };

                Usuario user_2 = new Usuario
                {
                    Nombre = "Victor",
                    Apellidos = "Gonzalez Perez",
                    Alias = "VictorAlias",
                    Email = "pruebaVictor@email.com"
                };


                Receta rec_1 = new Receta
                {
                    Nombre = "Lentejas Veganas",
                    Puntuacion = 5,
                    RecetasUsuarios = new List<RecetaUsuario>(){
                        new RecetaUsuario (){Usuario=user_1,Propietario=true}
                    }
                };

                Receta rec_2 = new Receta
                {
                    Nombre = "Pollo Plancha",
                    Puntuacion = 4,
                    RecetasUsuarios = new List<RecetaUsuario>(){
                        new RecetaUsuario (){Usuario=user_2,Propietario=true}
                    }
                };

            _context.Usuarios.Add(user_1);
            _context.Usuarios.Add(user_2);

            _context.Recetas.Add(rec_1);
            _context.Recetas.Add(rec_2);

            await _context.SaveChangesAsync();
        }


    }
}
