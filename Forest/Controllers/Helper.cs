using Forest.Services.Service;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Forest.Controllers
{
    public class Helper
    {
        ForestContext context;
        GenreService genreService = new GenreService() ;
        ArtistService artistService = new ArtistService();
        public List<SelectListItem> GetGenreDropdown()
        {
            List<SelectListItem> genreList = new List<SelectListItem>();
            IList<Genre> genres = genreService.GetGenres();
            foreach(var item in genres)
            {
                genreList.Add
                    (
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = (item.Name == (genres[0].Name) ? true : false)
                    }
                    );
            }
            return genreList;
        }
        public List<SelectListItem> GetArtistDropdown()
        {
            List<SelectListItem> artistList = new List<SelectListItem>();
            IList<Artist> artists = artistService.GetArtists();
            foreach (var item in artists)
            {
                artistList.Add
                    (
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = (item.Name == (artists[0].Name) ? true : false)
                    }
                    );
            }
            return artistList;
        }
        public IEnumerable<SelectListItem> GetSelectList<T>(IList<T> list,
            Func<T, object> funcToGetValue, Func<T, Object> funcToGetText)

        {
            return list.Select(x => new SelectListItem
            {
                Value = funcToGetValue(x).ToString(),
                Text = funcToGetText(x).ToString()
            });
        }
    }
    
}
