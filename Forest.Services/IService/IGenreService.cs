using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IGenreService
    {
        public IList<Genre> GetGenres();
        public Genre GetGenre(int id);
        public Genre GetGenre(Music music);
        public bool AddGenre(Genre genre, string userId);
        public bool DeleteGenre(int id);
        public bool UpdateGenre(Genre genre, int id);
    }
}