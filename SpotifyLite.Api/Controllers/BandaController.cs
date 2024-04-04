using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpotifyLite.Api.Controllers
{
    public class BandaController : Controller
    {
        // GET: BandaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BandaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BandaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BandaController/Create
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

        // GET: BandaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BandaController/Edit/5
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

        // GET: BandaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BandaController/Delete/5
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
