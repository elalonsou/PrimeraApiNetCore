using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using DAL.Repositories.Interfaces;
using DAL.Services;
using DAL.Models;

namespace DAL.Repositories
{
    public class RecetasRepository: GenericRepository<RecetasRepository>, IRecetaRepository
    {
       public RecetasRepository(ApplicationDbContext context) : base(context)
        { }

        public IEnumerable<Receta> GetAllByUser(int usuarioId)
        {
            return _appContext.Receta.Where(r => r.Id==usuarioId).ToList();
            throw new NotImplementedException();
        }

        public Receta GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receta> GetPaginada(int pagina, int cantidad)
        {
            throw new NotImplementedException();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}