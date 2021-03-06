﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SakalliTicaret.Core.Model;
using SakalliTicaret.Core.Model.Entity;

namespace SakalliTicaret.UI.WEB.Areas.Panel.Controllers
{
    public class CategoriesController : AdminControlerBase
    {
        private SakalliTicaretDb db = new SakalliTicaretDb();

        // GET: Panel/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Panel/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Panel/Categories/Create
        public ActionResult Create()
        {
            ViewBag.UstKategoriList = db.Categories.Where(x => x.ParentId == null).ToList();
            return View();
        }

        // POST: Panel/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParentId,Name,IsActive,CreateDateTime,CreateUserID,UpdateDateTime,UpdateUserID")] Category category)
        {
           
            var User = Session["AdminLoginUser"] as User;
            category.CreateDateTime= DateTime.Now;
            category.CreateUserID = User.ID;
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UstKategoriList = db.Categories.Where(x => x.ParentId == null).ToList();
            return View(category);
        }

        // GET: Panel/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.UstKategoriList = db.Categories.Where(x => x.ParentId == null).ToList();
            return View(category);
        }

        // POST: Panel/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParentId,Name,IsActive,CreateDateTime,CreateUserID,UpdateDateTime,UpdateUserID")] Category category)
        {
            var User = Session["AdminLoginUser"] as User;
            category.UpdateDateTime = DateTime.Now;
            category.UpdateUserID = User.ID;
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Panel/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Panel/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
