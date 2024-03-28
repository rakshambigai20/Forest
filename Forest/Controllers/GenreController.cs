using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Forest.Services.IService;
using Forest.Services.Service;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Newtonsoft.Json;

namespace Forest.Controllers
{
    public class GenreController : ForestController
    {
        //IGenreService genreService;
        IList<Genre> genres;
        ForestContext context;
        public GenreController()
        {
            //genreService = new GenreService();
            string str = httpContextAccessor.HttpContext.Session.GetString("genres");
            genres = JsonConvert.DeserializeObject<IList<Genre>>(str);
        }
        public ActionResult GetGenres()
        {
            //return View(genreService.GetGenres());
            string userId = HttpContext.Session.GetString("user_id");
            return View(genres);
        }

        public ActionResult GetGenre(int id)
        {
            Genre genre = null;
            //genre = new Genre();
            while(genre == null)
            {
                for (int i = 0; i < genres.Count; i++)
                {
                    if (genres[i].Id == id)
                        genre = genres[i];
                }
            }
            return View(genre);
        }
        // GET: GenreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
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

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenreController/Edit/5
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

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenreController/Delete/5
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
