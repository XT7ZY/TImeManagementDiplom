using TImeManagement.Data.Interfaces;
using TImeManagement.Models;

namespace TImeManagement.Data.Repositories
{
    public class RolesRepository : IRolesRepository<Role>
    {
        private readonly ApplicationDbContext _db;

        public RolesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Role> GetAll()
        {
            return _db.roles;
        }
    }
}
