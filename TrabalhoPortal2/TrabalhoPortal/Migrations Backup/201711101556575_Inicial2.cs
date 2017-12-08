namespace Portal.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class Inicial2
  {
    //public override void Up()
    //{
    //  DropForeignKey("dbo.Disciplinas", "Disciplina_coddisciplina", "dbo.Disciplinas");
    //  DropForeignKey("dbo.Disciplinas", "Curso_codcurso", "dbo.Cursoes");
    //  DropIndex("dbo.Disciplinas", new[] { "Disciplina_coddisciplina" });
    //  DropIndex("dbo.Disciplinas", new[] { "Curso_codcurso" });
    //  CreateTable(
    //      "dbo.DisciplinaCursoes",
    //      c => new
    //      {
    //        Disciplina_coddisciplina = c.Int(nullable: false),
    //        Curso_codcurso = c.Int(nullable: false),
    //      })
    //      .PrimaryKey(t => new { t.Disciplina_coddisciplina, t.Curso_codcurso })
    //      .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina, cascadeDelete: true)
    //      .ForeignKey("dbo.Cursoes", t => t.Curso_codcurso, cascadeDelete: true)
    //      .Index(t => t.Disciplina_coddisciplina)
    //      .Index(t => t.Curso_codcurso);

    //  DropColumn("dbo.Disciplinas", "Disciplina_coddisciplina");
    //  DropColumn("dbo.Disciplinas", "Curso_codcurso");
    //}

    //public override void Down()
    //{
    //  AddColumn("dbo.Disciplinas", "Curso_codcurso", c => c.Int());
    //  AddColumn("dbo.Disciplinas", "Disciplina_coddisciplina", c => c.Int());
    //  DropForeignKey("dbo.DisciplinaCursoes", "Curso_codcurso", "dbo.Cursoes");
    //  DropForeignKey("dbo.DisciplinaCursoes", "Disciplina_coddisciplina", "dbo.Disciplinas");
    //  DropIndex("dbo.DisciplinaCursoes", new[] { "Curso_codcurso" });
    //  DropIndex("dbo.DisciplinaCursoes", new[] { "Disciplina_coddisciplina" });
    //  DropTable("dbo.DisciplinaCursoes");
    //  CreateIndex("dbo.Disciplinas", "Curso_codcurso");
    //  CreateIndex("dbo.Disciplinas", "Disciplina_coddisciplina");
    //  AddForeignKey("dbo.Disciplinas", "Curso_codcurso", "dbo.Cursoes", "codcurso");
    //  AddForeignKey("dbo.Disciplinas", "Disciplina_coddisciplina", "dbo.Disciplinas", "coddisciplina");
    //}
  }
}
