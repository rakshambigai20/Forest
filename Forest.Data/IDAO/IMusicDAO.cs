using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IMusicDAO
    {
        Music GetMusic(int id, ForestContext context);
        void AddMusic(Music music, ForestContext context);
        void DeleteMusic(Music music , ForestContext context);
        void UpdateMusic(Music music, ForestContext context);
        void AddToCollection(OrderLine orderLine, int musicId, ForestContext context);
    }
}
