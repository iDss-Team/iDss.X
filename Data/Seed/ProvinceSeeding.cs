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
                new() { provid = "11", provname = "ACEH"},
                new() { provid = "12", provname = "SUMATERA UTARA"},
                new() { provid = "13", provname = "SUMATERA BARAT"},
                new() { provid = "14", provname = "RIAU"},
                new() { provid = "15", provname = "JAMBI"},
                new() { provid = "16", provname = "SUMATERA SELATAN"},
                new() { provid = "17", provname = "BENGKULU"},
                new() { provid = "18", provname = "LAMPUNG"},
                new() { provid = "19", provname = "BANGKA BELITUNG"},
                new() { provid = "21", provname = "KEPULAUAN RIAU"},
                new() { provid = "31", provname = "DKI JAKARTA"},
                new() { provid = "32", provname = "JAWA BARAT"},
                new() { provid = "33", provname = "JAWA TENGAH"},
                new() { provid = "34", provname = "YOGYAKARTA"},
                new() { provid = "35", provname = "JAWA TIMUR"},
                new() { provid = "36", provname = "BANTEN"},
                new() { provid = "51", provname = "BALI"},
                new() { provid = "52", provname = "NUSA TENGGARA BARAT"},
                new() { provid = "53", provname = "NUSA TENGGARA TIMUR"},
                new() { provid = "61", provname = "KALIMANTAN BARAT"},
                new() { provid = "62", provname = "KALIMANTAN TENGAH"},
                new() { provid = "63", provname = "KALIMANTAN SELATAN"},
                new() { provid = "64", provname = "KALIMANTAN TIMUR"},
                new() { provid = "65", provname = "KALIMANTAN UTARA"},
                new() { provid = "71", provname = "SULAWESI UTARA"},
                new() { provid = "72", provname = "SULAWESI TENGAH"},
                new() { provid = "73", provname = "SULAWESI SELATAN"},
                new() { provid = "74", provname = "SULAWESI TENGGARA"},
                new() { provid = "75", provname = "GORONTALO"},
                new() { provid = "76", provname = "SULAWESI BARAT"},
                new() { provid = "81", provname = "MALUKU"},
                new() { provid = "82", provname = "MALUKU UTARA"},
                new() { provid = "91", provname = "PAPUA"},
                new() { provid = "92", provname = "PAPUA BARAT"}
            });
        }
    }
}
