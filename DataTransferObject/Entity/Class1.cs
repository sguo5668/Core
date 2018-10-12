using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CustomerEntity
    {
        protected string _CustomerName = "";
        protected string _CustomerCode = "";        
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

    }
    public class AddressEntity
    {
        private string _Address1;

        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }
        private string _Address2;

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }
        private string _PinCode;

        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }

    }
    public class CustomerEntyityAddress : CustomerEntity
    {
        private List<AddressEntity> _Addresses = new List<AddressEntity>();
        public void Add(AddressEntity obj)
        {
            if (obj.Address1.Length == 0)
            {
                new Exception("Compulsory");
            }
            _Addresses.Add(obj);
        }
    }
}
