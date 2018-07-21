using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SeedData2
{
    public class Startup
    {

		private const string ReadModelDBName = "ReadModel";
		public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


			services.AddSingleton(x => new MongoClient("mongodb://localhost:27017"));
			services.AddSingleton(x => x.GetService<MongoClient>().GetDatabase(ReadModelDBName));


			services.AddTransient<IReadOnlyRepository<Product>, MongoDBRepository<Product>>();
			services.AddTransient<IRepository<Product>, MongoDBRepository<Product>>();
			services.AddTransient<IReadOnlyRepository<Customer>, MongoDBRepository<Customer>>();
			services.AddTransient<IRepository<Customer>, MongoDBRepository<Customer>>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,
	    IRepository<Product> productRepository,	IRepository<Customer> customerRepository, MongoClient mongoClient)
		{
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


			if (!productRepository.FindAllAsync(x => true).Result.Any()
				 && !customerRepository.FindAllAsync(x => true).Result.Any()
				)
			{
				SeedReadModel(productRepository, customerRepository);
			}


		}


		private void SeedReadModel(IRepository<Product> productRepository
		  , IRepository<Customer> customerRepository
		 )
		{
			var insertingProducts = new[] {
				new Product
				{
					Id = $"Product-{Guid.NewGuid().ToString()}",
					Name = "Laptop"
				},
				new Product
				{
					Id = $"Product-{Guid.NewGuid().ToString()}",
					Name = "Smartphone"
				},
				new Product
				{
					Id = $"Product-{Guid.NewGuid().ToString()}",
					Name = "Gaming PC"
				},
				new Product
				{
					Id = $"Product-{Guid.NewGuid().ToString()}",
					Name = "Microwave oven"
				},
			}
			.Select(x => productRepository.InsertAsync(x));

			var insertingCustomers = new Customer[] {
				new Customer
				{
					Id = $"Customer-{Guid.NewGuid().ToString()}",
					Name = "Andrea"
				},
				new Customer
				{
					Id = $"Customer-{Guid.NewGuid().ToString()}",
					Name = "Martina"
				},
			}
			.Select(x => customerRepository.InsertAsync(x));

			Task.WaitAll(insertingProducts.Union(insertingCustomers).ToArray());
		}
	}
}
