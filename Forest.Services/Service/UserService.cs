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
    
    public class UserService: IUserService
    {
        IUserDAO userDAO;
        public UserService()
        {
            userDAO = new UserDAO();
        }
        public void AddUser(User user) 
        {
            using(ForestContext context = new ForestContext()) 
            {
                userDAO.AddUser(user, context);
            }
        }

        public User GetUser(string userId)
        {
            using(ForestContext context = new ForestContext())
            {
                User user = userDAO.GetUser(userId, context);
                return user;
            }
        }
    }
}
