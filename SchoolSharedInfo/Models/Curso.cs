using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SchoolSharedInfo.Models
{
    public class Curso
    {
        
        public int CursoId { get; set; }

        public string NombreCurso { get; set; }

        public int Creditos { get; set; }

        public int ProfesorId { get; set; }

        public Alumno alumnos { get; set; }
        public virtual Curso Cursos { get; set; }
        public virtual Alumno Alumno { get; set; }
    }

}
