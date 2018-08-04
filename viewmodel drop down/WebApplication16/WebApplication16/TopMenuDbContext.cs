using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication16
{
	public class TopMenuDbContext : DbContext
	{
		public DbSet<MenuItem> MenuItems { get; set; }

		public TopMenuDbContext(DbContextOptions<TopMenuDbContext> options) : base(options)
		{
		}

		public void AddMenuItems()
		{
			MenuItems.Add(new MenuItem { Title = "Home", Url = "~/" });
			MenuItems.Add(new MenuItem { Title = "About", Url = "~/Home/About" });
			MenuItems.Add(new MenuItem { Title = "External", Url = "http://gunnarpeipman.com", OpenInNewWindow = true });

			SaveChanges();
		}
	}
}
