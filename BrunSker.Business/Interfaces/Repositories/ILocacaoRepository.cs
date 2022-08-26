using BrunSker.Domain.Entities;
using System.Linq.Expressions;

namespace BrunSker.Business.Interfaces.Repositories
{
    public interface ILocacaoRepository : IDisposable
    {
        Task<bool> AddAsync(Locacao lease);
        Task<bool> UpdateAsync(Locacao lease);
        Task<bool> DeleteAsync(int id);
        Task<Locacao> GetLocacaoByIdAsync(int id);
        Task<List<Locacao>> GetAllLocacoesAsync();
        Task<bool> HaveObjectInDb(Expression<Func<Locacao, bool>> where);
    }
}
