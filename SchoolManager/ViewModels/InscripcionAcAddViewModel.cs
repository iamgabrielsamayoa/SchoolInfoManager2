using SchoolSharedInfo.Data;
using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.ViewModels
{
    public class InscripcionAcAddViewModel
    {

        public IEnumerable<Alumno> Alumnos { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }

        public IEnumerable<FechaInscripcion> Inscripciones { get; set; }

        public Alumno Alumno { get; set; }

        public Curso Curso { get; set; }

        public FechaInscripcion fechaInscripcion { get; set; }

        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }

        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public FechaInscripcion Asignar { get; set; }

        public SelectList AlumnosSelectListItems { get; set; }

        public SelectList CursosSelectListItems { get; set; }

        public SelectList FechaInscripcionselectListItems { get; set; }

        public SelectList ProfesoresselectListItems { get; set; }

        public virtual void Init(Repository repository)
        {
                 AlumnosSelectListItems = new SelectList(
                repository.GetAlumnos(), "Id", "Nombre"
                );
        }
        public virtual void Init(Repository repository, String opcion)
        {
            if (opcion.ToLower() == "cursos")
            {
                CursosSelectListItems = new SelectList(
                    repository.GetCursos(), "CursoId", "NombreCurso"
                    );
            }

            else if (opcion.ToLower() == "fecha" || opcion.Contains("fecha"))
            {
                FechaInscripcionselectListItems = new SelectList(
                    repository.GetInscripciones(), "FechaInscripcionInicial", "FechaFinalSemestre"
                    );
            }

            else if (opcion.ToLower() == "profesor")
            {
                ProfesoresselectListItems = new SelectList(
                    repository.GetProfesores(), "Id", "Nombre"
                    );
            }
        }
        

    }
}