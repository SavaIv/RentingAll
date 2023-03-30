using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentingAll.Data
{
    public class RentingAllDbContext : IdentityDbContext
    {
        public RentingAllDbContext(DbContextOptions<RentingAllDbContext> options)
            : base(options)
        {
        }
    }
}