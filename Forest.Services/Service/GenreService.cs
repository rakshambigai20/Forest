using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.Models.Domain;
using Forest.Data.IDAO;
using Forest.Data.DAO;
using Forest.Services.IService;
using Forest.Data.Models.Repository;

namespace Forest.Services.Service
{
    public class GenreService : IGenreService
    {
        IGenreDAO genreDAO;
        IUserDAO userDAO;
        public GenreService()
        {
            genreDAO = new GenreDAO();
            userDAO = new UserDAO();
        }
        public IList<Genre> GetGenres()
        {
            using (ForestContext context = new ForestContext())
            {
                return genreDAO.GetGenres(context);
            }
        }
        public Genre GetGenre (int id)
        {
            using (ForestContext context = new ForestContext())
            {
                Genre genre = new Genre();
                genre = genreDAO.GetGenre(id,context);
                return genre;
            }
        }
        public Genre GetGenre(Music music)
        {
            using (ForestContext context = new ForestContext())
            {
                Genre genre = genreDAO.GetGenre(music, context);
                return genre;
            }
        }
        public bool AddGenre(Genre genre , string userId)
        {
            try
            {
                using (ForestContext context = new ForestContext())
                {
                    genreDAO.AddGenre(genre, context);
                    userDAO.AddGenre(genre, userId, context);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool DeleteGenre(int id) 
        {
            try
            {
                using(ForestContext context = new ForestContext())
                {
                    Genre genre = genreDAO.GetGenre(id, context);
                    if (genre != null) 
                    {
                        genreDAO.RemoveGenre(genre, context);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch 
            { 
                return false; 
            }
        }
        public bool UpdateGenre(Genre data, int id)
        {
            try
            {
                Genre genre = new Genre();
                {
                    genre.Id = id;
                    genre.Name = data.Name;
                }
                using(ForestContext context = new ForestContext())
                {
                    genreDAO.UpdateGenre(genre, context);
                    context.SaveChanges();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}