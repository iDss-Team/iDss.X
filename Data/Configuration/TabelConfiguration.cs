using iDss.X.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

    public class PickupStatusPoolConfiguration : IEntityTypeConfiguration<PickupStatusPool>
    {
        public void Configure(EntityTypeBuilder<PickupStatusPool> builder)
        {
            builder.HasKey(m => m.id); // Menentukan Primary Key

            builder.HasOne(m => m.PickupRequest) // Relasi ke mdt_account
                .WithMany(c => c.PickupStatusPools)
                .HasForeignKey(m => m.pickupno) // Foreign Key
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
