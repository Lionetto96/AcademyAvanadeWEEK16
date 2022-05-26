using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IBusinessLayer bl;

        public UserController(IBusinessLayer businesslayer)
        {
            this.bl = businesslayer;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userVm)
        {
            if (userVm == null)
                return View();

            var account = bl.GetUserByUsername(userVm.Username);
            if (account != null && ModelState.IsValid)
            {
                if (account.Password.Equals(userVm.Password))
                {
                    //Utente è autenticato

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim(ClaimTypes.Name,account.Username)
                    };
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = userVm.ReturnUrl
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                    );
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(nameof(userVm.Password), "Invalid Password");
                    return View(userVm);
                }
            }
            return View(userVm);
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
