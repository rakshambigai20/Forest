using Forest.Data.Models.Domain;
using Forest.Services.IService;
using Forest.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers
{
    public class ArtistController : Controller
    {
        IArtistService artistService;

        public ArtistController()
        {
            artistService = new ArtistService();
        }
        public ActionResult GetArtists()
        {
            return View(artistService.GetArtists());
        }

        public ActionResult GetArtist(int id)
        {
            Artist artist = artistService.GetArtist(id);
            return View(artist);
        }
        // GET: ArtistController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArtistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistController/Create
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

        // GET: ArtistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistController/Edit/5
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

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
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
