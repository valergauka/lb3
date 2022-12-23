using lb3.Models;
using lb3.Services;
using Microsoft.AspNetCore.Mvc;

namespace lb3.Controllers
{
    public class AbonentController : Controller
    {
        private readonly AbonentService _abonentService;

        public AbonentController(AbonentService abonentService)
        {
            _abonentService = abonentService;
        }

        public ActionResult<IList<Abonent>> Index() => View(_abonentService.Read());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Abonent> Create(Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                _abonentService.Create(abonent);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult<Abonent> Edit(string id) =>
            View(_abonentService.Find(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                _abonentService.Update(abonent);
                return RedirectToAction("Index");
            }
            return View(abonent);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _abonentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
