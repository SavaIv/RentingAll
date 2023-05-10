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

        public IActionResult All(
            string brand, 
            string searchTerm,
            CarSorting sorting)
        {
            var carsQuery = data.Cars.AsQueryable();

            if(!string.IsNullOrWhiteSpace(brand))
            {
                carsQuery = carsQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    //c.Model.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            carsQuery = sorting switch
            {
                CarSorting.DateCtreated => carsQuery.OrderByDescending(c => c.Id),
                CarSorting.Year => carsQuery.OrderByDescending(c => c.Year),
                CarSorting.BrandAndModel => carsQuery.OrderByDescending(c => c.Brand).ThenBy(c => c.Model),
                _ => carsQuery.OrderByDescending(c => c.Id)
            };

            var cars = carsQuery
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

            var carBrands = data
                .Cars
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(br => br)
                .ToList();

            return View(new AllCarsQueryModel
            {
                Brand = brand,
                Brands = carBrands,
                SearchTerm = searchTerm,
                Sorting = sorting,
                Cars = cars                
            });
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
