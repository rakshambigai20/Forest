using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Forest.Data.Models.Domain
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Tracks { get; set; }

        public int Minutes { get; set; }    
        public System.DateTime DateReleased { get; set; }
        public double Price { get; set; }   
        public string Image {  get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    }
}
