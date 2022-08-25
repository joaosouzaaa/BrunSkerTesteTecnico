using BrunSker.Domain.Entities;
using System.Linq.Expressions;

namespace BrunSker.Business.Interfaces.Repositories
{
    public interface ILeaseRepository : IDisposable
    {
        Task<bool> AddAsync(Lease lease);
        Task<bool> UpdateLeaseAsync(Lease lease);
        Task<bool> UpdateAsync(Lease lease);
        Task<bool> DeleteAsync(int id);
        Task<Lease> GetLeaseByIdAsync(int id);
        Task<List<Lease>> GetAllLeasesAsync();
        Task<bool> HaveObjectInDb(Expression<Func<Lease, bool>> where);
    }
}
