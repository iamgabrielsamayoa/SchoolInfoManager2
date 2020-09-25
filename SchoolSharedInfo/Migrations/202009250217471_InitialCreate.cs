namespace SchoolSharedInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Email = c.String(),
                        Carne = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FechaInscripcion",
                c => new
                    {
                        FechaInscripcionID = c.Int(nullable: false, identity: true),
                        FechaInscripcionInicial = c.DateTime(nullable: false),
                        CursoID = c.Int(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        FechaFinalSemestre = c.DateTime(nullable: false),
                        FechaInscripcion_FechaInscripcionID = c.Int(),
                    })
                .PrimaryKey(t => t.FechaInscripcionID)
                .ForeignKey("dbo.FechaInscripcion", t => t.FechaInscripcion_FechaInscripcionID)
                .ForeignKey("dbo.Alumno", t => t.AlumnoID, cascadeDelete: true)
                .Index(t => t.AlumnoID)
                .Index(t => t.FechaInscripcion_FechaInscripcionID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        NombreCurso = c.String(),
                        Creditos = c.Int(nullable: false),
                        ProfesorId = c.Int(nullable: false),
                        Alumno_Id = c.Int(),
                        alumnos_Id = c.Int(),
                        Cursos_CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Alumno", t => t.Alumno_Id)
                .ForeignKey("dbo.Alumno", t => t.alumnos_Id)
                .ForeignKey("dbo.Curso", t => t.Cursos_CursoId)
                .Index(t => t.Alumno_Id)
                .Index(t => t.alumnos_Id)
                .Index(t => t.Cursos_CursoId);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Profesores_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profesor", t => t.Profesores_Id)
                .Index(t => t.Profesores_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profesor", "Profesores_Id", "dbo.Profesor");
            DropForeignKey("dbo.Curso", "Cursos_CursoId", "dbo.Curso");
            DropForeignKey("dbo.Curso", "alumnos_Id", "dbo.Alumno");
            DropForeignKey("dbo.Curso", "Alumno_Id", "dbo.Alumno");
            DropForeignKey("dbo.FechaInscripcion", "AlumnoID", "dbo.Alumno");
            DropForeignKey("dbo.FechaInscripcion", "FechaInscripcion_FechaInscripcionID", "dbo.FechaInscripcion");
            DropIndex("dbo.Profesor", new[] { "Profesores_Id" });
            DropIndex("dbo.Curso", new[] { "Cursos_CursoId" });
            DropIndex("dbo.Curso", new[] { "alumnos_Id" });
            DropIndex("dbo.Curso", new[] { "Alumno_Id" });
            DropIndex("dbo.FechaInscripcion", new[] { "FechaInscripcion_FechaInscripcionID" });
            DropIndex("dbo.FechaInscripcion", new[] { "AlumnoID" });
            DropTable("dbo.Profesor");
            DropTable("dbo.Curso");
            DropTable("dbo.FechaInscripcion");
            DropTable("dbo.Alumno");
        }
    }
}
