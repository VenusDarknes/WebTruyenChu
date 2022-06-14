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
    public class chuongsController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: chuongs
        public ActionResult Index()
        {
            var chuongs = db.chuongs.Include(c => c.truyen);
            return View(chuongs.ToList());
        }

        // GET: chuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuong chuong = db.chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            return View(chuong);
        }

        // GET: chuongs/Create
        public ActionResult Create()
        {
            ViewBag.matruyen = new SelectList(db.truyens, "matruyen", "tentruyen");
            return View();
        }

        // POST: chuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "machuong,matruyen,tenchuong,noidungchuong,ngaydangchuong")] chuong chuong)
        {
            if (ModelState.IsValid)
            {
                db.chuongs.Add(chuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matruyen = new SelectList(db.truyens, "matruyen", "tentruyen", chuong.matruyen);
            return View(chuong);
        }

        // GET: chuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuong chuong = db.chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.matruyen = new SelectList(db.truyens, "matruyen", "tentruyen", chuong.matruyen);
            return View(chuong);
        }

        // POST: chuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "machuong,matruyen,tenchuong,noidungchuong,ngaydangchuong")] chuong chuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matruyen = new SelectList(db.truyens, "matruyen", "tentruyen", chuong.matruyen);
            return View(chuong);
        }

        // GET: chuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuong chuong = db.chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            return View(chuong);
        }

        // POST: chuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chuong chuong = db.chuongs.Find(id);
            db.chuongs.Remove(chuong);
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
