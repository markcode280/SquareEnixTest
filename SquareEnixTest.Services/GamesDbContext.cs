using Microsoft.EntityFrameworkCore;
using SquareEnixTest.Data;
using SquareEnixTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Services
{
    public class GamesDbContext:DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> dbContextOptions):base(dbContextOptions)
        {
             
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GamePlatforms> GamePlatforms { get; set; }
       
    }
}
