using System.ComponentModel.DataAnnotations;

namespace Repo.Model
{
    public class BookViewModel
    {
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
