using BrunSker.ApplicationService.Interfaces;
using BrunSker.Business.Interfaces.Notification;
using BrunSker.Domain.Entities;
using RestSharp;

namespace BrunSker.ApplicationService.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly INotificationHandler _notification;

        public EnderecoService(INotificationHandler notification)
        {
            _notification = notification;
        }

        public async Task<Endereco> GetAddressByCep(string cep)
        {
            var restClient = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            
            var restRequest = new RestRequest()
            {
                Method = Method.Get
            };

            var address = await restClient.GetAsync<Endereco>(restRequest);
            
            if(address == null || address.Cep == null)
            {
                _notification.AddDomainNotification("ViaCep", "Objeto não encontrado");
                return null;
            }

            return address;
        }
    }
}
