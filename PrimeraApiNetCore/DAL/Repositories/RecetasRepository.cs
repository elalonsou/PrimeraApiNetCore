using System;
using System.Collections.Generic;
using System.Data;

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
           return new List<Recetas>();
       }
    }
}