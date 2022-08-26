namespace BrunSker.ApplicationService.Requests.Lease
{
    public class LocacaoUpdateRequest
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public bool EstaLocado { get; set; }
        public string Cep { get; set; }
    }
}
