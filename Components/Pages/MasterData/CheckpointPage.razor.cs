using BootstrapBlazor.Components;
using iDss.X.Data;
using iDss.X.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace iDss.X.Components.Pages.MasterData
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CheckpointPage : ComponentBase
    {
        [Inject]
        private AppDbContext _db { get; set; } = default!;

        /// <summary>
        /// Mendapatkan/Mengatur sumber data konfigurasi paginasi
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        [NotNull]
        public List<Checkpoint> Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<Checkpoint>, string, SortOrder, IEnumerable<Checkpoint>>> SortLambdaCache = new();

        private Task<QueryData<Checkpoint>> OnQueryAsync(QueryPageOptions options)
        {
            var items = _db.mdt_checkpoint.ToList();

            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Checkpoint model)
            {
                if (!string.IsNullOrEmpty(model.cpcode))
                {
                    items = items.Where(item => item.cpcode?.Contains(model.cpcode, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                if (!string.IsNullOrEmpty(model.cpname))
                {
                    items = items.Where(item => item.cpname?.Contains(model.cpname, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                }

                isSearched = !string.IsNullOrEmpty(model.cpcode) || !string.IsNullOrEmpty(model.cpname);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Checkpoint>(FilterLogic.Or)).ToList();
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Checkpoint>()).ToList();
                isFiltered = true;
            }

            // Pengurutan
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
                var invoker = SortLambdaCache.GetOrAdd(typeof(Checkpoint), key => LambdaExtensions.GetSortLambda<Checkpoint>().Compile());
                items = (List<Checkpoint>)invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<Checkpoint>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

    }
}
