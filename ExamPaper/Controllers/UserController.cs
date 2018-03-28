using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamPaper.Models;
using ExamPaper.Models.ViewModel;

namespace ExamPaper.Controllers
{
    public class UserController : Controller
    {
        private _ExamPaper db = new _ExamPaper();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRegistrationVM userRegVm)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Id = userRegVm.Id;
                user.Name = userRegVm.Name;
                user.Email = userRegVm.Email;
                user.DOB = userRegVm.DOB;
                user.Password = userRegVm.ConfirmPassword;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(userRegVm);
        }

        public ActionResult Index()
        {
            return View(db.User.ToList());
        }
    }
}