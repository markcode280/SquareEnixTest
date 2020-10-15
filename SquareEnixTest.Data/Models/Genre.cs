using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SquareEnixTest.Data.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
    }
}
