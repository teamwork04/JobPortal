using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    [Authorize(Roles = "Employer")]
    public class MyPagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyPages
        public ActionResult Index()
        {
            return View(db.MyPages.ToList());
        }

        // GET: MyPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPage myPage = db.MyPages.Find(id);
            if (myPage == null)
            {
                return HttpNotFound();
            }
            return View(myPage);
        }

        // GET: MyPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Age,Summary,Experience,Skills,Languages,Hobbies")] MyPage myPage)
        {
            if (ModelState.IsValid)
            {
                db.MyPages.Add(myPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myPage);
        }

        // GET: MyPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPage myPage = db.MyPages.Find(id);
            if (myPage == null)
            {
                return HttpNotFound();
            }
            return View(myPage);
        }

        // POST: MyPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Age,Summary,Experience,Skills,Languages,Hobbies")] MyPage myPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myPage);
        }

        // GET: MyPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPage myPage = db.MyPages.Find(id);
            if (myPage == null)
            {
                return HttpNotFound();
            }
            return View(myPage);
        }

        // POST: MyPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyPage myPage = db.MyPages.Find(id);
            db.MyPages.Remove(myPage);
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
