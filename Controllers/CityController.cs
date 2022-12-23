using lb3.Models;
using lb3.Services;
using Microsoft.AspNetCore.Mvc;

namespace lb3.Controllers
{
    public class CityController : Controller
    {
        private readonly CityService _cityService;

        public CityController(CityService _cityService)
        {
            _cityService = _cityService;
        }

        public ActionResult<IList<City>> Index() => View(_cityService.Read());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Abonent> Create(City city)
        {
            if (ModelState.IsValid)
            {
                _cityService.Create(city);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult<City> Edit(string id) =>
            View(_cityService.Find(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _cityService.Update(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _cityService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
