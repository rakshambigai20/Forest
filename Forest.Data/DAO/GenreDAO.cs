using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Forest.Data.DAO
{
    public class GenreDAO : IGenreDAO
    {
        //ForestContext context;
        //public GenreDAO()
        //{
        //    context = new ForestContext();
        //}
        public IList<Genre> GetGenres(ForestContext context)
        {
            // Fetch all genres and include their associated music
            return context.Genres
                          .Include(genre => genre.Musics)
                          .ToList();
        }
        public Genre GetGenre(int id, ForestContext context)
        {
            //Genre genre = new Genre();
            //genre = context.Genres.Find(id);
            //return genre;
            context.Genres
                .Include(genre => genre.Musics)
                .ToList();
            return context.Genres.Find(id);
        }
        public void AddToCollection(Music music, Genre genre, ForestContext context)
        {
            if (context.Genres.Contains(genre))
            {
                genre.Musics.Add(music);
            }
            
        }
        public void AddGenre(Genre genre, ForestContext context)
        {
            context.Genres.Add(genre);
        }
        public Genre GetGenre(Music music, ForestContext context)
        {
            var genre = context.Genres
                               .Include(g => g.Musics)
                               .FirstOrDefault(g => g.Musics.Any(m => m.Id == music.Id));

            return genre;
        }

        public void RemoveFromCollection(Music music, Genre genre, ForestContext context)
        {
            if(context.Genres.Contains(genre))
            {
                if (genre.Musics.Contains(music))
                {
                    genre.Musics.Remove(music);
                }
            }
        }
        public void RemoveGenre(Genre genre, ForestContext context)
        {
            context.Genres.Remove(genre);
        }
        public void UpdateGenre(Genre genre, ForestContext context)
        {
            Genre g = context.Genres.Find(genre.Id);
            context.Entry(g).CurrentValues.SetValues(genre);
        }
    }
}