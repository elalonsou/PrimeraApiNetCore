using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using DAL.Repositories.Interfaces;
using DAL.Services;
using DAL.Models;

namespace DAL.Repositories
{
    public class RecetasRepository: GenericRepository<RecetasRepository>, IRecetasRepository
    {
       public RecetasRepository(ApplicationDbContext context) : base(context)
        { }

       public IEnumerable<Recetas> getAllByUser()
       { 
            return _appContext.Recetas.Where(r => r.nombre.Contains("Pollo")).ToList();
       }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}