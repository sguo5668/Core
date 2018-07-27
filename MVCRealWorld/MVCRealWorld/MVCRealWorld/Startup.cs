using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVCRealWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

			//services.AddAuthentication("FiverSecurityScheme")
			//	.AddCookie("FiverSecurityScheme", options =>
			//	{
			//		options.AccessDeniedPath = new PathString("/Account/Access");
			//		options.Cookie = new CookieBuilder
			//		{
			//				//Domain = "",
			//				HttpOnly = true,
			//			Name = ".Fiver.Security.Cookie",
			//			Path = "/",
			//			SameSite = SameSiteMode.Lax,
			//			SecurePolicy = CookieSecurePolicy.SameAsRequest
			//		};
			//		options.Events = new CookieAuthenticationEvents
			//		{
			//			OnSignedIn = context =>
			//			{
			//				Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
			//				  "OnSignedIn", context.Principal.Identity.Name);
			//				return Task.CompletedTask;
			//			},
			//			OnSigningOut = context =>
			//			{
			//				Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
			//				  "OnSigningOut", context.HttpContext.User.Identity.Name);
			//				return Task.CompletedTask;
			//			},
			//			OnValidatePrincipal = context =>
			//			{
			//				Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
			//				  "OnValidatePrincipal", context.Principal.Identity.Name);
			//				return Task.CompletedTask;
			//			}
			//		};
			//			//options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
			//			options.LoginPath = new PathString("/Account/Login");
			//		options.ReturnUrlParameter = "RequestPath";
			//		options.SlidingExpiration = true;
			//	});

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		   .AddCookie();

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

			app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=LogIn}/{id?}");
            });
        }
    }
}
