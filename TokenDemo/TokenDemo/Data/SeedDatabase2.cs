using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenDemo.Data
{
    public  class SeedDatabase2
    {

        public static void initializer( ApplicationDbContext context)
        {
 

            if (!context.Users.Any())
            {

                ApplicationUser user = new ApplicationUser()
                {

                    Email = "a@s.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "ram",
                    //  Password = "password@123"
                };

                context.Users.Add(user);
                context.SaveChangesAsync();
            }

        }
    }
}
