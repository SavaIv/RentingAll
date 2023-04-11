using Microsoft.EntityFrameworkCore;
using RentingAll.Areas.Cars.Data.Models;
using RentingAll.Data;

namespace RentingAll.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<RentingAllDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(RentingAllDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category {Name = "Mini"},
                new Category {Name = "Economy"},
                new Category {Name = "Midsize"},
                new Category {Name = "Large"},
                new Category {Name = "SUV"},
                new Category {Name = "Vans"},
                new Category {Name = "Luxury"}                
            });

            data.SaveChanges();
        }
    }
}
