using Microsoft.AspNetCore.Mvc;
using RentingAll.Areas.Cars.Data.Models;
using RentingAll.Areas.Cars.Models.Cars;
using RentingAll.Data;

namespace RentingAll.Areas.Cars.Controllers
{
    public class CarsController : AreaCarsBaseController
    {
        private readonly RentingAllDbContext data;

        public CarsController(RentingAllDbContext _data)
        {
            data = _data;
        }

        public IActionResult Add()
        {
            return View(new AddCarFormModel
            {
                Categories = GetCarCategories()
            });
        }

        [HttpPost]
        public IActionResult Add(AddCarFormModel car) 
        {
            if (!data.Categories.Any(c => c.Id == car.CategoryId))
            {
                ModelState.AddModelError(nameof(car.CategoryId), "Category does nott exist!");
            }


            if(!ModelState.IsValid)
            {
                car.Categories = GetCarCategories();

                return View(car);
            }

            var userCar = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                CategoryId = car.CategoryId,
                Year = car.Year
            };

            data.Cars.Add(userCar);
            data.SaveChanges();
            
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var cars = data
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarListingViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    Category = c.Category.Name
                })
                .ToList();

            return View(cars);
        }

        private IEnumerable<CarCategoryViewModel> GetCarCategories()
        {
            return data
                    .Categories
                    .Select(c => new CarCategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToList();
        
        }
    }
}
