using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCCore1.Models;

namespace MVCCore1.Controllers
{
    public class DemoController : Controller
    {
        private readonly DatabaseContext _context;
        public DemoController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CountryMaster> countrylist = new List<CountryMaster>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            countrylist = (from product in _context.CountryMaster
                           select product).ToList();

            // ------- Inserting Select Item in List -------
            countrylist.Insert(0, new CountryMaster { ID = 0, Name = "Select" });

            // ------- Assigning countrylist to ViewBag.ListofCountry -------
            ViewBag.ListofCountry = countrylist;
            return View();
        }

        [HttpPost]
        public IActionResult Index(CountryMaster CountryMaster)
        {
            // ------- Validation ------- //

            if (CountryMaster.ID == 0)
            {
                ModelState.AddModelError("", "Select Country");
            }

            // ------- Getting selected Value ------- //
            int SelectValue = CountryMaster.ID;

            ViewBag.SelectedValue = CountryMaster.ID;

            // ------- Setting Data back to ViewBag after Posting Form ------- //

            List<CountryMaster> countrylist = new List<Models.CountryMaster>();

            countrylist = (from product in _context.CountryMaster
                           select product).ToList();

            countrylist.Insert(0, new CountryMaster { ID = 0, Name = "Select" });
            ViewBag.ListofCountry = countrylist;
            // ---------------------------------------------------------------- //

            return View();
        }

    }
}
