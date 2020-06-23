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
    public class PHANQUYENController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Admin/PHANQUYEN
        public ActionResult Index()
        {
            var pHANQUYENs = db.PHANQUYENs.Include(p => p.TAIKHOAN);
            return View(pHANQUYENs.ToList());
        }

        // GET: Admin/PHANQUYEN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYEN/Create
        public ActionResult Create()
        {
            ViewBag.ID_TK = new SelectList(db.TAIKHOANs, "ID_TK", "username");
            return View();
        }

        // POST: Admin/PHANQUYEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TENQUYEN,ID_TK")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PHANQUYENs.Add(pHANQUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TK = new SelectList(db.TAIKHOANs, "ID_TK", "username", pHANQUYEN.ID_TK);
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYEN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TK = new SelectList(db.TAIKHOANs, "ID_TK", "username", pHANQUYEN.ID_TK);
            return View(pHANQUYEN);
        }

        // POST: Admin/PHANQUYEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TENQUYEN,ID_TK")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANQUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TK = new SelectList(db.TAIKHOANs, "ID_TK", "username", pHANQUYEN.ID_TK);
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYEN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // POST: Admin/PHANQUYEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            db.PHANQUYENs.Remove(pHANQUYEN);
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
