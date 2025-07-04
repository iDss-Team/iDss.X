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
        public DbSet<CostComponent> mdt_costcomponent { get; set; }
        public DbSet<Relation> mdt_relation { get; set; }
        public DbSet<ReasonUN> mdt_reasonun { get; set; }
        public DbSet<Service> mdt_service { get; set; }
        public DbSet<PackingType> mdt_packingtype { get; set; }
        public DbSet<PackingSize> mdt_packingsize { get; set; }
        public DbSet<PackingPrice> mdt_packingprice { get; set; }
        public DbSet<Country> mdt_country { get; set; }
        public DbSet<CityIntl> mdt_cityintl { get; set; }
        public DbSet<PostCode> mdt_postcode { get; set; }
        public DbSet<Bank> mdt_bank { get; set; }
        public DbSet<NCSBankAccount> mdt_ncsbankaccount { get; set; }
        public DbSet<Zone> mdt_zone { get; set; }
        public DbSet<CityZone> mdt_cityzone { get; set; }
        public DbSet<ReasonPickup> mdt_reasonpickup { get; set; }


        //Pickup
        public DbSet<PickupRequest> pum_pickuprequest { get; set; }
        public DbSet<PickupStatusPool> pum_pickupstatuspool { get; set; }
        public DbSet<PickupRegular> pum_pickupregular { get; set; }
        public DbSet<PickupSchedule> pum_pickupschedule { get; set; }
        public DbSet<SuccessPickup> pum_successpickup { get; set; }
        public DbSet<CancelPickup> pum_cancelpickup { get; set; }
        public DbSet<ReschedulePickup> pum_reschedulepickup { get; set; }
        public DbSet<ReassignPickup> pum_reassignpickup { get; set; }
        public DbSet<UnsuccessPickup> pum_unsuccesspickup { get; set; }


        //Transaction
        public DbSet<ShipmentDetail> trx_shipmentdetail { get; set; }
        public DbSet<ShipperDetail> trx_shipper { get; set; }
        public DbSet<ConsigneeDetail> trx_consignee { get; set; }
        public DbSet<CneeDirectory> trx_cneedirectory { get; set; }
        public DbSet<CostItem> trx_costitem { get; set; }
        public DbSet<PaymentDetail> trx_payment { get; set; }
        public DbSet<UnitItem> trx_unititem { get; set; }
        public DbSet<CheckpointPool> trx_checkpointpool { get; set; }
        public DbSet<Attachment> trx_attachment { get; set; }
        public DbSet<VoidTransaction> trx_void { get; set; }
        public DbSet<TrxStaging> trx_staging { get; set; }

        //Outbound
        public DbSet<AWBInventory> mdt_awbinventory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

			// Apply all configuration IEntityTypeConfiguration<T>
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigurationMarker).Assembly);

            //Seed table app_menu
            modelBuilder.SeedNavigation();

            //Seed table city
            modelBuilder.SeedArea();

            //Seed table mdt_branch
            modelBuilder.SeedMasterData();

        }

    }
}
