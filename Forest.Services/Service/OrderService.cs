using Forest.Data.DAO;
using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using Forest.Services.IService;
using Forest.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Service
{
    public class OrderService : IOrderService
    {
        private IOrderlineDAO orderlineDAO;
        private IMusicDAO musicDAO;
        private IOrderDAO orderDAO;
        private IUserDAO userDAO;
        public OrderService()
        {
            orderlineDAO = new OrderlineDAO();
            musicDAO = new MusicDAO();
            orderDAO = new OrderDAO();
            userDAO = new UserDAO();
        }
        public void AddOrder(CheckOutUser checkOutUser)
        {
            using (ForestContext context = new ForestContext())
            {
                IList<OrderLine> orderLines = new List<OrderLine>();
                {
                    foreach (CartMusic music in checkOutUser.Cart)
                    {
                        OrderLine orderLine = new OrderLine()
                        {

                            Quantity = music.Quantity,
                            Id = music.Music.Id


                        };
                        orderLines.Add(orderLine);
                        musicDAO.AddToCollection(orderLine, orderLine.Id, context);

                    }
                    Order order = new Order()
                    {
                        DelAddress = checkOutUser.DelAddress,
                        OrderLines = orderLines
                    };
                    orderDAO.Add(order, context);
                    User user = checkOutUser.User;
                    //user.Orders.Add(order);
                    userDAO.AddToCollection(order, user.UserId, context);
                    context.SaveChanges();

                }

            }
        }
    }
}
