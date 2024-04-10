using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleDemoWithoutIdentity.Controllers
{
    public class VehicalController : Controller
    {
        // GET: VehicalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
