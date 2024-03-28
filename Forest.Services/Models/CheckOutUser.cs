using Forest.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.Models
{
    public class CheckOutUser
    {
        public User User { get; set; }
        public string DelAddress { get; set; }  
        public IList<CartMusic> Cart { get; set; }
    }
}
