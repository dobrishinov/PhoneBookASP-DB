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
    public class PhonesManagerController : Controller
    {
        [HttpGet]
        public ActionResult EditPhone(int? ContactId, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            PhoneRepository phonesRepository = new PhoneRepository();

            PhoneEntity phone = null;
            if (id == null)
            {
                phone = new PhoneEntity();
                phone.ContactId = ContactId.Value;
            }
            else
                phone = phonesRepository.GetById(id.Value);

            ViewData["phone"] = phone;

            return View();
        }
        [HttpPost]
        public ActionResult EditPhone()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            PhoneEntity phone = new PhoneEntity();
            TryUpdateModel(phone);

            PhoneRepository phonesRepository = new PhoneRepository();
            phonesRepository.Save(phone);

            return RedirectToAction("ContactDetails", "ContactsManager", new { id = phone.ContactId });
        }

        public ActionResult DeletePhone(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            PhoneRepository phonesRepository = new PhoneRepository();
            PhoneEntity phone = phonesRepository.GetById(id);
            phonesRepository.Delete(phone);

            return RedirectToAction("ContactDetails", "ContactsManager", new { id = phone.ContactId });
        }
    }
}