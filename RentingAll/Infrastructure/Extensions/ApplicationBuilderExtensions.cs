using Microsoft.EntityFrameworkCore;
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

            return app;
        }
    }
}
