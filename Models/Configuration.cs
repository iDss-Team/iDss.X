using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iDss.X.Models
{
    public class AppModuleCtg : CommonField1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)] 
        public String modulectgname { get; set; }

        public int modulectgsort { get; set; }

        [ValidateNever]
        public virtual ICollection<AppModule> Modules { get; set; } = new List<AppModule>();

    }

    public class AppModule : CommonField2
    {
        [Key]
        [StringLength(5)] 
        public String moduleid { get; set; }

        [StringLength(30)] 
        public String modulename { get; set; }

        public String? description { get; set; }

        public int modulesort { get; set; }

        [ValidateNever]
        [Required]
        [Display(Name = "Module Category")] 
        public int modulectgid { get; set; }
        [ForeignKey("modulectgid")]
        [ValidateNever] 
        public AppModuleCtg ModuleCtg { get; set; }

        [StringLength(50)] 
        public String? icon { get; set; }

        [ValidateNever] 
        public virtual ICollection<AppMenu> Menus { get; set; } = new List<AppMenu>();

        [NotMapped]
        public int TotalMenus => Menus?.Count(menu => menu.path != null) ?? 0;
        
        [NotMapped]
        public int TotalActiveMenus => Menus?.Count(menu => menu.flag == 1 && menu.path != null) ?? 0;
    }

    public class AppMenu : CommonField2
    {
        [Key][StringLength(10)] public String menuid { get; set; }

        [StringLength(50)] public String menuname { get; set; }

        [StringLength(100)] public String? path { get; set; }

        public String? description { get; set; }

        public int menusort { get; set; }

        [StringLength(10)] public String? parentid { get; set; }

        [StringLength(5)][ValidateNever][Required][Display(Name = "Module")] public String moduleid { get; set; }
        [ForeignKey("moduleid")][ValidateNever] public AppModule Module { get; set; }

        [StringLength(50)] public String? icon { get; set; }

        [StringLength(100)] public String? properties { get; set; }

        [NotMapped] public List<AppMenu> submenus { get; set; } = new(); // List untuk submenu

    }
}
