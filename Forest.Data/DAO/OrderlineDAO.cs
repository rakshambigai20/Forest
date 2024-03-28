using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forest.Data.DAO
{
    public class OrderlineDAO : IOrderlineDAO
    {
        public void Add(OrderLine orderLine, ForestContext context)
        {
            context.OrderLines.Add(orderLine);
        }
        
    }
}
