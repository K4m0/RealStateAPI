using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Models
{
    public class PropertyImageDTO
    {
        public long? IdPropertyImage { get; set; }
        public long IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
