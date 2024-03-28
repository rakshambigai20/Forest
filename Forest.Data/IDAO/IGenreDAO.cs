using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IGenreDAO
    {
        IList<Genre> GetGenres(ForestContext context);
        Genre GetGenre(int id, ForestContext context);
        void AddToCollection(Music music, Genre genre, ForestContext context);

        void AddGenre(Genre genre, ForestContext context);
        Genre GetGenre(Music music, ForestContext context);
        void RemoveFromCollection(Music music, Genre genre, ForestContext context);

        void RemoveGenre(Genre genre, ForestContext context);
        void UpdateGenre(Genre data, ForestContext context);
    }
}
