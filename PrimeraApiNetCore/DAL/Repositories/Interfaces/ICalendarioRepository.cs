using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface ICalendarioRepository
    {
        IEnumerable<Calendario> GetAllByUserId(int userId);

        Calendario GetById();

        IEnumerable<Calendario> GetPaginada(int pagina, int cantidad);

        IEnumerable<Calendario> GetByUserId(int userId,
           Expression<Func<Calendario, bool>> filter = null,
           Func<IQueryable<Calendario>, IOrderedQueryable<Calendario>> orderBy = null,
           string includeProperties = "");
    }
}
