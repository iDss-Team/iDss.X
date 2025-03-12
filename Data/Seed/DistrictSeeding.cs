using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class DistrictSeeding
    {
        public static void SeedDistrict(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().HasData(new District[]
            {
                new() { distid = "317307", distname = "Pal Merah", cityid = "3173"}
            });
        }
    }
}
