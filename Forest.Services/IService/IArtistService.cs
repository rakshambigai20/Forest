using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IArtistService
    {
        public IList<Artist> GetArtists();
        public Artist GetArtist(int id);
    }
}
