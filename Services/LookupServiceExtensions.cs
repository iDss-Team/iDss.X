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
            services.AddScoped<MasterDataPart1Service>(); // Service Taufan
            services.AddScoped<MasterDataPart2Service>(); // Service Andri
            services.AddScoped<MasterDataPart3Service>(); // Service Arbi
            services.AddScoped<OutboundService>(); 
            services.AddScoped<PickupService>(); 
            services.AddSingleton<WeatherForecastService>();
            //services.AddScoped<ILookupService, VillageLookupService>(); // Daftarkan lookup service

            return services;
        }
    }
}
