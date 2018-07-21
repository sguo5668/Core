﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenDemo.Data;
using TokenDemo.Model;

namespace TokenDemo.Controllers
{

    [Route("api/[controller]")]
    public class AuthController: Controller

    {

        private UserManager<ApplicationUser> userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {

            this.userManager = userManager;

        }
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var user = await userManager.FindByNameAsync(model.Username);
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

            if (user !=null && await  userManager.CheckPasswordAsync(user, model.Password))
            {

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = new JwtSecurityToken(
                    issuer : "http:///abc.com",
                    audience: "http:///abc.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims : claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok( new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                    });
            }

            return Unauthorized();

        }


    }
}
