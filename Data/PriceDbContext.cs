using iDss.X.Data.Configuration;
using iDss.X.Data.Seed;
using iDss.X.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iDss.X.Data
{
    public class PriceDbContext : DbContext
    {
        public PriceDbContext(DbContextOptions<PriceDbContext> options) : base(options)
        {
            
        }

        public DbSet<GeneralPrice> pri_pricegeneral { get; set; }
        
    }
}   
