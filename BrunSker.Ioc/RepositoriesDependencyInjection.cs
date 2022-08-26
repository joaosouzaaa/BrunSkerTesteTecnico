using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BrunSker.Ioc
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
        }
    }
}
