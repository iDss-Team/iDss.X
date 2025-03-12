using BootstrapBlazor.Components;
using iDss.X.Data;
using iDss.X.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Components.Pages
{
    public partial class ModulePage
    {
        [Inject] private AppDbContext _db { get; set; } = default!;

        public List<AppModuleCtg> CategoriesWithModules { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            CategoriesWithModules = await _db.app_modulectg
                .Include(ctg => ctg.Modules)
                .OrderBy(ctg => ctg.modulectgsort)
                .ToListAsync();
        }

        private async Task NavigateToHome(string moduleId)
        {
            await session.SetItemAsync("moduleid", moduleId);
            Navigation.NavigateTo("/Home");
        }
    }
}
