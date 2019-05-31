using System;
using System.Collections.Generic;

using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IRecetaRepository
    {
        IEnumerable<Receta> GetAllByUser(int usuarioId);

        Receta GetById();

        IEnumerable<Receta> GetPaginada(int pagina, int cantidad);

    }
}