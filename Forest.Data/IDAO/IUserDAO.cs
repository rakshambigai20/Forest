using Forest.Data.DAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IUserDAO
    {
        void AddToCollection(Music music, string userId, ForestContext context);

        void AddGenre(Genre genre, string userId, ForestContext context);
        User GetUser(Music music, ForestContext context);
        void RemoveFromCollection(Music music, ForestContext context);
        void AddUser(User user, ForestContext context);
        void AddToCollection(Order order, string userId, ForestContext context);
        User GetUser(string userId, ForestContext context);
    }
}
