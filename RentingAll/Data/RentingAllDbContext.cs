using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingAll.Areas.Cars.Data.Models;

namespace RentingAll.Data
{
    public class RentingAllDbContext : IdentityDbContext
    {       
        public RentingAllDbContext(DbContextOptions<RentingAllDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}