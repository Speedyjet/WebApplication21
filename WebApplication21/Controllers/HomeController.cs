using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class HomeController : Controller
    {
        private BookModel db = new BookModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.BOOKS.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKS bOOKS = db.BOOKS.Find(id);
            if (bOOKS == null)
            {
                return HttpNotFound();
            }
            return View(bOOKS);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOKID,BOOKNAME,AUTHOR,ISBN")] BOOKS bOOKS)
        {
            if (ModelState.IsValid)
            {
                db.BOOKS.Add(bOOKS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOOKS);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKS bOOKS = db.BOOKS.Find(id);
            if (bOOKS == null)
            {
                return HttpNotFound();
            }
            return View(bOOKS);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKID,BOOKNAME,AUTHOR,ISBN")] BOOKS bOOKS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOKS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOKS);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKS bOOKS = db.BOOKS.Find(id);
            if (bOOKS == null)
            {
                return HttpNotFound();
            }
            return View(bOOKS);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOKS bOOKS = db.BOOKS.Find(id);
            db.BOOKS.Remove(bOOKS);
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
