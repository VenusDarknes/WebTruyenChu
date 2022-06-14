﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTruyenChu.Models;

namespace WebTruyenChu.Controllers
{
    public class theloaisController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: theloais
        public ActionResult Index()
        {
            return View(db.theloais.ToList());
        }
        // GET: theloais/alllist
        public ActionResult Gettheloais(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            theloai theloai = db.theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        //Code cac chuc nang 
        // GET: theloais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            theloai theloai = db.theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // GET: theloais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: theloais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matheloai,tentheloai,tenurl")] theloai theloai)
        {
            if (ModelState.IsValid)
            {
                db.theloais.Add(theloai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theloai);
        }

        // GET: theloais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            theloai theloai = db.theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: theloais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matheloai,tentheloai,tenurl")] theloai theloai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theloai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloai);
        }

        // GET: theloais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            theloai theloai = db.theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: theloais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            theloai theloai = db.theloais.Find(id);
            db.theloais.Remove(theloai);
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
