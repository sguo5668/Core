using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoApp.Models.Student;

namespace DemoApp.Controllers
{

    [Produces("application/json")]
    //[Route("api/StudentAPI")]
    public class StudentAPIController : Controller
    {
        // GET: api/GetAllStudents
        [HttpGet]
        [Route("api/StudentAPI/GetAllStudents")]
        public IEnumerable<PersonalDetail> GetAllStudents()
        {
            List<PersonalDetail> students = new List<PersonalDetail>
            {
            new PersonalDetail{
                               RegNo = "2017-0001",
                               Name = "Nishan",
                               Address = "Kathmandu",
                               PhoneNo = "9849845061",
                               AdmissionDate = DateTime.Now
                               },
            new PersonalDetail{
                               RegNo = "2017-0002",
                               Name = "Namrata Rai",
                               Address = "Bhaktapur",
                               PhoneNo = "9849845062",
                               AdmissionDate = DateTime.Now
                              },
             new PersonalDetail{
                               RegNo = "2017-0003",
                               Name = "Junge Rai",
                               Address = "Pokhara",
                               PhoneNo = "9849845063",
                               AdmissionDate = DateTime.Now
                              },
              new PersonalDetail{
                               RegNo = "2017-0004",
                               Name = "Sunita Ghimire",
                               Address = "Kathmandu",
                               PhoneNo = "9849845064",
                               AdmissionDate = DateTime.Now
                              },
               new PersonalDetail{
                               RegNo = "2017-0005",
                               Name = "John ",
                               Address = "Baneshwor",
                               PhoneNo = "9849845065",
                               AdmissionDate = DateTime.Now
                              },
            };
            return students;
        }
    }
}