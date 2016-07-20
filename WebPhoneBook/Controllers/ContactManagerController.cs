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
    public class ContactsManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contactsRepository =new ContactsRepository();
           ViewData["contacts"] = contactsRepository.GetAll(c=>c.UserId==AuthenticationManager.LoggedUser.Id);

            return View();
        }
        public ActionResult ContactDetails(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contactsRepository = new ContactsRepository();
            PhoneRepository phonesRepository = new PhoneRepository();

            ViewData["contact"] = contactsRepository.GetById(id);
            ViewData["phones"] = phonesRepository.GetAll(p=>p.ContactId==id);

            return View();
        }
        [HttpGet]
        public ActionResult EditContact(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contactsRepository = new ContactsRepository();

            ContactEntity contact = null;
            if (id == null)
            {
                contact = new ContactEntity();
                contact.UserId = AuthenticationManager.LoggedUser.Id;
            }
            else
                contact = contactsRepository.GetById(id.Value);

            ViewData["contact"] = contact;

            return View();
        }
        [HttpPost]
        public ActionResult EditContact(ContactEntity contact)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contactsRepository = new ContactsRepository();
            contactsRepository.Save(contact);

            return RedirectToAction("Index", "ContactsManager");
        }

        public ActionResult DeleteContact(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contactsRepository = new ContactsRepository();
            ContactEntity contact = contactsRepository.GetById(id);
            contactsRepository.Delete(contact);

            return RedirectToAction("Index", "ContactsManager");
        }
    }
}