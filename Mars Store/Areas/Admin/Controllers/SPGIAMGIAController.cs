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
    public class SPGIAMGIAController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Admin/SPGIAMGIA
        public ActionResult Index()
        {
            var sPGIAMGIAs = db.SPGIAMGIAs.Include(s => s.SANPHAM);
            return View(sPGIAMGIAs.ToList());
        }

        // GET: Admin/SPGIAMGIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPGIAMGIA sPGIAMGIA = db.SPGIAMGIAs.Find(id);
            if (sPGIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(sPGIAMGIA);
        }

        // GET: Admin/SPGIAMGIA/Create
        public ActionResult Create()
        {
            ViewBag.ID_SP = new SelectList(db.SANPHAMs, "ID_SP", "tensanpham");
            return View();
        }

        // POST: Admin/SPGIAMGIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_KM,ID_SP,soluong,giaht,ngayban")] SPGIAMGIA sPGIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.SPGIAMGIAs.Add(sPGIAMGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SP = new SelectList(db.SANPHAMs, "ID_SP", "tensanpham", sPGIAMGIA.ID_SP);
            return View(sPGIAMGIA);
        }

        // GET: Admin/SPGIAMGIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPGIAMGIA sPGIAMGIA = db.SPGIAMGIAs.Find(id);
            if (sPGIAMGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SP = new SelectList(db.SANPHAMs, "ID_SP", "tensanpham", sPGIAMGIA.ID_SP);
            return View(sPGIAMGIA);
        }

        // POST: Admin/SPGIAMGIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_KM,ID_SP,soluong,giaht,ngayban")] SPGIAMGIA sPGIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPGIAMGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SP = new SelectList(db.SANPHAMs, "ID_SP", "tensanpham", sPGIAMGIA.ID_SP);
            return View(sPGIAMGIA);
        }

        // GET: Admin/SPGIAMGIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPGIAMGIA sPGIAMGIA = db.SPGIAMGIAs.Find(id);
            if (sPGIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(sPGIAMGIA);
        }

        // POST: Admin/SPGIAMGIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPGIAMGIA sPGIAMGIA = db.SPGIAMGIAs.Find(id);
            db.SPGIAMGIAs.Remove(sPGIAMGIA);
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
