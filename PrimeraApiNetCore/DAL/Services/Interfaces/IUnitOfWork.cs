using DAL.Repositories.Interfaces;

namespace DAL.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IRecetaRepository Recetas { get; }
      
        

        int SaveChanges();
    }
}