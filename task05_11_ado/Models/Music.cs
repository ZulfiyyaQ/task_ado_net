using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05_11_ado.Models
{
    internal class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
