
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
   
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
