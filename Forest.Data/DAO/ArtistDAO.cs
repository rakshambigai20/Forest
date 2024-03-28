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
    public class ArtistDAO : IArtistDAO
    {
        //ForestContext context;
        //public GenreDAO()
        //{
        //    context = new ForestContext();
        //}
        public IList<Artist> GetArtists(ForestContext context)
        {
            return context.Artists.ToList();
        }
        public Artist GetArtist(int id, ForestContext context)
        {
            //Genre genre = new Genre();
            //genre = context.Genres.Find(id);
            //return genre;
            context.Artists
                .Include(artist => artist.Musics)
                .ToList();
            return context.Artists.Find(id);
        }
        public void AddToCollection(Music music, Artist artist, ForestContext context)
        {
            if (context.Artists.Contains(artist))
            {
                artist.Musics.Add(music);
            }
        }
        public Artist GetArtist(Music music, ForestContext context)
        {
            IList<Artist> artists = GetArtists(context);
            for (int i = 0; i < artists.Count; i++)
            {
                if (artists[i].Musics.Contains<Music>(music))
                {
                    return artists[i];
                }
            }
            return null;
        }
        public void RemoveFromCollection(Music music, Artist artist, ForestContext context)
        {
            if (context.Artists.Contains(artist))
            {
                if (artist.Musics.Contains(music))
                {
                    artist.Musics.Remove(music);
                }
            }

        }
    }
}