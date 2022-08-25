using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddressByCep(string cep);
    }
}
