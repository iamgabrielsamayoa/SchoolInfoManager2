using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSharedInfo.Models
{
    public class FechaInscripcion
    {

        public int FechaInscripcionID { get; set; }
        public DateTime FechaInscripcionInicial { get; set; }

        //Esto lo modifico a nombre curso va?
        public int CursoID { get; set; }
        public int AlumnoID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha en que culmina el semestre")]
        public DateTime FechaFinalSemestre { get; set; }

        public Curso Curso { get; set; }
        public Alumno  Alumno {get; set;}

        public virtual ICollection<FechaInscripcion> FechaInscripcions { get; set; }
    }
}
