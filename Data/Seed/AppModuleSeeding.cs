using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class AppModuleSeeding
    {
        public static void SeedAppModuleCtg(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppModuleCtg>().HasData(new AppModuleCtg[]
            {
            new() { id = 1, modulectgname = "Administrasion", modulectgsort = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 2, modulectgname = "Operasional Cargo", modulectgsort = 2, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 3, modulectgname = "Operasional Credit Card & Billing", modulectgsort = 3, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 4, modulectgname = "Monitoring & Reports", modulectgsort = 4, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 5, modulectgname = "Financial Management", modulectgsort = 5, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 6, modulectgname = "CRM (Customer Relationship Management)", modulectgsort = 6, createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });
        }

        public static void SeedAppModule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppModule>().HasData(new AppModule[]
            {
             new() { moduleid = "101", modulename = "Administrasion", description = "accsess apps configuration dor administrator", modulesort = 1, modulectgid = 1, icon = "idcard", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "102", modulename = "Master Data", description = "iDss Data Master", modulesort = 2, modulectgid = 1, icon = "database", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "103", modulename = "Pickup Management", description = "Pickup Processing Center", modulesort = 3, modulectgid = 2, icon = "schedule", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "104", modulename = "Outbound Control Library", description = "Outbound Processing Center", modulesort = 4, modulectgid = 2, icon = "bank", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "105", modulename = "Linehaul Control Library", description = "Linehaul Processing Center", modulesort = 5, modulectgid = 2, icon = "car", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "106", modulename = "Inbound Control Library", description = "Inbound Processing Center", modulesort = 6, modulectgid = 2, icon = "interaction", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "107", modulename = "Dashboard & Reporting", description = "Dashboard & Reporting", modulesort = 7, modulectgid = 4, icon = "fund", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });
        }
    }
}
