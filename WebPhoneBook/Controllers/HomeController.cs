using WebPhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.Entity;

namespace WebPhoneBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Authenticate(username, password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
                ViewData["username"] = username;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            AuthenticationManager.Logout();
            
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Fake()
        {
            UserRepository urepo = new UserRepository();
            UserEntity u = new UserEntity();
            u.Username = "admin";
            u.Password = "admin";
            u.LastName = "admin";
            u.FirstName = "admin";
            u.AdminStatus = true;
            urepo.Save(u);
            return View();
        }
    }
}