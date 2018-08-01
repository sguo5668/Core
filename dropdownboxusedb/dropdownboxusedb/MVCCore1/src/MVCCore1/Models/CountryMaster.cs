using System.ComponentModel.DataAnnotations;

namespace MVCCore1.Models
{
    public class CountryMaster
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Country Name")]
        public string Name { get; set; }
    }
}
