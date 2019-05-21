using System;
using System.Collections.Generic;

using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IRecetasRepository
    {
         IEnumerable<Recetas> getAllByUser();
    }
}