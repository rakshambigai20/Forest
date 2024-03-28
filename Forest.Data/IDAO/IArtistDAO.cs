using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IArtistDAO
    {
        void AddToCollection(Music music,Artist artist , ForestContext context);
        IList<Artist> GetArtists(ForestContext context);
        Artist GetArtist(int id, ForestContext context);
        Artist GetArtist(Music music, ForestContext context);
        void RemoveFromCollection(Music music, Artist artist, ForestContext context);
    }
}
