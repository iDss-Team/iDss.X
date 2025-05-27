using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class VillageSeeding
    {
        public static void SeedVillage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Village>().HasData(new Village[]
            {
                new() { villid = "3173071006", villname = "Kota Bambu Selatan", distid = "317307", createddate = new DateTime(2025, 1, 1)}
            });
        }
    }
}
