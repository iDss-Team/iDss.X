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
            new() { id = 1, modulectgname = "Administration & System Management", modulectgsort = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 2, modulectgname = "Data Management", modulectgsort = 2, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 3, modulectgname = "Pre-Delivery", modulectgsort = 3, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 4, modulectgname = "In-Transit", modulectgsort = 4, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 5, modulectgname = "Post-Delivery", modulectgsort = 5, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 6, modulectgname = "Back Office", modulectgsort = 6, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { id = 7, modulectgname = "Warehouse Management", modulectgsort = 7, createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });
        }

        public static void SeedAppModule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppModule>().HasData(new AppModule[]
            {
             new() { moduleid = "101", modulename = "Administrasion", description = "Manages system settings, permissions and general platform configurations", modulesort = 1, modulectgid = 1, icon = "fa-solid fa-user-tie", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "102", modulename = "Master Data", description = "Stores and manages core data", modulesort = 2, modulectgid = 2, icon = "fa-solid fa-database", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "103", modulename = "Prospect Customer Relationship", description = "Handles potential customer prospects, including registration, analysis, and follow-ups to be regular customers", modulesort = 3, modulectgid = 3, icon = "fa-solid fa-handshake-simple", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "104", modulename = "Prospect Agent Relationship", description = "Manages relationships with potential agents, registration, evaluation, and communication to expand the operational network.", modulesort = 4, modulectgid = 3, icon = "fa-solid fa-people-group", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "105", modulename = "Sales Management", description = "Records and manages the sales process, pricing and monitoring team performance and targets.", modulesort = 5, modulectgid = 3, icon = "fa-solid fa-magnifying-glass-chart", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "106", modulename = "Pickup Management", description = "Schedules and manages pickup from customers, including route optimization and field team coordination.", modulesort = 6, modulectgid = 3, icon = "fa-solid fa-truck-moving", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "107", modulename = "Outbound Control Library", description = "Controls and manages the outbound shipment of goods from origin distribution centers to final destinations.", modulesort = 7, modulectgid = 4, icon = "fa-solid fa-plane-departure", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "108", modulename = "Linehaul Control Library", description = "Monitors and manages the movement of goods during intercity or inter-hub transportation.", modulesort = 8, modulectgid = 4, icon = "fa-solid fa-truck-plane", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "109", modulename = "Inbound Control Library", description = "Handles the receiving of incoming shipments from distribution centers until delivery to recipient.", modulesort = 9, modulectgid = 4, icon = "fa-solid fa-plane-arrival", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "110", modulename = "Return Management", description = "Manages the return process due to incorrect shipments, damaged goods, or other return policies.", modulesort = 10, modulectgid = 4, icon = "fa-solid fa-reply", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "111", modulename = "Billing Delivery System", description = "Inbound Processing Center", modulesort = 11, modulectgid = 4, icon = "fa-solid fa-file-invoice", flag = 0, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "112", modulename = "Credit Card System", description = "Inbound Processing Center", modulesort = 12, modulectgid = 4, icon = "fa-solid fa-credit-card", flag = 0, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "113", modulename = "COD Collection", description = "Handles cash payments upon delivery, including transaction recording and coordination with couriers.", modulesort = 13, modulectgid = 5, icon = "fa-solid fa-money-bill-wave", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "114", modulename = "Shipment Tracking Visibility", description = "Provides real-time tracking for customers and internal teams to monitor shipment status and locations.", modulesort = 14, modulectgid = 4, icon = "fa-solid fa-shoe-prints", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "115", modulename = "Problem Handling & Solution", description = "Addresses operational issues such as delivery delays, lost shipments, or customer complaints, and records provided solutions.", modulesort = 15, modulectgid = 4, icon = "fa-solid fa-glasses", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "116", modulename = "Analytics & Reporting", description = "Generates reports and data analysis related to operational performance, sales, and financial aspects to support strategic decision-making.", modulesort = 16, modulectgid = 5, icon = "fa-solid fa-chart-line", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "117", modulename = "Finance Management", description = "Manages company financials, including transaction records, operational expenses, payment reconciliation, and invoicing.", modulesort = 17, modulectgid = 5, icon = "fa-solid fa-sack-dollar", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "118", modulename = "Customer Care Services", description = "Provides customer support to answer inquiries, handle complaints, and offer shipment and service-related information.", modulesort = 18, modulectgid = 5, icon = "fa-solid fa-headset", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "119", modulename = "Legal & Compliance", description = "Ensures compliance with industry regulations and legal requirements, including document management and audit processes.", modulesort = 19, modulectgid = 6, icon = "fa-solid fa-scale-balanced", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "120", modulename = "Integration Management", description = "Manages connections with external systems, APIs, and third-party services to ensure seamless data exchange and interoperability.", modulesort = 20, modulectgid = 1, icon = "fa-solid fa-code-compare", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "121", modulename = "Data Synchronization", description = "Ensures consistency across multiple systems by managing automated data imports, exports, and synchronization processes.", modulesort = 21, modulectgid = 2, icon = "fa-solid fa-rotate", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { moduleid = "122", modulename = "Data Quality & Validation", description = "Maintains data accuracy and reliability by implementing validation rules, detecting duplicates, and managing data correction processes.", modulesort = 22, modulectgid = 2, icon = "fa-solid fa-list-check", flag = 1, createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });
        }
    }
}
