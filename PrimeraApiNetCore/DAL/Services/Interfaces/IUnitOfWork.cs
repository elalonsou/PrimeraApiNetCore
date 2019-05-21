using DAL.Repositories.Interfaces;

namespace DAL.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IRecetasRepository Recetas { get; }
      
        int SaveChanges();
    }
}