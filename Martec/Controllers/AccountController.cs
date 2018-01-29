using Martec.Domain.Interfaces;
using Martec.Domain.Managers;
using Martec.Domain.Models;
using Martec.Infrastructure.Service;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Infrastruture.Utilities;
using Martec.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Controllers
{
    public class AccountController : Controller
    {

        private UserManager _user;

        // GET: Account
        public AccountController(UserManager user)
        {
            //var repo = new UserRepository(new MartecEntities());
            //_user = new UserManager(repo, new MD5Encryption(), new EmailNotification());
            _user = user;

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _user.Login(model.Email, model.Password);
                if (user != null)
                {
                    var auth = HttpContext.GetOwinContext().Authentication;
                    var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.Email,user.Email),
                        new Claim (ClaimTypes.Name,user.Email),
                        new Claim(ClaimTypes.GivenName,user.FirstName),
                        new Claim (ClaimTypes.Surname,user.LastName),
                        new Claim (ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    };

                    var roleClaims = user.Roles.Select(r => new Claim(ClaimTypes.Role, r));

                    claims.AddRange(roleClaims);

                    var identity = new ClaimsIdentity(claims, Constants.Authentication.Type);

                    auth.SignIn(new Microsoft.Owin.Security.AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        //return Redirect(Request.UrlReferrer.ToString());
                        return Redirect(returnUrl);

                    }

                    return RedirectToAction("Showcart", "Cart");
                }

            }
            ModelState.AddModelError("Invalid Login", "Invalid Email and password");

            return View(model);
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new UserModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,


                    };
                    _user.RegisterUser(user, model.Password);
                    return RedirectToAction("login", "account");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                    ModelState.AddModelError("Error", ex);
                }

            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var auth = HttpContext.GetOwinContext().Authentication;
            auth.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}