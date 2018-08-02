using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.ViewComponents
{
	public class TopMenu : ViewComponent
	{
		private readonly TopMenuDbContext _context;

		public TopMenu(TopMenuDbContext context)
		{
			_context = context;

			_context.AddMenuItems();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = _context.MenuItems.ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", model));
		}
	}
}
