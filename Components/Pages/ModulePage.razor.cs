using AutoMapper;
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
        [Inject] private IMapper _mapper { get; set; } = default!;

        public List<AppModuleCtg> CategoriesWithModules { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            //var authState = await AuthProvider.GetAuthenticationStateAsync();
            //var user = authState.User;

            //System.Console.WriteLine("Authenticated: " + user.Identity?.IsAuthenticated);
            //System.Console.WriteLine("Username: " + user.Identity?.Name);

            CategoriesWithModules = await _db.app_modulectg
                .Include(ctg => ctg.Modules)
                .ThenInclude(mod => mod.Menus)
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
