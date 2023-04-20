using Microsoft.AspNetCore.Mvc;
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
            return View();
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
