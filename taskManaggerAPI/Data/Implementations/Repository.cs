using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;

namespace taskManaggerAPI.Data.Implementations
{
    public class Repository : IRepository
    {
        internal readonly taskManaggerContext _context;

        public Repository(taskManaggerContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
