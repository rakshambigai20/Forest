using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Service
{
    public class ArtistService : IArtistService
    {
        IArtistDAO artistDAO;
        public ArtistService()
        {
            artistDAO = new ArtistDAO();
        }
        public IList<Artist> GetArtists()
        {
            using (ForestContext context = new ForestContext())
            {
                return artistDAO.GetArtists(context);
            }
        }
        public Artist GetArtist(int id)
        {
            using (ForestContext context = new ForestContext())
            {
                Artist artist = artistDAO.GetArtist(id, context);
                return artist;
            }
        }
    }
}
