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
    public class CatController : Controller
    {
        private CategoryModel db = new CategoryModel();

        // GET: Cat
        public ActionResult Index()
        {
            return View(db.CATEGORIES.ToList());
        }

        // GET: Cat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIES cATEGORIES = db.CATEGORIES.Find(id);
            if (cATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIES);
        }

        // GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CATEGORYID,CATEGORYNAME")] CATEGORIES cATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIES.Add(cATEGORIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIES);
        }

        // GET: Cat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIES cATEGORIES = db.CATEGORIES.Find(id);
            if (cATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIES);
        }

        // POST: Cat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CATEGORYID,CATEGORYNAME")] CATEGORIES cATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIES);
        }

        // GET: Cat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIES cATEGORIES = db.CATEGORIES.Find(id);
            if (cATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIES);
        }

        // POST: Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIES cATEGORIES = db.CATEGORIES.Find(id);
            db.CATEGORIES.Remove(cATEGORIES);
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
