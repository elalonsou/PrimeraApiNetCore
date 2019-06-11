using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IRecetaRepository: IGenericRepository<Receta>
    {
        IEnumerable<Receta> GetAllByUserId(int userId);

        Task<IEnumerable<Receta>> GetAllByUserIdAsync(int userId);


        Receta GetById(int id);

        Task<Receta> GetByIdAsync(int id);

        IEnumerable<Receta> GetPaginada(int pagina, int cantidad);

        IEnumerable<Receta> GetByUserId(int userId,
           Expression<Func<Receta, bool>> filter = null,
           Func<IQueryable<Receta>, IOrderedQueryable<Receta>> orderBy = null,
           string includeProperties = "");
    }
}