using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.IService;
using Forest.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers
{
    public class MusicController : Controller
    {
        ForestContext context;
        private Helper helper;
        private IMusicService musicService;
        public MusicController()
        {
            musicService = new MusicService();
            helper = new Helper();
        }


        public ActionResult GetMusic(int id)
        {
            Music music = musicService.GetMusic(id);
            return View(music);
        }
        // GET: MusicController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicController/Create
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

        // GET: MusicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicController/Edit/5
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

        // GET: MusicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicController/Delete/5
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