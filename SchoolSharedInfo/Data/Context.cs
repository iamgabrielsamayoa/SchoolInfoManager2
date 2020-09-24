using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolSharedInfo.Data
{
    public class Context : DbContext
    {
        //Conn to DB
        public Context() : base("Context")
        {
        }


        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<FechaInscripcion> FechaInscripcion { get; set; }

        public DbSet<Profesor> Profesor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
        }
    }
}
