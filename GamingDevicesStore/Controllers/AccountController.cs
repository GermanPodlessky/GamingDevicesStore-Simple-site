using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Controllers
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }

    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }
    }

    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public AccountController()
        {
            authProvider = new FormAuthProvider();
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid && authProvider != null)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}