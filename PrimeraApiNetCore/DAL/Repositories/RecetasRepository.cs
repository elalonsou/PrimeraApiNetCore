using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using DAL.Repositories.Interfaces;
using DAL.Services;
using DAL.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RecetasRepository: GenericRepository<Receta>, IRecetaRepository
    {
       public RecetasRepository(ApplicationDbContext context) : base(context)
        { }
        
        public IEnumerable<Receta> GetAllByUserId(int userId)
        {
            return _appContext.RecetasUsuarios.Include(x => x.Receta).Where(x => x.UsuarioId == userId).Select(x => x.Receta).ToList();
        }

        public async Task <IEnumerable<Receta>> GetAllByUserIdAsync(int userId)
        {
            return await _appContext.RecetasUsuarios.Include(x => x.Receta).Where(x => x.UsuarioId == userId).Select(x => x.Receta).ToListAsync();
        }

        public Receta GetById(int id)
        {
            return _appContext.Recetas.Where(x => x.Id==id).FirstOrDefault();
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