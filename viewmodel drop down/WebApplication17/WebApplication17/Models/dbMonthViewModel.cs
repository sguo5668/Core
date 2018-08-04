﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication17.Models
{

	public class dbMonthViewModel
	{
		public string[] MonthData { get; set; }
		public int SelectedMonth { get; set; }
		public IEnumerable<SelectListItem> GetMonthSelectList(int defaultValue)
		{
			return MonthData
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
