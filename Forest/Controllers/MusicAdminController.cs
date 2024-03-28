using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.Models;
using Forest.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forest.Controllers
{
    public class MusicAdminController : Controller
    {
        Helper helper;
        MusicService musicService;
        GenreService genreService;
        ArtistService artistService;
        ForestContext context;
        public MusicAdminController() 
        {
            helper = new Helper();
            musicService = new MusicService();
            genreService = new GenreService();
            artistService = new ArtistService();
            context = new ForestContext();
        }
        
        
        // GET: MusicAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicAdminController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Music music = musicService.GetMusic(id);
                return View(music);
            }
            catch
            {
                return View();
            }
        }
        // GET: MusicAdminController/Create
        public ActionResult Create()
        {
            ViewBag.genreList = helper.GetGenreDropdown();
            ViewBag.artistList = helper.GetArtistDropdown();
            return View();
        }


        // GET: MusicAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            Music music = musicService.GetMusic(id);
            return View(music);
         
        }

        // POST: MusicAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Music collection)
        {
            try
            {
  
                musicService.UpdateMusic(collection,id );
                Music music = musicService.GetMusic(id);
                Genre genre = genreService.GetGenre(music);
                return RedirectToAction("GetGenre", "Genre", new { id = genre.Id });
         
              
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            Music music = musicService.GetMusic(id);
            return View(music);
        }

        // POST: MusicAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Music music = musicService.GetMusic(id);
                Genre genre = genreService.GetGenre(music);
                musicService.DeleteMusic(id);
                return RedirectToAction("GetGenre","Genre", new { id = genre.Id });
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MusicGenreArtist collection)
        {
            try
            {
                musicService.AddMusic(collection, "mo");
               return RedirectToAction("GetGenre", "Genre", new { id = collection.GenreId });
          }
            catch
            {
                return View();
            }
        }
        
        public ActionResult AddMusic()
        {
            ViewBag.genreList = helper.GetSelectList<Genre>(
                genreService.GetGenres(), x => x.Id, x => x.Name);
            ViewBag.artistList = helper.GetSelectList<Artist>(
                artistService.GetArtists(), x => x.Id, x => x.Name);
            return View();
        }
        public ActionResult AddGenre()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGenre(Genre genre)
        {
            try
            {
                genreService.AddGenre(genre, "mo");
                return RedirectToAction("GetGenres", "Genre");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteGenre(int id)
        {
            Genre genre = genreService.GetGenre(id);
            return View(genre);
        }

        // POST: MusicAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGenre(int id, IFormCollection collection)
        {
            try
            {
                Genre genre = genreService.GetGenre(id);
                genreService.DeleteGenre(id);
                return RedirectToAction("GetGenres", "Genre");
            }
            catch
            {
                return View();
            }
        }
        // GET: MusicAdminController/Edit/5
        public ActionResult EditGenre(int id)
        {
            Genre genre = genreService.GetGenre(id);
            return View(genre);

        }

        // POST: MusicAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGenre(Genre collection , int id)
        {
            try
            {

                genreService.UpdateGenre(collection, id);
                return RedirectToAction("GetGenres", "Genre" );


            }
            catch
            {
                return View();
            }
        }



    }
}
