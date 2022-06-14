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
    public class truyensController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: truyens
        public ActionResult Index()
        {
            var truyens = db.truyens.Include(t => t.theloai);
            return View(truyens.ToList());
        }
        public ActionResult TruyenTheLoai(int? matheloai)
        {
            HomeModel list = new HomeModel();
            if (matheloai == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list.theloais = db.theloais.ToList();
            list.chuongs = db.chuongs.ToList();
            list.truyens = db.truyens.Where(n => n.matheloai == matheloai).ToList();
            if (list.truyens.ToList().Count() == 0)
            {
                return HttpNotFound();
            }

            return View(list);
        }
        public ActionResult TruyenDetails(int? matruyen)
        {
            HomeModel list = new HomeModel();
            if (matruyen == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list.theloais = db.theloais.ToList();
            list.chuongs = db.chuongs.ToList();
            list.truyens = db.truyens.Where(n => n.matruyen == matruyen).ToList();
            if (list.truyens.ToList().Count() == 0)
            {
                return HttpNotFound();
            }

            return View(list);
        }

        // GET: truyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // GET: truyens/Create
        public ActionResult Create()
        {
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai");
            return View();
        }

        // POST: truyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matruyen,matheloai,tentruyen,hinh,tacgia,mota,ngaydangtruyen")] truyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.truyens.Add(truyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // GET: truyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // POST: truyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matruyen,matheloai,tentruyen,hinh,tacgia,mota,ngaydangtruyen")] truyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // GET: truyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // POST: truyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            truyen truyen = db.truyens.Find(id);
            db.truyens.Remove(truyen);
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
