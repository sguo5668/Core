using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models.Student
{
    public class PersonalDetail
    {
       [Key]
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
