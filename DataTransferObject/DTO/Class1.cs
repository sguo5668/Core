using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
namespace DTO
{
    public class CustomerDTO : CustomerEntity 
    {
        public AddressEntity _Address = new AddressEntity();
        
    }
}
