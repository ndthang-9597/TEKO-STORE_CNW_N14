using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mars_Store.Models.Entities;

namespace Mars_Store.Areas.Admin.Controllers
{
    public class QUYENController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Admin/QUYEN
        public ActionResult Index()
        {
            var qUYENs = db.QUYENs.Include(q => q.PHANQUYEN);
            return View(qUYENs.ToList());
        }

        // GET: Admin/QUYEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUYEN);
        }

        // GET: Admin/QUYEN/Create
        public ActionResult Create()
        {
            ViewBag.TENQUYEN = new SelectList(db.PHANQUYENs, "TENQUYEN", "TENQUYEN");
            return View();
        }

        // POST: Admin/QUYEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_QUYEN,TENQUYEN")] QUYEN qUYEN)
        {
            if (ModelState.IsValid)
            {
                db.QUYENs.Add(qUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TENQUYEN = new SelectList(db.PHANQUYENs, "TENQUYEN", "TENQUYEN", qUYEN.TENQUYEN);
            return View(qUYEN);
        }

        // GET: Admin/QUYEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.TENQUYEN = new SelectList(db.PHANQUYENs, "TENQUYEN", "TENQUYEN", qUYEN.TENQUYEN);
            return View(qUYEN);
        }

        // POST: Admin/QUYEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_QUYEN,TENQUYEN")] QUYEN qUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TENQUYEN = new SelectList(db.PHANQUYENs, "TENQUYEN", "TENQUYEN", qUYEN.TENQUYEN);
            return View(qUYEN);
        }

        // GET: Admin/QUYEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUYEN);
        }

        // POST: Admin/QUYEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUYEN qUYEN = db.QUYENs.Find(id);
            db.QUYENs.Remove(qUYEN);
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
