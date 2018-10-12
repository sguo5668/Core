using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using Entity;
using DTO;
namespace MiddleTier
{
    public class Customer : CustomerEntyityAddress
    {
        
        public List<CustomerDTO> getCustomers()
        {
            CustomerDal obj = new CustomerDal();
            
            return obj.getCustomers();
        }

        public void Add()
        {
            CustomerDal obj = new CustomerDal();
            obj.Add(this);
        }
      
    }
}
