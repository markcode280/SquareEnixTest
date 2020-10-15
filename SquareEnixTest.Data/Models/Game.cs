using Microsoft.EntityFrameworkCore.Storage;
using ServiceStack.DataAnnotations;
using SquareEnixTest.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquareEnixTest.Data
{
    [Table("Game")]
    public class Game
    {
      
        [Key]
        public int Id { get; set; }
        
        
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GamePlatforms> Platforms { get; set; }
        public Genre Genre { get; set; }

    }
}
