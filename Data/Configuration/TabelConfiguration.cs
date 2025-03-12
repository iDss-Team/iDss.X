using iDss.X.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDss.X.Data.Configuration
{
    public class AppModuleConfiguration : IEntityTypeConfiguration<AppModule>
    {
        public void Configure(EntityTypeBuilder<AppModule> builder)
        {
            builder.HasKey(m => m.moduleid); // Menentukan Primary Key

            builder.HasOne(m => m.ModuleCtg) // Relasi ke AppModuleCategory
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.modulectgid) // Foreign Key
                .OnDelete(DeleteBehavior.Restrict); // **Restrict (Mencegah Cascade Delete)**
        }
    }

    public class AppMenuConfiguration : IEntityTypeConfiguration<AppMenu>
    {
        public void Configure(EntityTypeBuilder<AppMenu> builder)
        {
            builder.HasKey(m => m.menuid); // Menentukan Primary Key

            builder.HasOne(m => m.Module) // Relasi ke AppModule
                .WithMany(c => c.Menus)
                .HasForeignKey(m => m.moduleid) // Foreign Key
                .OnDelete(DeleteBehavior.Restrict); // **Restrict (Mencegah Cascade Delete)**
        }
    }
}
