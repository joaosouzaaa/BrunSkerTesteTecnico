using BrunSker.Business.Interfaces.Notification;
using BrunSker.Business.Settings.NotificationSettings;
using BrunSker.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrunSker.Ioc
{
    public static class DependencyInjectionHandler
    {
        public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BrunSkerDbContext>();

            services.AddDbContext<BrunSkerDbContext>(options =>
            {
                var mySqlConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString));
            });

            services.AddScoped<INotificationHandler, NotificationHandler>();

            services.AddRepositoriesDependencyInjection();
            services.AddServicesDependencyInjection();
        }
    }
}
