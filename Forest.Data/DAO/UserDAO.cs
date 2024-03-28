using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.DAO
{
    public class UserDAO : IUserDAO
    {
        public IList<User> GetUsers(ForestContext context)
        {
            return context.Users.ToList();
        }
        public void AddToCollection(Music music, string userId, ForestContext context)
        {
            User user = context.Users.Find(userId);
            if (user != null)
            {
                user.Musics.Add(music);
            }
        }
        public void AddGenre(Genre genre, string userId, ForestContext context)
        {
            User user = context.Users.Find(userId);
            if (user != null) 
            {
                user.Genres.Add(genre);
            }
        }
        public User GetUser(Music music, ForestContext context)
        {
            IList<User> users = GetUsers(context);
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Musics.Contains<Music>(music))
                {
                    return users[i];
                }
            }
            return null;

        }
        public void RemoveFromCollection(Music music,ForestContext context)
        {
            User user = GetUser(music, context);
            user.Musics.Remove(music);
        }
        public void AddUser(User user, ForestContext context)
        {
            context.Users.Add(user);
        }
        public User GetUser(string userId, ForestContext context)
        {
            User user = context.Users.Find(userId);
            return user;
        }
        public void AddToCollection(Order order, string userId, ForestContext context)
        {
            User user = context.Users.Find(userId); 
            if (user != null) 
            {
                user.Orders.Add(order);
            }
                
        }

        
    }
}
