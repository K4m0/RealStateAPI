using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Entities
{
    public class PropertyImage
    {
        [Key]
        public long IdPropertyImage { get; set; }
        public long IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
