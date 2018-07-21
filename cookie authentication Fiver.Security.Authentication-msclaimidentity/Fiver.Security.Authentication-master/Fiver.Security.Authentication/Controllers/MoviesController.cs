﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Security.Authentication.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
