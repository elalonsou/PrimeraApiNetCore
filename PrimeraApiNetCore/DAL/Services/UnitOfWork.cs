using DAL.Repositories.Interfaces;
using DAL.Repositories;

namespace DAL.Services
{
    public class UnitOfWork: Interfaces.IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IRecetaRepository _recetas;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRecetaRepository Recetas
        {
            get
            {
                if (_recetas == null)
                    _recetas = new RecetasRepository(_context);

                return _recetas;
            }
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}