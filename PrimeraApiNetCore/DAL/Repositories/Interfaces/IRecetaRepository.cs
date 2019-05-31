using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IRecetaRepository
    {
        IEnumerable<Receta> GetAllByUserId(int userId);

        Receta GetById();

        IEnumerable<Receta> GetPaginada(int pagina, int cantidad);

        IEnumerable<Receta> GetByUserId(int userId,
           Expression<Func<Receta, bool>> filter = null,
           Func<IQueryable<Receta>, IOrderedQueryable<Receta>> orderBy = null,
           string includeProperties = "");
    }
}