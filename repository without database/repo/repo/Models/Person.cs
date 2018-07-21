using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace repo.Models
{
	public class Person
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[StringLength(10)]
		//  [RequiredIf("City", null)]
		public string Name { get; set; }

	 	public string City { get; set; }

		 	//  [RegularExpression("^(\\w)+$", ErrorMessage = "Only letters are permitted in the Country field")]
		public string Country { get; set; }

		// this field is last in the class - therefore any RequiredAttribute validation that occurs
		// on fields before it don't guarantee this field's value is correctly set - see my blog post 
		// if that doesn't make sense!
		[DisplayName("UK Resident")]
		public bool IsUKResident { get; set; }
	}
}
