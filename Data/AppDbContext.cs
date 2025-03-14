using iDss.X.Data.Configuration;
using iDss.X.Data.Seed;
using iDss.X.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Configuration
        public DbSet<AppModuleCtg> app_modulectg { get; set; }
        public DbSet<AppModule> app_module { get; set; }
        public DbSet<AppMenu> app_menu { get; set; }

        //MasterData
        public DbSet<Branch> mdt_branch { get; set; }
        public DbSet<Courier> mdt_courier { get; set; }
        public DbSet<CIF> mdt_cif { get; set; }
        public DbSet<Account> mdt_account { get; set; }
        public DbSet<AccountAddr> mdt_accountaddr { get; set; }
        public DbSet<CRO> mdt_cro { get; set; }
        public DbSet<AccountCro> mdt_accountcro { get; set; }
        public DbSet<BranchAccount> mdt_branchaccount { get; set; }
        public DbSet<Province> mdt_province { get; set; }
        public DbSet<City> mdt_city { get; set; }
        public DbSet<District> mdt_district { get; set; }
        public DbSet<Village> mdt_village { get; set; }
        public DbSet<Counter> mdt_counter { get; set; }
        public DbSet<Agent> mdt_agent { get; set; }
        public DbSet<Industry> mdt_industry { get; set; }
        public DbSet<Checkpoint> mdt_checkpoint { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>().ToTable("users");
            //modelBuilder.Entity<ApplicationRole>().ToTable("roles");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("user_token");
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("user_role");
            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("role_claim");
            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("user_claim");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("user_login");

            //Example Rewrite On-Delete Rule
            modelBuilder.ApplyConfiguration(new AppModuleConfiguration());
            modelBuilder.ApplyConfiguration(new AppMenuConfiguration());

            //Seed table app_module
            modelBuilder.SeedAppModuleCtg();

            //Seed table app_module
            modelBuilder.SeedAppModule();

            //Seed table app_menu
            modelBuilder.SeedAppMenu();

            //Seed table province
            modelBuilder.SeedProvince();

            //Seed table city
            modelBuilder.SeedCity();

            //Seed table district
            modelBuilder.SeedDistrict();

            //Seed table village
            modelBuilder.SeedVillage();

            //Seed table mdt_branch
            modelBuilder.SeedBranch();

        }

    }
}
