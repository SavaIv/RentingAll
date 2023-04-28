using Microsoft.AspNetCore.Mvc;
using RentingAll.Areas.Cars.Models.Home;
using RentingAll.Data;
using RentingAll.Models;
using System.Diagnostics;

namespace RentingAll.Areas.Cars.Controllers
{
    public class HomeController : AreaCarsBaseController
    {
        private readonly RentingAllDbContext data;

        public HomeController(RentingAllDbContext _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            var totalCars = data.Cars.Count();

            var cars = data
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarIndexViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl
                })
                .Take(3)
                .ToList();

            return View(new IndexViewModel
            {
                TotalCars = totalCars,
                Cars = cars
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
