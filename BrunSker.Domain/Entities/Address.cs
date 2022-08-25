using BrunSker.Domain.Entities.EntitiesBase;

namespace BrunSker.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string? Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public Lease Lease { get; set; }
        //public string ZipCode { get; set; }
        //public string Street { get; set; }
        //public string? Complement { get; set; }
        //public string District { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Ibge { get; set; }
        //public string? Gia { get; set; }
        //public string Ddd { get; set; }
        //public string Siafi { get; set; }
    }
}
