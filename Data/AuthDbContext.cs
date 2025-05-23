using iDss.X.Data.Configuration;
using iDss.X.Data.Seed;
using iDss.X.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Hanya ubah tabel Identity
            var identityTables = new List<string>
            {
                "AspNetUsers",
                "AspNetRoles",
                "AspNetUserRoles",
                "AspNetUserClaims",
                "AspNetUserLogins",
                "AspNetRoleClaims",
                "AspNetUserTokens"
            };

            // mengubah nama field identity menjadi lowercase
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();

                if (tableName != null && identityTables.Contains(tableName))
                {
                    foreach (var property in entity.GetProperties())
                    {
                        property.SetColumnName(property.Name.ToLower());
                    }
                }
            }

            // Ubah nama tabel default Identity
            builder.Entity<ApplicationUser>().ToTable("idm_user");
            builder.Entity<IdentityRole>().ToTable("idm_role");
            builder.Entity<IdentityUserRole<string>>().ToTable("idm_userrole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("idm_userclaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("idm_userlogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("idm_usertoken");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("idm_roleclaim");

        }
    }
}   
