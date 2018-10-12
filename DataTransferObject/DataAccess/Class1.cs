using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entity;
using DTO;
namespace DataAccess
{
    public class CustomerDal
    {
        public List<CustomerDTO> getCustomers()
        {
            // fetch customer records
            List<CustomerDTO> obj = new List<CustomerDTO>();


			var connectionString = "Server=(localdb)\\mssqllocaldb;Database=NorthWind;Trusted_Connection=True;MultipleActiveResultSets=true";

		

			string queryString = "SELECT customerid as customercode, contactname as customername, address as address1, city as address2 FROM Customers";

			SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);

			DataSet oCustomers = new DataSet();
			adapter.Fill(oCustomers, "Customers");



			DataSet oAddress = new DataSet(); // get address records for the custome

            foreach (DataRow o1 in oCustomers.Tables[0].Rows)
            {
                CustomerDTO o = new CustomerDTO();
                o.CustomerCode = o1[0].ToString();
                o.CustomerName = o1[1].ToString();
                o._Address.Address1 =  o1[2].ToString();
                o._Address.Address2 = o1[3].ToString();
                obj.Add(o);
            }
            return obj;
        }
       
        public bool Add(CustomerEntity obj)
        {
            // Insert in to DB
            return true;
        }
    }
}
