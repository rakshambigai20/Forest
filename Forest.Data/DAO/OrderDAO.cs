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
    public class OrderDAO: IOrderDAO
    {
        public void Add(Order order, ForestContext context)
        {
            context.Orders.Add(order);
        }

    }
}
