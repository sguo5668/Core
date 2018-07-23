using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CrqsTodo.Interfaces;
using CrqsTodo.Commands;
using CrqsTodo.CommandHandlers;
using CrqsTodo.Queries;
using CrqsTodo.DTO;
using CqrsTodo.CommandHandlers;
using CrqsTodo.QueryHandlers;

namespace CrqsTodo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TodoContext>(options =>
                options.UseSqlServer(connection));

             services.AddMvc();
            //services.AddTransient<IValidator<Todo>, TodoValidator>();
            //services.AddSignalR();

            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();

            services.AddTransient<ICommandHandler<CreateTodo>, CreateTodoHandler>();
            services.AddTransient<ICommandHandler<DeleteTodo>, DeleteTodoHandler>();

            services.AddTransient<ICommandHandler<UpdateTodo>, UpdateTodoHandler>();
            services.AddTransient<ICommandHandler<MakeComplete>, MakeCompleteHandler>();

            services.AddTransient<IQueryHandler<GetAllTodo, Task<IEnumerable<Todo>>>, GetAllTodoHandler>();
            services.AddTransient<IQueryHandler<GetTodoById, Task<Todo>>, GetTodoByIdHandler>();
            services.AddTransient<IQueryHandler<GetTodoCount, Task<int>>, GetTodoCountHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
