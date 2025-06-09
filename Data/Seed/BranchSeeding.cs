using iDss.X.Models;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data.Seed
{
    public static class BranchSeeding
    {
        public static void SeedBranch(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(new Branch[]
            {
            new() { branchid = 1, branchname = "Katamso Head Office", branchcode = "C1", branchtype = "Central", addr1 = "Jl Brigjen Katamso No.7, Kota Bambu Selatan, Palmerah, Jakarta Barat", villid = "3173071006", latitude = "-6.189083", longitude = "106.800992", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { branchid = 2, branchname = "Kemanggisan Head Office", branchcode = "C2", branchtype = "Central", addr1 = "Jl.Kemanggisan Raya No.19, Kota Bambu Selatan, Palmerah, Jakarta Barat", villid = "3173071006", latitude = "-6.189993", longitude = "106.792306", createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });

            modelBuilder.Entity<PackingType>().HasData(new PackingType[]
            {
            new() { packingcode = "101", packingname = "Bubble Wrap", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { packingcode = "102", packingname = "Kardus (Box)", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { packingcode = "103", packingname = "Kayu", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { packingcode = "104", packingname = "Styrofoam", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });

            modelBuilder.Entity<PackingSize>().HasData(new PackingSize[]
            {
            new() { sizecode = "s", sizename = "Small", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { sizecode = "m", sizename = "Medium", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" },
            new() { sizecode = "l", sizename = "Large", remarks = "", createddate = new DateTime(2025, 1, 1), createdby = "System" }
            });
        }
    }
}
