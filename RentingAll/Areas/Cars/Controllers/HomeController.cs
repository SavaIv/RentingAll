using Microsoft.AspNetCore.Mvc;

namespace RentingAll.Areas.Cars.Controllers
{
    public class HomeController : AreaCarsBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
