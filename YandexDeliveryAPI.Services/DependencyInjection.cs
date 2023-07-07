using Microsoft.Extensions.DependencyInjection;
using YandexDeliveryAPI.Services.Interfaces;
using YandexDeliveryAPI.Services.Services;

namespace YandexDeliveryAPI.Services
{
    public static class DependencyInjection
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryService, DeliveryService>();
        }
    }
}
