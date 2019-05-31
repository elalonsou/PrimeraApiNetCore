using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;

using DAL.Services.Interfaces;
using DAL.Services;


namespace PrimeraApiNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddLogging(builder =>
                   builder.AddConsole()
                          .AddFilter(DbLoggerCategory.Database.Command.Name,
                                     LogLevel.Information));

            //Esto creo que crea un singleton, es decir se crea una única instancia del servicio durante el funcionamiento de la aplicación Web.
            //services.Add(new ServiceDescriptor(typeof(DAL.IHola), new DAL.Services.ApplicationDbContext()));
            
            //Registramos el servicio como Scope
            //services.AddScoped<DAL.IHola, DAL.Hola>();

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("PrimeraApiNetCore"))
                        .EnableSensitiveDataLogging(true)
                        .UseLoggerFactory(services.BuildServiceProvider()
                                        .GetService<ILoggerFactory>())
                
              
            );

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
