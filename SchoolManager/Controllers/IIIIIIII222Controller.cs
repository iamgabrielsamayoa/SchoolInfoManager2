﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolSharedInfo.Data;
using SchoolSharedInfo.Models;

namespace SchoolManager.Controllers
{
    public class IIIIIIII222Controller : Controller
    {
        private Context db = new Context();

        // GET: IIIIIIII222
        public ActionResult Index()
        {
            return View(db.FechaInscripcion.ToList());
        }

        // GET: IIIIIIII222/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Find(id);
            if (fechaInscripcion == null)
            {
                return HttpNotFound();
            }
            return View(fechaInscripcion);
        }

        // GET: IIIIIIII222/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IIIIIIII222/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FechaInscripcionID,CursoID,AlumnoID")] FechaInscripcion fechaInscripcion)
        {
            if (ModelState.IsValid)
            {
                db.FechaInscripcion.Add(fechaInscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fechaInscripcion);
        }

        // GET: IIIIIIII222/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Find(id);
            if (fechaInscripcion == null)
            {
                return HttpNotFound();
            }
            return View(fechaInscripcion);
        }

        // POST: IIIIIIII222/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FechaInscripcionID,CursoID,AlumnoID")] FechaInscripcion fechaInscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fechaInscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fechaInscripcion);
        }

        // GET: IIIIIIII222/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Find(id);
            if (fechaInscripcion == null)
            {
                return HttpNotFound();
            }
            return View(fechaInscripcion);
        }

        // POST: IIIIIIII222/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Find(id);
            db.FechaInscripcion.Remove(fechaInscripcion);
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
