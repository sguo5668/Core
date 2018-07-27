 
using MVCRealWorld.Models.ViewModel;
using MVCRealWorld.Models.EntityManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVC5RealWorld.Controllers
{
    public class AccountController : Controller
    {      
        public async Task<IActionResult> SignUp() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpView USV) {
            if (ModelState.IsValid) {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName)) {
                    UM.AddUserAccount(USV);
					//   FormsAuthentication.SetAuthCookie(USV.FirstName, false);

					// create claims
					List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, "Sean Connery"),
				new Claim(ClaimTypes.Email, USV.LoginName)
			};

					// create identity
					ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

					// create principal
					ClaimsPrincipal principal = new ClaimsPrincipal(identity);

					// sign-in
					await HttpContext.SignInAsync(
							scheme: CookieAuthenticationDefaults.AuthenticationScheme,
							principal: principal);




					//return RedirectToAction("Welcome", "Home");

					return RedirectToAction("Index", "Home");


				}
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        [Authorize]
		public async Task<IActionResult> SignOut() {
			//  FormsAuthentication.SignOut();

			//await HttpContext.SignOutAsync(
			//	  scheme: "FiverSecurityCookie");
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			


			return RedirectToAction("Login", "Account");
        }


        public async Task<IActionResult> LogIn() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginView ULV, string returnUrl) {


            if (ModelState.IsValid) {


		 


				UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else {
                    if (ULV.Password.Equals(password)) {
						//FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
						//return RedirectToAction("Welcome", "Home");
						//  FormsAuthentication.RedirectFromLoginPage(ULV.LoginName, false);

						List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, "Sean Connery"),
				new Claim(ClaimTypes.Email, ULV.LoginName)
			};

						// create identity
						ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

						// create principal
						ClaimsPrincipal principal = new ClaimsPrincipal(identity);

						// sign-in
						await HttpContext.SignInAsync(
								scheme: CookieAuthenticationDefaults.AuthenticationScheme,
								principal: principal);

						return RedirectToAction("Index", "Home");

					}
					else {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ULV);
        }
    }
}