using Blazored.SessionStorage;
using BootstrapBlazor.Components;
using iDss.X.Data;
using iDss.X.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace iDss.X.Components.Shared
{

    public sealed partial class MainLayout
    {
        [Inject] private AppDbContext _db { get; set; } = default!;
        [Inject] private ISessionStorageService SessionStorage { get; set; } = default!;

        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsConfOpen { get; set; }
        private bool IsModOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private string ModuleID { get; set; } = "";

        public List<MenuItem> Menus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            ModuleID = await session.GetItemAsync<string>("moduleid") ?? "0";

            var menuList = await _db.app_menu
                 .Where(m => m.moduleid == ModuleID)
                 .OrderBy(m => m.menuid)
                 .ToListAsync();
            Menus = ConvertToMenuItems(menuList);
        }

        private List<MenuItem> ConvertToMenuItems(List<AppMenu> appMenus)
        {
            // 1️ Konversi AppMenu ke MenuItem (tanpa struktur parent-child)
            var menuItems = appMenus.Select(m => new MenuItem
            {
                Text = m.menuname,
                Icon = m.icon,
                Url = m.path,
                Items = new List<MenuItem>() // Submenu akan ditambahkan nanti
            }).ToList();

            // 2️ Buat Dictionary untuk lookup berdasarkan menuid
            var menuDictionary = menuItems.ToDictionary(m => m.Text ?? "unknown");

            // 3️ Hubungkan parent dengan child berdasarkan parentid
            foreach (var appMenu in appMenus)
            {
                if (!string.IsNullOrEmpty(appMenu.parentid)) // Jika memiliki parent
                {
                    var parentMenuKey = appMenus.FirstOrDefault(a => a.menuid == appMenu.parentid)?.menuname;
                    if (parentMenuKey != null && menuDictionary.TryGetValue(parentMenuKey, out var parentMenu))
                    {
                        if (parentMenu.Items is List<MenuItem> submenuList)
                        {
                            submenuList.Add(menuDictionary[appMenu.menuname]);
                        }
                        else
                        {
                            // Jika Items bukan List<MenuItem>, buat List baru dan assign kembali
                            parentMenu.Items = new List<MenuItem>(parentMenu.Items) { menuDictionary[appMenu.menuname] };
                        }
                    }
                }
            }

            // 4️ Kembalikan hanya menu utama (tanpa parentid)
            var finalMenu =  menuItems.Where(m => !appMenus.Any(a => a.menuname == m.Text && !string.IsNullOrEmpty(a.parentid))).ToList();

            // ✅ 5️ Tambahkan menu "Home" secara manual di awal
            finalMenu.Insert(0, new MenuItem
            {
                Text = "Home",
                Icon = "fa-solid fa-fw fa-home",
                Url = "/home",
                Items = new List<MenuItem>()
            });

            return finalMenu;
        }

    }
}
