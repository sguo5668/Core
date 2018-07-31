using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.ViewComponents
{
    public class Address: ViewComponent
	{

		IAddressRepository _addressRepository;

		public Address(IAddressRepository addressRepository) {

			_addressRepository = addressRepository;

		}

		public async Task<IViewComponentResult> InvokeAsync(int AddressType)
		{

			//AddressModel address = new AddressModel()
			//{

			//	Address1="123 main",
			//	Address2 = "Bldg #1",
			//	City="Fremont",
			//	State= new StateModel {StateName = "CA" },
			//	Zip="94536"

			//};

			//return View("Address", address);

			var items = await _addressRepository.GetTypedAddressAsync(AddressType);

			 

			return View(items);

		}

	}
}
