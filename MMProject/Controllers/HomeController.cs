using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MMProject.Data;
using MMProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MMProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDBContext _db;
        public HomeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            var datetime = _db.Savings.Select(s => s.Date).ToList();
            var values = _db.Savings.Select(s => s.Wealt).ToList();

            ViewBag.Dates = datetime;
            ViewBag.Values = values;

            return View();
        }

        public IActionResult Privacy()
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
