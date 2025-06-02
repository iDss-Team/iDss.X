using iDss.X.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace iDss.X.Data.Configuration
{
    public class CIFConfiguration : IEntityTypeConfiguration<CIF>
    {
        public void Configure(EntityTypeBuilder<CIF> builder)
        {
            builder.HasKey(m => m.cif); // Menentukan Primary Key

            builder.HasOne(m => m.Industry) // Relasi ke mdt_industry
                .WithMany(c => c.CIFs)
                .HasForeignKey(m => m.industryid) // Foreign Key
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }

    public class AccountAddrConfiguration : IEntityTypeConfiguration<AccountAddr>
    {
        public void Configure(EntityTypeBuilder<AccountAddr> builder)
        {
            builder.HasKey(m => m.id); // Menentukan Primary Key

            builder.HasOne(m => m.Account) // Relasi ke mdt_account
                .WithMany(c => c.AccountAddrs)
                .HasForeignKey(m => m.acctno) // Foreign Key
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class accountCROConfiguration : IEntityTypeConfiguration<AccountCro>
    {
        public void Configure(EntityTypeBuilder<AccountCro> builder)
        {
            builder.HasKey(ac => new { ac.acctno, ac.crocode });

            builder.HasOne(m => m.Account) // Relasi ke mdt_account
                .WithMany(c => c.AccountCros)
                .HasForeignKey(m => m.acctno) // Foreign Key
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.CRO) // Relasi ke mdt_cro
                .WithMany(c => c.AccountCros)
                .HasForeignKey(m => m.crocode) // Foreign Key
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PickupRegularConfiguration : IEntityTypeConfiguration<PickupRegular>
    {
        public void Configure(EntityTypeBuilder<PickupRegular> builder)
        {
            builder.HasOne(reg => reg.Courier)
                .WithMany(cou => cou.PickupRegulars)
                .HasForeignKey(reg => reg.couriercode)
                .HasPrincipalKey(cou => cou.couriercode);
        }
    }

    public class PickupRequestConfiguration : IEntityTypeConfiguration<PickupRequest>
    {
        public void Configure(EntityTypeBuilder<PickupRequest> builder)
        {
            builder.HasIndex(pr => pr.pickupno).IsUnique();

            builder.HasOne(pr => pr.Courier)
                .WithMany(cou => cou.PickupRequests)
                .HasForeignKey(pr => pr.couriercode)
                .HasPrincipalKey(cou => cou.couriercode);
        }
    }

    public class PickupStatusPoolConfiguration : IEntityTypeConfiguration<PickupStatusPool>
    {
        public void Configure(EntityTypeBuilder<PickupStatusPool> builder)
        {
            builder.HasKey(m => m.id); // Menentukan Primary Key

            builder.HasOne(m => m.PickupRequest) // Relasi ke pum_pickuprequest
                .WithMany(c => c.PickupStatusPools)
                .HasForeignKey(m => m.pickupno) // Foreign Key
                .HasPrincipalKey(pr => pr.pickupno)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ShipmentDetailConfiguration : IEntityTypeConfiguration<ShipmentDetail>
    {
        public void Configure(EntityTypeBuilder<ShipmentDetail> builder)
        {
            builder.HasIndex(shd => shd.awb).IsUnique();

            builder.HasOne(shd => shd.ShipperDetail)
                .WithOne(shp => shp.ShipmentDetail)
                .HasForeignKey<ShipperDetail>(shp => shp.awb)
                .HasPrincipalKey<ShipmentDetail>(shd => shd.awb);

            builder.HasOne(shd => shd.ConsigneeDetail)
                .WithOne(cne => cne.ShipmentDetail)
                .HasForeignKey<ConsigneeDetail>(cne => cne.awb)
                .HasPrincipalKey<ShipmentDetail>(shd => shd.awb);

            builder.HasOne(shd => shd.VoidTransaction)
                .WithOne(vod => vod.ShipmentDetail)
                .HasForeignKey<VoidTransaction>(vod => vod.awb)
                .HasPrincipalKey<ShipmentDetail>(shd => shd.awb);

            builder.HasOne(shd => shd.PaymentDetail)
                .WithOne(pym => pym.ShipmentDetail)
                .HasForeignKey<PaymentDetail>(pym => pym.awb)
                .HasPrincipalKey<ShipmentDetail>(shd => shd.awb);

            builder.HasOne(shd => shd.PickupRequest)
                .WithMany(psp => psp.ShipmentDetails)
                .HasForeignKey(shd => shd.pickupno)
                .HasPrincipalKey(psp => psp.pickupno);
        }
    }

    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.HasIndex(c => c.couriercode).IsUnique();
        }


    }

    public class AWBInventoryConfiguration : IEntityTypeConfiguration<AWBInventory>
    {
        public void Configure(EntityTypeBuilder<AWBInventory> builder)
        {
            builder.HasIndex(a => a.awb).IsUnique();
        }
    }

    public class ShipperDetailConfiguration : IEntityTypeConfiguration<ShipperDetail>
    {
        public void Configure(EntityTypeBuilder<ShipperDetail> builder)
        {
            builder.HasIndex(a => a.awb).IsUnique();
        }
    }

    public class ConsigneeDetailConfiguration : IEntityTypeConfiguration<ConsigneeDetail>
    {
        public void Configure(EntityTypeBuilder<ConsigneeDetail> builder)
        {
            builder.HasIndex(a => a.awb).IsUnique();
        }
    }

    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.HasIndex(a => a.awb).IsUnique();
        }
    }

    public class VoidTransactionConfiguration : IEntityTypeConfiguration<VoidTransaction>
    {
        public void Configure(EntityTypeBuilder<VoidTransaction> builder)
        {
            builder.HasIndex(a => a.awb).IsUnique();
        }
    }

    public class CheckpointPoolConfiguration : IEntityTypeConfiguration<CheckpointPool>
    {
        public void Configure(EntityTypeBuilder<CheckpointPool> builder)
        {
            builder.HasOne(cp => cp.Courier)
                .WithMany(cou => cou.CheckpointPools)
                .HasForeignKey(cp => cp.couriercode)
                .HasPrincipalKey(cou => cou.couriercode);
        }
    }
}
