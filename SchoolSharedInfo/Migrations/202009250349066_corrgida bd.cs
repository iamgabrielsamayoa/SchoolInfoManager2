namespace SchoolSharedInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrgidabd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FechaInscripcion", "CursoID");
            AddForeignKey("dbo.FechaInscripcion", "CursoID", "dbo.Curso", "CursoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FechaInscripcion", "CursoID", "dbo.Curso");
            DropIndex("dbo.FechaInscripcion", new[] { "CursoID" });
        }
    }
}
