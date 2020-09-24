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

            return View(db.FechaInscripcion.ToList());
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
            db.Alumnos.ToList();


            return View();
        }

        

        // POST: Inscripcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FechaInscripcionID,CursoID,AlumnoID")] FechaInscripcion fechaInscripcion, int? SelectedDepartment)
        {
            //Repository repository = new Repository(db);
            //var AlumnosList = repository.GetAlumnos();

            //var ViewModel = new NewInscripcion
            //{
            //    Alumnos = AlumnosList
            //};

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "Gestion", Value = "1" });
            lst.Add(new SelectListItem() { Text = "Colegio", Value = "2" });
            lst.Add(new SelectListItem() { Text = "Estado", Value = "3" });
            lst.Add(new SelectListItem() { Text = "Pais", Value = "4" });

            ViewBag.Opciones = lst;

            if (ModelState.IsValid)
            {
                db.FechaInscripcion.Add(fechaInscripcion);
                db.SaveChanges();
                //return View(ViewModel);
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

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var AlumnosQuery = from d in db.Alumnos
                                   orderby d.Id
                                   select d;
            ViewBag.DepartmentID = new SelectList(AlumnosQuery, "AlumnoID", "Nombre", selectedDepartment);
        }
    }
}
