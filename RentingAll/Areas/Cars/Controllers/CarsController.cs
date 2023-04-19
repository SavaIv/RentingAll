using Microsoft.AspNetCore.Mvc;
using RentingAll.Areas.Cars.Models.Cars;

namespace RentingAll.Areas.Cars.Controllers
{
    public class CarsController : AreaCarsBaseController
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCarFormModel car) 
        {
            return View();
        }
    }
}
