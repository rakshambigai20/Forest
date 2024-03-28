using Forest.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IUserService
    {
        public void AddUser(User user);
        public User GetUser(string userId);
    }
}
