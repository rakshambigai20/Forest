using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.IService;
using Forest.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Service
{
    public class MusicService : IMusicService
    {
        private IMusicDAO musicDAO;
        private IArtistDAO artistDAO;
        private IGenreDAO genreDAO;
        private IUserDAO userDAO;
        ForestContext context;
        public MusicService()
        {
            musicDAO = new MusicDAO();
            artistDAO = new ArtistDAO();
            genreDAO = new GenreDAO();
            userDAO = new UserDAO();
            context = new ForestContext();
        }
        public Music GetMusic(int id)
        {
            using (ForestContext context = new ForestContext())
            {
                Music music = new Music();
                music = musicDAO.GetMusic(id, context);
                return music;

            }
        }
        public bool AddMusic(MusicGenreArtist data, string userId)
        {
            try
            {
                #region(Prepare Music Object)
                Music music = new Music()
                {
                    Title = data.Title,
                    Tracks = data.Tracks,
                    Minutes = data.Minutes,
                    DateReleased = data.DateReleased,
                    Price = data.Price,
                    Image = data.Image,
                };
                #endregion
                #region(Unit of work)
                using(ForestContext context = new ForestContext())
                {
                    musicDAO.AddMusic(music, context);
                    userDAO.AddToCollection(music, userId, context);
                    Genre genre = genreDAO.GetGenre(data.GenreId, context);
                    genreDAO.AddToCollection(music, genre, context);
                    Artist artist = artistDAO.GetArtist(data.ArtistId, context);
                    artistDAO.AddToCollection(music, artist, context);
                    context.SaveChanges();
                }
                #endregion
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool DeleteMusic(int id) 
        {
            try
            {
                using(ForestContext context = new ForestContext())
                {
                    Music music = musicDAO.GetMusic(id, context);
                    Genre genre = genreDAO.GetGenre(music,context);
                    genreDAO.RemoveFromCollection(music, genre, context);
                    Artist artist = artistDAO.GetArtist(music, context);
                    artistDAO.RemoveFromCollection(music,artist, context);
                    User user = userDAO.GetUser(music, context);
                    userDAO.RemoveFromCollection(music, context);
                    context.Musics.Remove(music);
                    context.SaveChanges();
                }
                return true;
            }
            catch { 
                return false;
            }
        }
        public bool UpdateMusic(Music data, int id)
        {
            try
            {
                Music music = new Music()
                {
                    Id = id,
                    Title = data.Title,
                    Tracks = data.Tracks,
                    Minutes = data.Minutes,
                    DateReleased = data.DateReleased,
                    Price = data.Price,
                    Image = data.Image,
                };
                using (ForestContext context = new ForestContext())
                {
                    musicDAO.UpdateMusic(music, context);
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
