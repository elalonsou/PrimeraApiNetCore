using DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DAL.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IRecetaRepository Recetas { get; }
      
        

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}