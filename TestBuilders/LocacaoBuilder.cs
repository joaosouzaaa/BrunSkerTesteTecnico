using Bogus;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.ApplicationService.Response.Locacao;
using BrunSker.Domain.Entities;

namespace TestBuilders
{
    public class LocacaoBuilder
    {
        private decimal _preco = 20;
        private string _cep = "29705042";
        private int _id = new Faker().Random.Int(1, 1000);
        private bool _estaLocado = false;
        private Endereco _endereco = EnderecoBuilder.NewObject().DomainBuild();

        public static LocacaoBuilder NewObject()
        {
            return new LocacaoBuilder();
        }

        public Locacao DomainBuild()
        {
            return new Locacao
            {
                EstaLocado = _estaLocado,
                Endereco = _endereco,
                Id = _id,
                Preco = _preco
            };
        }

        public LocacaoSaveRequest SaveRequestBuild()
        {
            return new LocacaoSaveRequest
            {
                Preco = _preco,
                Cep = _cep
            };
        }

        public LocacaoUpdateRequest UpdateRequestBuild()
        {
            return new LocacaoUpdateRequest
            {
                Cep = _cep,
                EstaLocado = _estaLocado,
                Id = _id,
                Preco = _preco
            };
        }

        public LocacaoResponse ResponseBuild()
        {
            return new LocacaoResponse
            {
                EnderecoResponse = EnderecoBuilder.NewObject().ResponseBuild(),
                EstaLocado = _estaLocado,
                Id = _id,
                Preco = _preco
            };
        }

        public LocacaoBuilder WithPreco(decimal preco)
        {
            _preco = preco;
            return this;
        }

        public LocacaoBuilder WithCep(string cep)
        {
            _cep = cep;
            return this;
        }

        public LocacaoBuilder WithEndereco(Endereco endereco)
        {
            _endereco = endereco;
            return this;
        }

        public LocacaoBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
    }
}
