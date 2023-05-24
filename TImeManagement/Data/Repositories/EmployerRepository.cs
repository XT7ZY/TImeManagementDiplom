using TImeManagement.Data.Interfaces;
using TImeManagement.Models;

namespace TImeManagement.Data.Repositories
{
    public class EmployerRepository : IBaseRepository<Employer>
    {
        private readonly ApplicationDbContext _db;
        public EmployerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Employer entity)
        {
            await _db.employers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Employer entity)
        {
            _db.employers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Employer> GetAll()
        {
            return _db.employers;
        }

        public async Task<Employer> Update(Employer entity)
        {
            _db.employers.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
