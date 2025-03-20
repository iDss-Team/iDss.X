using BootstrapBlazor.Components;
using iDss.X.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace iDss.X.Services
{
    public static class LookupServiceExtensions
    {
        public static IServiceCollection AddIDSSServices(this IServiceCollection services)
        {
            services.AddScoped<MasterDataServices>(); // Tambahkan service lainnya di sini
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<ILookupService, VillageLookupService>(); // Daftarkan lookup service

            return services;
        }
    }
}
