using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Security;
namespace BharatiRadio.Controllers
{
    public class AuthController : Controller
    {
        RadioContext db = new RadioContext();
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Auth user, string ReturnUrl)
        {
            var creds = db.Auths.Where(modal=> modal.UserName == user.UserName && modal.password== user.password).FirstOrDefault();
            if (creds != null)
            {
                FormsAuthentication.SetAuthCookie(creds.UserName, false);
                Session["UserName"] = creds.UserName.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else return RedirectToAction("Index", "Admin");
            }
            ViewBag.error = "Invalid Username or Password";
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Login", "Auth");
        }
    }
}