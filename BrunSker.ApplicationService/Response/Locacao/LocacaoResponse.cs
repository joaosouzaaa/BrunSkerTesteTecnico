using BrunSker.ApplicationService.Response.Endereco;

namespace BrunSker.ApplicationService.Response.Locacao
{
    public class LocacaoResponse
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public bool EstaLocado { get; set; }

        public EnderecoResponse EnderecoResponse { get; set; }
    }
}
