using Microsoft.EntityFrameworkCore;
using MoviesAPIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPIStore.MoviesContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
          
        }
 
        public DbSet<ServicesTB> ServicesTB { get; set; }
    
        public DbSet<APIManagerTB> APIManagerTB { get; set; }
        public DbSet<MoviesTB> MoviesTB { get; set; }
        public DbSet<MusicTB> MusicTB { get; set; }
        public DbSet<LoggerTB> LoggerTB { get; set; }

        
    }
}
