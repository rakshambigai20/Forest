using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Forest.Data.Models.Domain
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

        public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();



    }
}
