using Forest.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Models
{
    public class CartMusic
    {
        public int Quantity { get; set; }
        public Music Music { get; set; }
    }
}
