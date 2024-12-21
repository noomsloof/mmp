using Microsoft.AspNetCore.Mvc;

namespace MMProject.Controllers
{
    public class FundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
