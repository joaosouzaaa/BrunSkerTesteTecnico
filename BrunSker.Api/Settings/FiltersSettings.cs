using BrunSker.Api.Filters;

namespace BrunSker.Api.Settings
{
    public static class FiltersSettings
    {
        public static void AddFiltersSettings(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.AddService<NotificationFilter>();
            });

            services.AddScoped<NotificationFilter>();
        }
    }
}
