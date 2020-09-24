using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSharedInfo.Models
{
    public class Alumno
    {
        public Alumno()
        {
            FechaInscripcions = new List<FechaInscripcion>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }


        public string Email { get; set; }

        public string Carne { get; set; }

        public virtual ICollection<FechaInscripcion> FechaInscripcions { get; set; }

    }
}
