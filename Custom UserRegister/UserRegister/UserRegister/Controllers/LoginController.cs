using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegister.AES256Encryption;
using UserRegister.Models;
 
using System;
 

namespace UserRegister.Controllers
{

    public class LoginController : Controller
    {
        IRegisterUser _IRegisterUser;

 
		public LoginController(IRegisterUser IRegisterUser)
        {
            _IRegisterUser = IRegisterUser;


        }

        public ActionResult Login()
        {

	 
			return View(new RegisterUser());
        }

        [HttpPost]
        public ActionResult Login(RegisterUser RegisterUser)
        {


 
			try
            {

                if (string.IsNullOrEmpty(RegisterUser.Username) && (string.IsNullOrEmpty(RegisterUser.Password)))
                {
                    ModelState.AddModelError("", "Enter Username and Password");
                }
                else if (string.IsNullOrEmpty(RegisterUser.Username))
                {
                    ModelState.AddModelError("", "Enter Username");
                }
                else if (string.IsNullOrEmpty(RegisterUser.Password))
                {
                    ModelState.AddModelError("", "Enter Password");
                }
                else
                {

                   RegisterUser.Password = EncryptionLibrary.EncryptText(RegisterUser.Password);

                    if (_IRegisterUser.ValidateRegisteredUser(RegisterUser))
                    {
                        var UserID = _IRegisterUser.GetLoggedUserID(RegisterUser);
                        HttpContext.Session.SetString("UserID", Convert.ToString(UserID));

                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User is Already Registered");
                        return View("Login", RegisterUser);
                    }
                }

                return View("Login", RegisterUser);
            }
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }

}
