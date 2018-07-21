using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserRegister.Models;
 
using UserRegister.AES256Encryption;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserRegister.Controllers
{
    public class RegisterUserController : Controller
    {
        IRegisterUser _repository;
        public RegisterUserController(IRegisterUser repository)
        {
            _repository = repository;
        }

        [HttpGet]
        // GET: RegisterUser/Create
        public ActionResult Create()
        {
            return View(new RegisterUser());
        }

        // POST: RegisterUser/Create
        [HttpPost]
        public ActionResult Create(RegisterUser RegisterUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", RegisterUser);
                }

                // Validating Username 
                if (_repository.ValidateUsername(RegisterUser))
                {
                    ModelState.AddModelError("", "User is Already Registered");
                    return View("Create", RegisterUser);
                }
                RegisterUser.CreateDate = DateTime.Now;

                // Encrypting Password with AES 256 Algorithm
                RegisterUser.Password = EncryptionLibrary.EncryptText(RegisterUser.Password);

                // Saving User Details in Database
                _repository.Add(RegisterUser);
                TempData["UserMessage"] = "User Registered Successfully";
                ModelState.Clear();
                return View("Create", new RegisterUser());
            }
            catch
            {
                return View();
            }
        }
    }
}
