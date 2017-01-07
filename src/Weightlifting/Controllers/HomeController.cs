using Microsoft.AspNetCore.Mvc;

namespace Weightlifting.Controllers
{
    public class HomeController : Controller
    {       
        public HomeController()
        {            
        }

        // GET: /<controller>/
        public IActionResult Index()
        {          
            return RedirectToAction("Index", "Workout");
        }

        // GET: About
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

    }
}
