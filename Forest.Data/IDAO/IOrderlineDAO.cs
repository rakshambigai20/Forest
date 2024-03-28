using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.IDAO
{
    public interface IOrderlineDAO
    {
        public void Add(OrderLine orderline, ForestContext context);
    }
}
