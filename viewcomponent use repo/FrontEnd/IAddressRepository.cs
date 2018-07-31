using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Models;

namespace FrontEnd
{
	public interface IAddressRepository
	{
		Task<AddressModel> GetTypedAddressAsync(int AddressType);
	}
}
