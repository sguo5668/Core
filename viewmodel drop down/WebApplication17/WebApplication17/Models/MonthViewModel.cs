using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication17.Models
{
	public class MonthViewModel
	{
		private readonly string[] _months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

		public int SelectedMonth { get; set; }   //added to capture postback selection
		public IEnumerable<SelectListItem> GetMonthSelectList(int defaultValue)
		{
			return _months
				.Where(month => !string.IsNullOrEmpty(month))
				.Select((e, i) => new SelectListItem
				{
					Text = e + " - " + (i + 1).ToString(),
					Value = (i + 1).ToString(),
					Selected = (i + 1 == defaultValue)
				});
		}
	}
}
