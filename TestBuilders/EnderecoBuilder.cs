using Bogus;
using BrunSker.ApplicationService.Response.Endereco;
using BrunSker.Domain.Entities;

namespace TestBuilders
{
    public class EnderecoBuilder
    {
        private string _bairro = "bairro here";
        private string _cep = "68926360";
        private string _complemento = "complemento here";
        private string _ddd = "11";
        private string _gia = "1234";
        private string _ibge = "7548";
        private int _id = new Faker().Random.Int(1, 1000);
        private string _localidade = "local here";
        private string _logradouro = "logradouro";
        private string _siafi = "8547";
        private string _uf = "sp";

        public static EnderecoBuilder NewObject()
        {
            return new EnderecoBuilder();
        }

        public Endereco DomainBuild()
        {
            return new Endereco
            {
                Bairro = _bairro,
                Cep = _cep,
                Complemento = _complemento,
                Ddd = _ddd,
                Gia = _gia,
                Ibge = _ibge,
                Id = _id,
                LocacaoId = 1,
                Localidade = _localidade,
                Logradouro = _logradouro,
                Siafi = _siafi,
                Uf = _uf
            };
        }

        public EnderecoResponse ResponseBuild()
        {
            return new EnderecoResponse
            {
                Bairro = _bairro,
                Cep = _cep,
                Complemento = _complemento,
                Ddd = _ddd,
                Gia =_gia,
                Ibge = _ibge,
                Id = _id,
                Localidade = _localidade,
                Logradouro = _logradouro,
                Siafi = _siafi,
                Uf = _uf
            };
        }

        public EnderecoBuilder WithCep(string cep)
        {
            _cep = cep;
            return this;
        }
    }
}
