﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenDemo.Data
{
    public  class SeedDatabase
    {

        public static void initializer( IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {

                ApplicationUser user = new ApplicationUser()
                {

                    Email = "s@s.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "sam"
                };

                userManager.CreateAsync(user, "Password@123");


            }

        }
    }
}
