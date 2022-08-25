using BrunSker.Domain.Entities.EntitiesBase;

namespace BrunSker.Domain.Entities
{
    public class Lease : BaseEntity
    {
        public decimal Price { get; set; }
        public bool IsRented { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
