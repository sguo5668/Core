using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HeroManager HM = new HeroManager();
            var heroes = HM.GetAll;

            return View(heroes);
        }
    }
}
