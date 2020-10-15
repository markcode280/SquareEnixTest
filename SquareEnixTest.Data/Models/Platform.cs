using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SquareEnixTest.Data.Models
{
    [Table("Platform")]
   public class Platform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public virtual ICollection<GamePlatforms> Games { get; set; }
        
    }
}
