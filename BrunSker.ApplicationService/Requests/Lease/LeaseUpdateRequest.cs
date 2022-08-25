using BrunSker.ApplicationService.Requests.Address;

namespace BrunSker.ApplicationService.Requests.Lease
{
    public class LeaseUpdateRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool IsRented { get; set; }

        public AddressUpdateRequest AddressUpdateRequest { get; set; }
    }
}
