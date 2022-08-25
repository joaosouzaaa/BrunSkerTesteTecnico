using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BrunSker.Ioc
{
    public static class ServicesDependencyInjection
    {
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILeaseService, LeaseService>();
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
