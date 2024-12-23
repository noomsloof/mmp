using Microsoft.AspNetCore.Mvc;
using MMProject.Models;
using MMProject.Data;
using System.Linq;

namespace MMProject.Controllers
{
    public class FundController : Controller
    {
        private readonly ApplicationDBContext _db;
        public FundController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Saving> allSaving = _db.Savings;

            return View(allSaving);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saving obj) {

            double amount = obj.Wealt;
            var lastReccord = _db.Savings.OrderByDescending(r => r.Id).FirstOrDefault();
            double newWealt = lastReccord.Wealt + amount;

            obj.Wealt = newWealt;

            if (ModelState.IsValid)
            {
                _db.Savings.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Savings.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Saving obj)
        {
            if (ModelState.IsValid)
            {
                _db.Savings.Update(obj);
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

            var obj = _db.Savings.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Savings.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
