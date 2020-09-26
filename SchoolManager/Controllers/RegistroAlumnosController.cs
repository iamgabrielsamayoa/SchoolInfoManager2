using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManager.ViewModels;
using SchoolSharedInfo.Data;
using SchoolSharedInfo.Models;

namespace SchoolManager.Controllers
{
    public class RegistroAlumnosController : Controller
    {
        private Context db = new Context();
        

        // GET: RegistroAlumnos
        public ActionResult Index()
        {
            return View(db.FechaInscripcion.Include(a => a.Alumno)
                .Include(a => a.Curso));
        }

        
        // GET: Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //FechaInscripcion fechaInscripcion = db.FechaInscripcion.Find(id);

            FechaInscripcion fechaInscripcion1 = db.FechaInscripcion.Include(a => a.Alumno)
                  .Include(q => q.Curso)
                  .Where(a => a.FechaInscripcionID == id).SingleOrDefault();

            if (fechaInscripcion1 == null)
            {
                return HttpNotFound();
            }

            return View(fechaInscripcion1);

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Include(a => a.Alumno)
                  .Include(q => q.Curso)
                  .Where(a => a.FechaInscripcionID == id).SingleOrDefault();
            if (fechaInscripcion == null)
            {
                return HttpNotFound();
            }
            return View(fechaInscripcion);
        }

        // POST: Inscripcion/Edit/5
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

        // GET: 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Include(a => a.Alumno)
                  .Include(q => q.Curso)
                  .Where(a => a.FechaInscripcionID == id).SingleOrDefault();
            if (fechaInscripcion == null)
            {
                return HttpNotFound();
            }
            return View(fechaInscripcion);
        }

        // POST: Inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            FechaInscripcion fechaInscripcion = db.FechaInscripcion.Include(a => a.Alumno)
                    .Include(q => q.Curso)
                    .Where(a => a.FechaInscripcionID == id).SingleOrDefault();


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