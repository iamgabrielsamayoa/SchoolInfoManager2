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
    public class InscripcionController : Controller
    {
        private Context db = new Context();

        // GET: Inscripcion
        public ActionResult Index()
        {
            // en teoria
            // SELECT * FROM Fechainscripcion join on Fechainscripcion.CursoId = Curso.Id join on
            // Fechainscripcoion.Alumnoid = Alumno.Id
            return View(db.FechaInscripcion
                .Include(a => a.Curso)
                .Include(a => a.Alumno)
                .ToList());
        }

        // GET: Inscripcion/Details/5
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

        // GET: Inscripcion/Create
        public ActionResult Create()
        {
            Repository repository = new Repository(db);
            var AlumnosList = repository.GetAlumnos();
            var CursosList = repository.GetCursos();

            var ViewModel = new InscripcionAcAddViewModel
            {
                Alumnos = AlumnosList,
                Cursos = CursosList
            };
            ViewModel.Init(repository);
            //El String vacio lo use para elegir opcion 2 que seria cursos
            ViewModel.Init(repository, "");
            return View(ViewModel);
        }



        // POST: Inscripcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InscripcionAcAddViewModel fechaInscripcion)
        {
            //fechaInscripcion.Asignar.FechaInscripcionInicial = DateTime.Today;
            if (ModelState.IsValid)
            {
                var asignacion = fechaInscripcion.Asignar;
                asignacion.FechaInscripcionInicial = DateTime.Now;

                db.FechaInscripcion.Add(asignacion);
                db.SaveChanges();
              return RedirectToAction("Index");
            }


            return View(fechaInscripcion);
        }

        // GET: Inscripcion/Edit/5
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

        // GET: Inscripcion/Delete/5
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

        // POST: Inscripcion/Delete/5
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
