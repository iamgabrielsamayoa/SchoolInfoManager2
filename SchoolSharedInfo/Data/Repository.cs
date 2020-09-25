using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSharedInfo.Data
{
    public class Repository
    {
        private Context _context = null;

        public Repository(Context context)
        {
            _context = context;
        }

        public IList<Alumno> GetAlumnos()
        {
            return _context.Alumnos
                .OrderBy(r => r.Nombre)
                .ToList();
        }

        public IList<Curso> GetCursos()
        {
            return _context.Cursos
                .OrderBy(r => r.NombreCurso)
                .ToList();
        }
    }
}
