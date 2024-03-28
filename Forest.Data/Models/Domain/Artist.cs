using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.Models.Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}
