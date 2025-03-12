using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class AppMenuSeeding
    {
        public static void SeedAppMenu(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppMenu>().HasData(new AppMenu[]
            {
                new() { menuid = "1.1", menuname = "Identity", path = null, menusort = 1, parentid = "", moduleid = "101", icon ="fa-solid fa-fingerprint", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "1.1.1", menuname = "User Data", path = "/admin/user", menusort = 1, parentid = "1.1", moduleid = "101", icon ="fa-solid fa-user", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "1.1.2", menuname = "Role Data", path = "/admin/role", menusort = 1, parentid = "1.1", moduleid = "101", icon ="fa-solid fa-user-shield", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "1.2", menuname = "Configuration", path =null, menusort = 2, parentid = "", moduleid = "101", icon ="fa-solid fa-wrench", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "1.2.1", menuname = "Audittrail", path = "/admin/audittrail", menusort = 1, parentid = "1.2", moduleid = "101", icon ="fa-solid fa-shoe-prints", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "1.2.2", menuname = "Preparing Sign-out", path = "/admin/preparingsignout", menusort = 1, parentid = "1.2", moduleid = "101", icon ="fa-solid fa-bell", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1", menuname = "Branch & Agent", path = null, menusort = 1, parentid = "", moduleid = "102", icon ="fa-solid fa-building", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.1", menuname = "NCS Branch Office", path = "/master/branch", menusort = 1, parentid = "2.1", moduleid = "102", icon ="fa-solid fa-building-flag", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.2", menuname = "NCS Counter", path = "/master/counter", menusort = 2, parentid = "2.1", moduleid = "102", icon ="fa-solid fa-shop", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.3", menuname = "NCS Agent", path = "/master/agent", menusort = 3, parentid = "2.1", moduleid = "102", icon ="fa-solid fa-store", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.4", menuname = "NCS Agent Otonom", path = "/master/agentotonom", menusort = 4, parentid = "2.1", moduleid = "102", icon ="fa-solid  fa-house-laptop", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.5", menuname = "Wholesaler", path = "/master/wholesaler", menusort = 5, parentid = "2.1", moduleid = "102", icon ="fa-solid fa-person-booth", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.1.6", menuname = "Branch Corporate", path = "/master/branchcorporate", menusort = 6, parentid = "2.1", moduleid = "102", icon ="fa-solid fa-envelopes-bulk", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2", menuname = "Operational", path = null, menusort = 2, parentid = "", moduleid = "102", icon ="fa-solid fa-warehouse", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2.1", menuname = "Courier Group", path = "/master/couriergroup", menusort = 1, parentid = "2.2", moduleid = "102", icon ="fa-solid fa-people-line", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2.2", menuname = "Courier Code", path = "/master/courier", menusort = 2, parentid = "2.2", moduleid = "102", icon ="fa-solid fa-motorcycle", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2.3", menuname = "Courier Route", path = "/master/courierroute", menusort = 3, parentid = "2.2", moduleid = "102", icon ="fa-solid fa-road", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2.4", menuname = "Checkpoint Code", path = "/master/checkpointcode", menusort = 4, parentid = "2.2", moduleid = "102", icon ="fa-solid fa-location-dot", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.2.5", menuname = "HUB Code", path = "/master/hubcode", menusort = 5, parentid = "2.2", moduleid = "102", icon ="fa-solid fa-building-circle-arrow-right", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.3", menuname = "Client", path = null, menusort = 3, parentid = "", moduleid = "102", icon ="fa-solid fa-user", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.3.1", menuname = "CIF Data Client", path = "/master/cif", menusort = 1, parentid = "2.3", moduleid = "102", icon ="fa-solid fa-users-between-lines", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.3.2", menuname = "Account Data Client", path = "/master/account", menusort = 2, parentid = "2.3", moduleid = "102", icon ="fa-solid fa-user-tag", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.3.3", menuname = "Industry Code", path = "/master/industry", menusort = 3, parentid = "2.3", moduleid = "102", icon ="fa-solid fa-industry", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.4", menuname = "Sales", path = null, menusort = 4, parentid = "", moduleid = "102", icon ="fa-solid fa-handshake", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"},
                new() { menuid = "2.4.1", menuname = "CRO", path = "/master/cro", menusort = 1, parentid = "2.4", moduleid = "102", icon ="fa-solid fa-person-arrow-up-from-line", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System"}
            });
        }
    }
}
