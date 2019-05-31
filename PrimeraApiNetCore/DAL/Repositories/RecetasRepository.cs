using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using DAL.Repositories.Interfaces;
using DAL.Services;
using DAL.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RecetasRepository: GenericRepository<RecetasRepository>, IRecetaRepository
    {
       public RecetasRepository(ApplicationDbContext context) : base(context)
        { }
        
        public IEnumerable<Receta> GetAllByUserId(int userId)
        {
            return _appContext.RecetasUsuarios.Include(x => x.Receta).Where(x => x.UsuarioId == userId).Select(x => x.Receta).ToList();
        }

        public Receta GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receta> GetPaginada(int pagina, int cantidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receta> GetByUserId(int userId, Expression<Func<Receta, bool>> filter = null, Func<IQueryable<Receta>, IOrderedQueryable<Receta>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}