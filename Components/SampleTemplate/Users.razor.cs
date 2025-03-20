using BootstrapBlazor.Components;
using iDss.X.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace iDss.X.Components.SampleTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Users
    {
        [Inject]
        [NotNull]
        private IStringLocalizer<Foo>? Localizer { get; set; }

        /// <summary>
        /// Mendapatkan/Mengatur sumber data konfigurasi paginasi
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        private static string GetAvatarUrl(int id) => $"images/avatars/150-{id}.jpg";

        private static Color GetProgressColor(int count) => count switch
        {
            >= 0 and < 10 => Color.Secondary,
            >= 10 and < 20 => Color.Danger,
            >= 20 and < 40 => Color.Warning,
            >= 40 and < 50 => Color.Info,
            >= 50 and < 70 => Color.Primary,
            _ => Color.Success
        };

        [NotNull]
        private IEnumerable<Foo>? Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<Foo>, string, SortOrder, IEnumerable<Foo>>> SortLambdaCache = new();

        private readonly ConcurrentDictionary<Foo, IEnumerable<SelectedItem>> _cache = new();
        private IEnumerable<SelectedItem> GetHobbys(Foo item) => _cache.GetOrAdd(item, f => Foo.GenerateHobbys(Localizer));

        private Task<QueryData<Foo>> OnQueryAsync(QueryPageOptions options)
        {
            // Kode ini tidak dapat digunakan dalam praktik sebenarnya, hanya ditulis untuk demonstrasi guna mencegah penghapusan semua data.
            if (Items == null || !Items.Any())
            {
                Items = Foo.GenerateFoo(Localizer, 23).ToList();
            }

            var items = Items;
            var isSearched = false;
            // Memproses kueri tingkat lanjut.
            if (options.SearchModel is Foo model)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Address))
                {
                    items = items.Where(item => item.Address?.Contains(model.Address, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Address);
            }

            if (options.Searches.Any())
            {
                // Melakukan pencarian fuzzy berdasarkan SearchText
                items = items.Where(options.Searches.GetFilterFunc<Foo>(FilterLogic.Or));
            }

            // Penyaringan
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Foo>());
                isFiltered = true;
            }

            // Pengurutan
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // Jika tidak dilakukan pengurutan di bagian eksternal, maka pengurutan akan dilakukan secara otomatis di bagian internal.
                var invoker = SortLambdaCache.GetOrAdd(typeof(Foo), key => LambdaExtensions.GetSortLambda<Foo>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<Foo>()
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
