using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SquareEnixTest.Data.Models
{
    [Table("PlatformGames")]
    public class GamePlatforms
    {
        [Key]
        public int Id  { get; set; }
        public int GameId { get; set; }
        public int PlatFormId { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Game Game { get; set; }
    }
}
