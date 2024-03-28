using Forest.Data.Models.Domain;
using Forest.Services.IService;
using Forest.Services.Models;
using Forest.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Forest.Controllers
{
    public abstract class ForestController : Controller
    {
        IGenreService genreService;
        IList<Genre> genres;
       
        public IHttpContextAccessor httpContextAccessor;
        public ForestController()
        {
            genreService = new GenreService();
            string genres = JsonConvert.SerializeObject(genreService.GetGenres());
            httpContextAccessor = new HttpContextAccessor();
            httpContextAccessor.HttpContext.Session.SetString("genres", genres);
            
        }
        


    }
}
