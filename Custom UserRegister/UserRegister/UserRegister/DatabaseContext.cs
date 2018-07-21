using Microsoft.EntityFrameworkCore;
using UserRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegister
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
          
        }
        public DbSet<RegisterUser> RegisterUser { get; set; }
 
        
    }
}
