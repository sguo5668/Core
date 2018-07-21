using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MoviesAPIStore.MoviesContext;
using MoviesAPIStore.Repository;
using MoviesAPIStore.Models;
using Microsoft.AspNetCore.Http;
using MoviesAPIStore.Middlewares;
using Swashbuckle.AspNetCore.Swagger;

namespace MoviesAPIStore
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
            services.AddMvc();


 
            var connection = Configuration.GetConnectionString("DatabaseConnection");

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection, b => b.UseRowNumberForPaging()));
 
           // services.AddTransient<IServicesStore, ServicesStoreConcrete>();
       
 
            services.AddTransient<IValidateRequest, ValidateRequestConcrete>();
            services.AddTransient<IMovies, MoviesConcrete>();
            services.AddTransient<IMusic, MusicConcrete>();
            services.AddTransient<IRequestLogger, RequestLoggerConcrete>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

 
            //Middleware Call
            app.UseMiddleware<ApiKeyValidatorsMiddleware>();

		
			app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

		
		}
    }
}
