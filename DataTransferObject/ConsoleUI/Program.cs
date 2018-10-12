using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleTier;
using Entity;
using DTO;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // From Data out
            Customer obj = new Customer();
            List<CustomerDTO> oCustomers = obj.getCustomers();

            // Data in
            Customer objCust = new Customer();
            objCust.CustomerCode = "c001";
            objCust.CustomerName = "Shivprasad";
            
            AddressEntity objAddress = new AddressEntity();
            objAddress.Address1 = "Mumbai";
            objCust.Add(objAddress);


        }
    }
}
