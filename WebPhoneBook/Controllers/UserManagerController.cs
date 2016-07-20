using DataAccess.Entity;
using DataAccess.Repository;
using WebPhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class UsersManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = new UserRepository();
            ViewData["users"] = usersRepository.GetAll();

            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = new UserRepository();

            UserEntity user = null;
            if (id == null)
                user = new UserEntity();
            else
                user = usersRepository.GetById(id.Value);

            ViewData["user"] = user;

            return View();
        }
        [HttpPost]
        public ActionResult EditUser(UserEntity user)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = new UserRepository();
            usersRepository.Save(user);

            return RedirectToAction("Index", "UsersManager");
        }

        public ActionResult DeleteUser(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = new UserRepository();
            UserEntity user = usersRepository.GetById(id);
            usersRepository.Delete(user);

            return RedirectToAction("Index", "UsersManager");
        }
    }
}