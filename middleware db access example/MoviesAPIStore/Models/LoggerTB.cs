using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPIStore.Models
{
    [Table("LoggerTB")]
    public class LoggerTB
    {
        [Key]
        public long LoggerID { get; set; }
        public string LoggerAPI { get; set; }
        public string APIKey { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Host { get; set; }
        public string Protocol { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string Scheme { get; set; }
        public string QueryString { get; set; }
        public string IsHttps { get; set; }
        public string RemoteIpAddress { get; set; }
    }

}
