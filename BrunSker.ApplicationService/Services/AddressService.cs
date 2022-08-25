using BrunSker.ApplicationService.Interfaces;
using BrunSker.Business.Interfaces.Notification;
using BrunSker.Domain.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace BrunSker.ApplicationService.Services
{
    public class AddressService : IAddressService
    {
        private readonly INotificationHandler _notification;

        public AddressService(INotificationHandler notification)
        {
            _notification = notification;
        }

        public async Task<Address> GetAddressByCep(string cep)
        {
            var restClient = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            
            var restRequest = new RestRequest()
            {
                Method = Method.Get
            };

            var restResponse = await restClient.GetAsync(restRequest);

            if (restResponse.IsSuccessful)
                return JsonConvert.DeserializeObject<Address>(restResponse.Content);

            _notification.AddDomainNotification("ViaCep", $"Sua requisição não teve sucesso com a mensagem: {restResponse.ErrorMessage}");
            return null;
        }
    }
}
