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

            var viewModel = new CalIndexViewModel
            {
                InvestPlans = _db.InvestPlans,
                Savings = new List<Saving>
                {
                    _db.Savings.OrderByDescending(r => r.Id).FirstOrDefault()
                }
            };

            return View(viewModel);
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
                _db.InvestPlans.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id is null || Id is 0)
            {
                return NotFound();
            }

            var obj = _db.InvestPlans.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.InvestPlans.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.InvestPlans.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InvestPlan obj)
        {
            if (ModelState.IsValid)
            {
                _db.InvestPlans.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
