using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPIStore.Models
{
    [Table("ServicesTB")]
    public class ServicesTB
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string APIName { get; set; }
    }
}
