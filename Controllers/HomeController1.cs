using Microsoft.AspNetCore.Mvc;

namespace StudentRecord.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
