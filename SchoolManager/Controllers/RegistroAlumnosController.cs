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

        //Details 
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Repository repository = new Repository(db);
            var AlumnosList = repository.GetAlumnos();
            var CursosList = repository.GetCursos();
            var InscripcionesList = repository.GetInscripciones();

            var ViewModel = new InscripcionAcAddViewModel
            {
                Alumnos = AlumnosList,
                Cursos = CursosList,
                Inscripciones = InscripcionesList
            };
            ViewModel.Init(repository);
            ViewModel.Init(repository, "cursos");
            ViewModel.Init(repository, "fecha");

            

            return View(ViewModel);
        }

        // GET: 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Repository repository = new Repository(db);
            var Inscritos = repository.GetInscripciones();
            return View();

            if (Inscritos == null)
            {
                return HttpNotFound();
            }

            Inscritos = db.FechaInscripcion.OrderBy(a => a.AlumnoID).ToList();

            return View(db.FechaInscripcion.)
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnosRegistro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST:
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: 
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST:
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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