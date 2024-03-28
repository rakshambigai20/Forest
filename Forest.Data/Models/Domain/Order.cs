using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string DelAddress { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    }
}
