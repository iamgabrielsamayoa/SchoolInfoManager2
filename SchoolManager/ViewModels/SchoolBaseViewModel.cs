using SchoolSharedInfo.Data;
using SchoolSharedInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.ViewModels
{
    public class SchoolBaseViewModel
    {
        public FechaInscripcion FechaInscripcion { get; set; }

        public SelectList AlumnosSelectListItems { get; set; }

        public virtual void Init(Repository repository)
        {
            repository.GetAlumnos();
        }
    }
}