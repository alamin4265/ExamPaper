using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamPaper.Models;

namespace ExamPaper.Controllers
{
    public class EnglishQuestionBankController : Controller
    {
        private _ExamPaper db = new _ExamPaper();

        // GET: EnglishQuestionBank
        public ActionResult Index()
        {
            var englishQuestionBank = db.EnglishQuestionBank.Include(e => e.User);
            return View(englishQuestionBank.ToList());
        }

        // GET: EnglishQuestionBank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishQuestionBank englishQuestionBank = db.EnglishQuestionBank.Find(id);
            if (englishQuestionBank == null)
            {
                return HttpNotFound();
            }
            return View(englishQuestionBank);
        }

        // GET: EnglishQuestionBank/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            return View();
        }

        // POST: EnglishQuestionBank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,OptionA,OptionB,OptionC,OptionD,Verified,Answer,Approve,Date,UserId,CategoyId")] EnglishQuestionBank englishQuestionBank)
        {
            if (englishQuestionBank.Answer == "A")
            {
                englishQuestionBank.Answer = englishQuestionBank.OptionA;
            }
            else if (englishQuestionBank.Answer == "B")
            {
                englishQuestionBank.Answer = englishQuestionBank.OptionB;
            }
            else if (englishQuestionBank.Answer == "C")
            {
                englishQuestionBank.Answer = englishQuestionBank.OptionC;
            }
            else if (englishQuestionBank.Answer == "D")
            {
                englishQuestionBank.Answer = englishQuestionBank.OptionD;
            }
            else
            {
                ModelState.AddModelError("Answer","Answer Is Mandatory");
            }
            if (ModelState.IsValid)
            {
                englishQuestionBank.CategoryId = 1;
                englishQuestionBank.Date = DateTime.Now;
                englishQuestionBank.UserId = 1;
                englishQuestionBank.Approve = true;
                
                db.EnglishQuestionBank.Add(englishQuestionBank);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.UserId = new SelectList(db.User, "Id", "Name", englishQuestionBank.UserId);
            return View(englishQuestionBank);
        }

        // GET: EnglishQuestionBank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishQuestionBank englishQuestionBank = db.EnglishQuestionBank.Find(id);
            if (englishQuestionBank == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", englishQuestionBank.UserId);
            return View(englishQuestionBank);
        }

        // POST: EnglishQuestionBank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,OptionA,OptionB,OptionC,OptionD,Verified,Answer,Approve,Date,UserId,CategoyId")] EnglishQuestionBank englishQuestionBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishQuestionBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", englishQuestionBank.UserId);
            return View(englishQuestionBank);
        }

        // GET: EnglishQuestionBank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishQuestionBank englishQuestionBank = db.EnglishQuestionBank.Find(id);
            if (englishQuestionBank == null)
            {
                return HttpNotFound();
            }
            return View(englishQuestionBank);
        }

        // POST: EnglishQuestionBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishQuestionBank englishQuestionBank = db.EnglishQuestionBank.Find(id);
            db.EnglishQuestionBank.Remove(englishQuestionBank);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
