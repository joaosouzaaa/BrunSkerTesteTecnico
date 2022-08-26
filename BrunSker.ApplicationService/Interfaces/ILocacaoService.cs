using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.ApplicationService.Response.Locacao;

namespace BrunSker.ApplicationService.Interfaces
{
    public interface ILocacaoService : IDisposable
    {
        Task<bool> AddAsync(LocacaoSaveRequest locacaoSaveRequest);
        Task<bool> UpdateAsync(LocacaoUpdateRequest locacaoUpdateRequest);
        Task<bool> DeleteAsync(int id);
        Task<LocacaoResponse> GetLocacaoByIdAsync(int id);
        Task<List<LocacaoResponse>> GetAllLocacoesAsync();
    }
}
