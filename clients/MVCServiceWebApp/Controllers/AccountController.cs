using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MVCServiceWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" },
                Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
        }
        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties() { RedirectUri = "Home/Index" },
                Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            //return RedirectToAction("LogoutCompleted");
        }
        //public IActionResult LogoutCompleted()
        //{
        //    var myCookies = Request.Cookies.Keys;
        //    foreach (string cookie in myCookies)
        //    {
        //        Response.Cookies.Delete(cookie, new Microsoft.AspNetCore.Http.CookieOptions()
        //        {
        //            Domain = "https://localhost:3701"
        //        });
        //    }
        //    return Redirect("/Home/Index");
        //}
    }
}