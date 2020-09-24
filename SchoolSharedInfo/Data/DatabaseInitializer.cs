using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSharedInfo.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)


        {
            var Alumnos = new List<Alumno>
            {
            new Alumno{Nombre="Luis Suarez",Email="lSuarez@LiceoGuate.com",Carne=("0905-20-9231")},
            new Alumno{Nombre="Brayan Rodriguez",Email="brodriguez@LiceoGuate.com",Carne=("0905-20-9232")},
            new Alumno{Nombre="Fernando Campos",Email="fcampos@LiceoGuate.com",Carne=("0905-20-9233")},
            new Alumno{Nombre="Jefferson Rueda",Email="jrueda@LiceoGuate.com",Carne=("0905-20-9234")},
             };

            Alumnos.ForEach(s => context.Alumnos.Add(s));
            context.SaveChanges();
            var Cursos = new List<Curso>
            {
            new Curso{CursoId=1050,NombreCurso="Matematica",Creditos=3,ProfesorId=1},
            new Curso{CursoId=1051,NombreCurso="Idioma Espanol",Creditos=3,ProfesorId=2},
            new Curso{CursoId=1052,NombreCurso="Ciencias Naturales",Creditos=3,ProfesorId=3},
            new Curso{CursoId=1053,NombreCurso="Estudios Sociales",Creditos=3,ProfesorId=1},
            new Curso{CursoId=1054,NombreCurso="Ingles",Creditos=3,ProfesorId=2},
            };
            Cursos.ForEach(s => context.Cursos.Add(s));
            context.SaveChanges();

            var Profesores = new List<Profesor>
            {
            new Profesor{Id=1,Nombre="Mario Salazar",},
            new Profesor{Id=2,Nombre="Regina Florian",},
            new Profesor{Id=3,Nombre="Rudy Rivas",},
            };
            Profesores.ForEach(s => context.Profesor.Add(s));
            context.SaveChanges();


            var FechaInscripcion = new List<FechaInscripcion>
            {
            new FechaInscripcion{FechaInscripcionID=1, CursoID = 1050, AlumnoID = 1,},
            new FechaInscripcion{FechaInscripcionID=2, CursoID = 1051, AlumnoID = 2,},
            new FechaInscripcion{FechaInscripcionID=3, CursoID = 1052, AlumnoID = 3,},
            new FechaInscripcion{FechaInscripcionID=4, CursoID = 1053, AlumnoID = 4,},
            new FechaInscripcion{FechaInscripcionID=5, CursoID = 1054, AlumnoID = 5,},
            };
            FechaInscripcion.ForEach(s => context.FechaInscripcion.Add(s));
            context.SaveChanges();
        }

    }
}
