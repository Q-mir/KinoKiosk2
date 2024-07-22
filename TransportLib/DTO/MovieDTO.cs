using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLib.DTO
{
    public class MovieDTO
    {
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Actor { get; set; } = null!;
    }
}
