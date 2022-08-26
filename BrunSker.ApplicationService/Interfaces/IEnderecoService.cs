using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetAddressByCep(string cep);
    }
}
