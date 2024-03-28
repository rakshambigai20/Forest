using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IMusicService
    {
        public Music GetMusic(int id);
        bool AddMusic(MusicGenreArtist musicGenreArtist, string userId);
        bool DeleteMusic(int id);
        bool UpdateMusic(Music music, int id);
    }

}
