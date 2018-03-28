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
    public class BanglaQuestionBankController : Controller
    {
        private _ExamPaper db = new _ExamPaper();

        // GET: BanglaQuestionBank
        public ActionResult Index()
        {
            var banglaQuestionBank = db.BanglaQuestionBank.Include(b => b.User);
            return View(banglaQuestionBank.ToList());
        }

        // GET: BanglaQuestionBank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanglaQuestionBank banglaQuestionBank = db.BanglaQuestionBank.Find(id);
            if (banglaQuestionBank == null)
            {
                return HttpNotFound();
            }
            return View(banglaQuestionBank);
        }

        // GET: BanglaQuestionBank/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            return View();
        }

        // POST: BanglaQuestionBank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,OptionA,OptionB,OptionC,OptionD,Verified,Answer,Approve,Date,UserId,CategoyId")] BanglaQuestionBank banglaQuestionBank)
        {
            if (ModelState.IsValid)
            {
                db.BanglaQuestionBank.Add(banglaQuestionBank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User, "Id", "Name", banglaQuestionBank.UserId);
            return View(banglaQuestionBank);
        }

        // GET: BanglaQuestionBank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanglaQuestionBank banglaQuestionBank = db.BanglaQuestionBank.Find(id);
            if (banglaQuestionBank == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", banglaQuestionBank.UserId);
            return View(banglaQuestionBank);
        }

        // POST: BanglaQuestionBank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,OptionA,OptionB,OptionC,OptionD,Verified,Answer,Approve,Date,UserId,CategoyId")] BanglaQuestionBank banglaQuestionBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banglaQuestionBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", banglaQuestionBank.UserId);
            return View(banglaQuestionBank);
        }

        // GET: BanglaQuestionBank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanglaQuestionBank banglaQuestionBank = db.BanglaQuestionBank.Find(id);
            if (banglaQuestionBank == null)
            {
                return HttpNotFound();
            }
            return View(banglaQuestionBank);
        }

        // POST: BanglaQuestionBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BanglaQuestionBank banglaQuestionBank = db.BanglaQuestionBank.Find(id);
            db.BanglaQuestionBank.Remove(banglaQuestionBank);
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
