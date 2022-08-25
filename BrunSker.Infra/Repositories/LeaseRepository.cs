using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Domain.Entities;
using BrunSker.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrunSker.Infra.Repositories
{
    public class LeaseRepository : ILeaseRepository
    {
        private readonly BrunSkerDbContext _context;
        public DbSet<Lease> _dbContextSet => _context.Set<Lease>();

        public LeaseRepository(BrunSkerDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveDbAsync() => await _context.SaveChangesAsync() > 0;

        public async Task<bool> AddAsync(Lease lease)
        {
            await _dbContextSet.AddAsync(lease);

            return await SaveDbAsync();
        }

        public async Task<bool> UpdateLeaseAsync(Lease lease)
        {
            _context.Entry(lease).State = EntityState.Modified;

            return await SaveDbAsync();
        }

        public async Task<bool> UpdateAsync(Lease lease)
        {
            _context.Entry(lease).State = EntityState.Modified;
            _context.Entry(lease.Address).State = EntityState.Modified;

            return await SaveDbAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lease = await _dbContextSet.Include(l => l.Address).FirstOrDefaultAsync(l => l.Id == id);

            _dbContextSet.Remove(lease);

            return await SaveDbAsync();
        }

        public async Task<Lease> GetLeaseByIdAsync(int id) =>
            await _dbContextSet.Include(l => l.Address).FirstOrDefaultAsync(l => l.Id == id);
        
        public async Task<List<Lease>> GetAllLeasesAsync() =>
            await _dbContextSet.Include(l => l.Address).ToListAsync();

        public async Task<bool> HaveObjectInDb(Expression<Func<Lease, bool>> where) => await _dbContextSet.AnyAsync(where);

        public void Dispose() => _context.Dispose();
    }
}
