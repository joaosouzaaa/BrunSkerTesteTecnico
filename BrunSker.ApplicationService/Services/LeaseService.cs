using BrunSker.ApplicationService.AutoMapperConfigurations;
using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.Business.Interfaces.Notification;
using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.Services
{
    public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;
        private readonly IAddressService _addressService;
        private readonly INotificationHandler _notification;

        public LeaseService(ILeaseRepository leaseRepository, IAddressService addressService, INotificationHandler notification)
        {
            _leaseRepository = leaseRepository;
            _addressService = addressService;
            _notification = notification;
        }

        public async Task<bool> AddAsync(LeaseSaveRequest leaseSaveRequest)
        {
            if (leaseSaveRequest.Price < 0)
                return _notification.AddDomainNotification("Price", "Price less than 0.");

            var lease = new Lease()
            {
                Price = leaseSaveRequest.Price
            };

            lease.IsRented = false;
            
            var address = await _addressService.GetAddressByCep(leaseSaveRequest.Cep);
            
            if (address == null)
                return false;

            lease.Address = address;

            return await _leaseRepository.AddAsync(lease);
        }

        public async Task<bool> UpdateLeaseAsync(FinishLeaseRequest finishLeaseRequest)
        {
            var lease = await _leaseRepository.GetLeaseByIdAsync(finishLeaseRequest.Id);

            if (lease == null)
                return _notification.AddDomainNotification("Lease", "Lease does not exist.");

            if (finishLeaseRequest.Price < lease.Price)
                return _notification.AddDomainNotification("Price", "The price to finish the lease has to be bigger than the actual price.");

            lease.IsRented = true;

            return await _leaseRepository.UpdateLeaseAsync(lease);
        }

        public async Task<bool> UpdateAsync(LeaseUpdateRequest leaseUpdateRequest)
        {
            if (!await _leaseRepository.HaveObjectInDb(l => l.Id == leaseUpdateRequest.Id))
                return _notification.AddDomainNotification("Lease", "Lease does not exist.");

            var lease = leaseUpdateRequest.MapTo<LeaseUpdateRequest, Lease>();

            return await _leaseRepository.UpdateAsync(lease);
        }

        public void Dispose() => _leaseRepository.Dispose();
    }
}
