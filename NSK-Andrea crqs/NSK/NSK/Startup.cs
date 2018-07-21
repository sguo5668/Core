using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NSK.WorkerServices;

namespace NSK
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

			services.AddDbContext<NorthwindContext>(options =>
	 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddMvc();

			services.AddTransient<IDatabase, Database>();
			services.AddTransient<CatalogControllerWorkerServices>();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

			app.UseMvc(routes =>
			{
			 

				routes.MapRoute(
					name: "ProductsByCategory",
					template: "catalog/c/{categoryId}/{categoryName?}",
					defaults: new { controller = "Catalog", action = "ProductsByCategory" },
					constraints: new { categoryId = @"\d+" }
				);

				routes.MapRoute(
					name: "ProductsBySupplier",
					template: "catalog/s/{supplierId}/{supplierName?}",
					defaults: new { controller = "Catalog", action = "ProductsBySupplier" },
					constraints: new { supplierId = @"\d+" }
				);

				routes.MapRoute(
					name: "ProductPage",
					template: "product/{productId}/{productName?}",
					defaults: new { controller = "Catalog", action = "ProductDetail" },
					constraints: new { productId = @"\d+" }
				);

			 

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
    }
}
