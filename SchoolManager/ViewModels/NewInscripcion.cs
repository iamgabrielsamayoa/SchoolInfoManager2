using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.ViewModels
{
    public class NewInscripcion
    {
        public IEnumerable<Alumno> Alumnos { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }
        public FechaInscripcion Asignar { get; set; }
    }
}