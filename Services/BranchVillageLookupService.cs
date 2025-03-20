using BootstrapBlazor.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace iDss.X.Services
{
    public class VillageLookupService(IServiceProvider provider) : LookupServiceBase
    {
        private readonly IServiceProvider _provider = provider;

        public override IEnumerable<SelectedItem>? GetItemsByKey(string? key, object? data)
        {
            if (key == "branch.villages")
            {
                using var scope = _provider.CreateScope();
                var masterDataService = scope.ServiceProvider.GetRequiredService<MasterDataServices>();

                var villages = masterDataService.GetAllVillages().ToList();
                return villages.Select(v => new SelectedItem(v.villid, v.villname ?? "Unknown")).ToList();
            }
            return new List<SelectedItem>();
        }
    }
}
