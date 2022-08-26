using BrunSker.ApplicationService.AutoMapperConfigurations;
using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.ApplicationService.Response.Locacao;
using BrunSker.Business.Extensions;
using BrunSker.Business.Interfaces.Notification;
using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly INotificationHandler _notification;

        public LocacaoService(ILocacaoRepository locacaoRepository, IEnderecoService enderecoService, INotificationHandler notification)
        {
            _locacaoRepository = locacaoRepository;
            _enderecoService = enderecoService;
            _notification = notification;
        }

        public async Task<bool> AddAsync(LocacaoSaveRequest locacaoSaveRequest)
        {
            if (locacaoSaveRequest.Preco < 0)
                return _notification.AddDomainNotification("Preço", "Preço não pode ser menor que 0.");

            locacaoSaveRequest.Cep = locacaoSaveRequest.Cep.CleanCaracters();

            if(locacaoSaveRequest.Cep.Length != 8)
                return _notification.AddDomainNotification("Cep", "Cep deve ter tamanho de 8 caracteres.");

            var locacao = new Locacao()
            {
                Preco = locacaoSaveRequest.Preco,
                EstaLocado = false
            };
            
            var endereco = await _enderecoService.GetAddressByCep(locacaoSaveRequest.Cep);
            
            if (endereco == null)
                return false;

            locacao.Endereco = endereco;

            return await _locacaoRepository.AddAsync(locacao);
        }

        public async Task<bool> UpdateAsync(LocacaoUpdateRequest locacaoUpdateRequest)
        {
            var locacao = await _locacaoRepository.GetLocacaoByIdAsync(locacaoUpdateRequest.Id);

            if(locacao == null)
                return _notification.AddDomainNotification("Locação", "Locação não existe.");

            locacaoUpdateRequest.Cep = locacaoUpdateRequest.Cep.CleanCaracters();

            if (locacaoUpdateRequest.Cep.Length != 8)
                return _notification.AddDomainNotification("Cep", "Cep deve ter tamanho de 8 caracteres.");

            locacao.Preco = locacaoUpdateRequest.Preco;
            locacao.EstaLocado = locacaoUpdateRequest.EstaLocado;
            locacaoUpdateRequest.Cep = locacaoUpdateRequest.Cep.Insert(5, "-");

            if (locacao.Endereco.Cep != locacaoUpdateRequest.Cep)
            {
                var endereco = await _enderecoService.GetAddressByCep(locacaoUpdateRequest.Cep);
                
                if (endereco == null)
                    return false;

                locacao.Endereco = endereco;
            }

            return await _locacaoRepository.UpdateAsync(locacao);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(!await _locacaoRepository.HaveObjectInDb(l => l.Id == id))
                return _notification.AddDomainNotification("Locação", "Locação não existe.");

            return await _locacaoRepository.DeleteAsync(id);
        }

        public async Task<LocacaoResponse> GetLocacaoByIdAsync(int id)
        {
            var locacao = await _locacaoRepository.GetLocacaoByIdAsync(id);

            return locacao.MapTo<Locacao, LocacaoResponse>();
        }

        public async Task<List<LocacaoResponse>> GetAllLocacoesAsync()
        {
            var locacaoList = await _locacaoRepository.GetAllLocacoesAsync();

            return locacaoList.MapTo<List<Locacao>, List<LocacaoResponse>>();
        }

        public void Dispose() => _locacaoRepository.Dispose();
    }
}
