using Microsoft.AspNetCore.Mvc;

namespace EFCoreApp.Controllers
{
    public class HomeController : Controller{
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
    }
}