using Microsoft.AspNetCore.Mvc;
using MMProject.Data;
using MMProject.Models;

namespace MMProject.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CalculateController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InvestPlan obj)
        {

            if (ModelState.IsValid)
            {
                double converseYield = obj.YieldPerYear / 100;
                obj.YieldPerYear = converseYield;
                _db.InvestPlans.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
    }
}
