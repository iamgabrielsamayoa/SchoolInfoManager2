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

        public IList<FechaInscripcion> GetInscripciones()
        {
            return _context.FechaInscripcion
                .OrderBy(r => r.FechaInscripcionInicial)
                .ToList();
        }

        public IList<Profesor> GetProfesores()
        {
            return _context.Profesor
                .OrderBy(r => r.Nombre)
                .ToList();
        }

        //public override FechaInscripcion Get(int id, bool includeRelatedEntities = true)
        //{
        //    var comicBooks = Context..AsQueryable();

        //    if (includeRelatedEntities)
        //    {
        //        comicBooks = comicBooks
        //            .Include(cb => cb.Series)
        //            .Include(cb => cb.Artists.Select(a => a.Artist))
        //            .Include(cb => cb.Artists.Select(a => a.Role));
        //    }

        //    return comicBooks
        //        .Where(cb => cb.Id == id)
        //        .SingleOrDefault();
        //}
    }
}
