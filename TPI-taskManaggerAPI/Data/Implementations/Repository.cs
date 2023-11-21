using TPI_taskManaggerAPI.Data.Interfaces;
using TPI_taskManaggerAPI.DBContext;

namespace TPI_taskManaggerAPI.Data.Implementations
{
    public class Repository : IRepository
    {
        internal readonly taskManaggerContext _context;

        public Repository(taskManaggerContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
