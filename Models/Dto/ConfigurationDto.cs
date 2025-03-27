
namespace iDss.X.Models
{
    public class AppModuleCtgDto
    {
        public int id { get; set; }

        public String modulectgname { get; set; }

        public int modulectgsort { get; set; }

        public List<AppModuleDto> Modules { get; set; } = new();

    }

    public class AppModuleDto
    {
        public String moduleid { get; set; }

        public String modulename { get; set; }

        public String? description { get; set; }

        public int modulesort { get; set; }

        public int modulectgid { get; set; }

        public String modulectgname { get; set; }

        public String? icon { get; set; }

        public List<AppMenuDto> Menus { get; set; } = new();

        public int totalmenus => Menus?.Count(menu => menu.path != null) ?? 0;
        
        public int totalactivemenus => Menus?.Count(menu => menu.isactive == true && menu.path != null) ?? 0;
    }

    public class AppMenuDto
    {
        public String menuid { get; set; }

        public String menuname { get; set; }

        public String? path { get; set; }

        public String? description { get; set; }

        public int menusort { get; set; }

        public String? parentid { get; set; }

        public String moduleid { get; set; }

        public String modulename { get; set; }

        public String? icon { get; set; }

        public String? properties { get; set; }

        public bool isactive { get; set; }

        public List<AppMenu> submenus { get; set; } = new(); // List untuk submenu

    }
}
