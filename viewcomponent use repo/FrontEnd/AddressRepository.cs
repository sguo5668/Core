using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Models;

namespace FrontEnd
{
    public class AddressRepository: IAddressRepository
    {

		static IList<AddressModel> alladdresses;

		public AddressRepository()
		{
			alladdresses = new List<AddressModel>()
		{
			new AddressModel() {
				Id =1001,
				Address1 ="1 high st",
				City ="sacramento",
				State= new StateModel {StateName = "California" },
				Zip ="94345",
				ZipExt ="1234",
				AddressType =0,
				PersonId =1 },

			new AddressModel() {
				Id =1002,
				Address1 ="2 high st",
				City ="fremont",
				State= new StateModel {StateName = "Nevada" },
				Zip ="94345",
				ZipExt ="1234",
				AddressType =1,
				PersonId =1 },
			new AddressModel() { Id=1003, Address1="3 high st", City="san jose", Zip="94345", ZipExt="1234",AddressType=0, PersonId=2 },
			new AddressModel() { Id=1004, Address1="4 high st", City="san jose", Zip="94345", ZipExt="1234",AddressType=1, PersonId=2 }
		};
		}


		public Task<AddressModel> GetTypedAddressAsync(int addresstype)
		{
			return Task.Run(() =>
			{
				AddressModel typedaddress = alladdresses.Where(b => b.AddressType==addresstype && b.PersonId ==1).SingleOrDefault();
				return typedaddress;
			});
		}

	}
}
