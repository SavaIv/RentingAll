using Microsoft.AspNetCore.Mvc;
using RentingAll.Models;
using System.Diagnostics;

namespace RentingAll.Areas.Cars.Controllers
{
    public class HomeController : AreaCarsBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
