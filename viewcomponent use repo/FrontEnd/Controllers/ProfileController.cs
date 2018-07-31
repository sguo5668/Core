using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
			return ViewComponent("Address", new { AddressType = AddressType.Shipping });
		}

  //      public IActionResult UpdateShippingAddress()
  //      {
		
		//}

        public IActionResult UpdateResidenceAddress()
        {
			return ViewComponent("Address", new { AddressType = AddressType.Residence });
		}

 
    }
}
