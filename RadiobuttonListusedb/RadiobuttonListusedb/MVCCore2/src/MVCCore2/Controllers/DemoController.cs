using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCCore2.Models;
namespace MVCCore2.Controllers
{
    public class DemoController : Controller
    {
        private readonly DatabaseContext _context;
        public DemoController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
         // ------- Getting Data from Database Using EntityFrameworkCore -------

            List<Category> categorylist = new List<Category>();

            categorylist = (from category in _context.Category
                            select category).ToList();

         // ------- Creating instance of MainViewModel and assiging value to ListCategory -------

            MainViewModel obj = new MainViewModel();
            obj.ListCategory = categorylist;
            obj.Selectedanswer = string.Empty;
            return View(obj); // ------- Sending MainViewModel to Index View -------       
        }

        [HttpPost]
        public IActionResult Index(MainViewModel MainModel)
        {
            // -- Get Selected value from RadiobuttonList
            string SelectedValue = MainModel.Selectedanswer;

            List<Category> categorylist = new List<Category>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            categorylist = (from category in _context.Category
                            select category).ToList();

            // --Maintaining State of RadiobuttonList (Rebinding ListCategory)
            MainModel.ListCategory = categorylist;

            return View(MainModel);
        }


    }
}
