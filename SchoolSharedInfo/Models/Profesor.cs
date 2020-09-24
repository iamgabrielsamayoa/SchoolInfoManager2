using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSharedInfo.Models
{
    public class Profesor
    {
        //public Profesor()
        //{
        //    Cursos = new List<Curso>();
        //}

        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual Profesor Profesores { get; set; }
        

    }
}
