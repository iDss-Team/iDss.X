using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class ProvinceSeeding
    {
        public static void SeedProvince(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(new Province[]
            {
                new() { provid = "11", provname = "ACEH", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "12", provname = "SUMATERA UTARA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "13", provname = "SUMATERA BARAT", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "14", provname = "RIAU", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "15", provname = "JAMBI", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "16", provname = "SUMATERA SELATAN", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "17", provname = "BENGKULU", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "18", provname = "LAMPUNG", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "19", provname = "BANGKA BELITUNG", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "21", provname = "KEPULAUAN RIAU", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "31", provname = "DKI JAKARTA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "32", provname = "JAWA BARAT", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "33", provname = "JAWA TENGAH", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "34", provname = "YOGYAKARTA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "35", provname = "JAWA TIMUR", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "36", provname = "BANTEN", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "51", provname = "BALI", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "52", provname = "NUSA TENGGARA BARAT", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "53", provname = "NUSA TENGGARA TIMUR", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "61", provname = "KALIMANTAN BARAT", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "62", provname = "KALIMANTAN TENGAH", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "63", provname = "KALIMANTAN SELATAN", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "64", provname = "KALIMANTAN TIMUR", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "65", provname = "KALIMANTAN UTARA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "71", provname = "SULAWESI UTARA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "72", provname = "SULAWESI TENGAH", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "73", provname = "SULAWESI SELATAN", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "74", provname = "SULAWESI TENGGARA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "75", provname = "GORONTALO", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "76", provname = "SULAWESI BARAT", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "81", provname = "MALUKU", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "82", provname = "MALUKU UTARA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "91", provname = "PAPUA", createddate = new DateTime(2025, 1, 1)},
                new() { provid = "92", provname = "PAPUA BARAT", createddate = new DateTime(2025, 1, 1)}
            });
        }
    }
}
