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
            await Eliminar();

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

            //---------  Recetas y recetas usuarios  -----------------
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

            Receta rec_3 = new Receta
            {
                Nombre = "Lubina plancha",
                RecetasUsuarios = new List<RecetaUsuario>(){
                        new RecetaUsuario (){Usuario=user_1,Propietario=true},
                        new RecetaUsuario (){Usuario=user_2,Propietario=false}
                    }
            };

            //------------- Calendarios ------------------
            Calendario cal_1 = new Calendario
            {
                Nombre= "Calendario Sergio",
                CalendariosUsuarios  = new List<CalendarioUsuario>
                {
                    new CalendarioUsuario(){Propietario=true, Usuario = user_1}
                }
            };

            Calendario cal_2 = new Calendario
            {
                Nombre = "Calendario Victor",
                CalendariosUsuarios = new List<CalendarioUsuario>
                {
                    new CalendarioUsuario(){Propietario=true, Usuario = user_2}
                }
            };

            Calendario cal_3 = new Calendario
            {
                Nombre = "Calendario Sergio 2",
                CalendariosUsuarios = new List<CalendarioUsuario>
                {
                    new CalendarioUsuario(){Propietario=true, Usuario = user_1},
                    new CalendarioUsuario(){Propietario=false, Usuario = user_2}
                }
            };

            //-------------  Planes  -------------------
            Planificacion plan_1 = new Planificacion
            {
                Calendario = cal_1,
                Fecha = DateTime.Now,
                TipoPlanificacion = TipoPlanificacion.Cena,
                PlanificacionesRecetas = new List<PlanificacionReceta>
                {
                    new PlanificacionReceta(){ Receta=rec_1 }
                }
            };

            Planificacion plan_2 = new Planificacion
            {
                Calendario = cal_1,
                Fecha = new DateTime(2019,01,05),
                TipoPlanificacion = TipoPlanificacion.Comida,
                PlanificacionesRecetas = new List<PlanificacionReceta>
                {
                    new PlanificacionReceta(){ Receta=rec_3 }
                }
            };


            Planificacion plan_3 = new Planificacion
            {
                Calendario = cal_2,
                Fecha = DateTime.Now,
                TipoPlanificacion = TipoPlanificacion.Cena,
                PlanificacionesRecetas = new List<PlanificacionReceta>
                {
                    new PlanificacionReceta(){ Receta=rec_2 }
                }
            };

            Planificacion plan_4 = new Planificacion
            {
                Calendario = cal_1,
                Fecha = new DateTime(2019, 01, 05),
                TipoPlanificacion = TipoPlanificacion.Cena,
                PlanificacionesRecetas = new List<PlanificacionReceta>
                {
                    new PlanificacionReceta(){ Receta=rec_1 },
                    new PlanificacionReceta(){ Receta=rec_3 }
                }
            };

            _context.Usuarios.Add(user_1);
            _context.Usuarios.Add(user_2);

            _context.Recetas.Add(rec_1);
            _context.Recetas.Add(rec_2);
            _context.Recetas.Add(rec_3);

            _context.Calendarios.Add(cal_1);
            _context.Calendarios.Add(cal_1);
            _context.Calendarios.Add(cal_1);

            _context.Planificaciones.Add(plan_1);
            _context.Planificaciones.Add(plan_2);
            _context.Planificaciones.Add(plan_3);
            _context.Planificaciones.Add(plan_4);

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar()
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [Recetas]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [RecetasUsuarios]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [Usuarios]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [PlanificacionReceta]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [Planificaciones]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [CalendariosUsuarios]");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [Calendarios]");

        }
    }

}
