//namespace Portal.Migrations
//{
//  using System;
//  using System.Data.Entity.Migrations;

//  public partial class inicial
//  {
//    //      public override void Up()
//    //      {
//    //          CreateTable(
//    //              "dbo.Alunoes",
//    //              c => new
//    //                  {
//    //                      codaluno = c.Int(nullable: false, identity: true),
//    //                      matricula = c.String(),
//    //                      nome = c.String(nullable: false),
//    //                      cpf = c.String(nullable: false, maxLength: 11),
//    //                      email = c.String(nullable: false),
//    //                      dataNascimento = c.DateTime(nullable: false),
//    //                      password = c.String(nullable: false, maxLength: 100),
//    //                      curso_codcurso = c.Int(),
//    //                  })
//    //              .PrimaryKey(t => t.codaluno)
//    //              .ForeignKey("dbo.Cursoes", t => t.curso_codcurso)
//    //              .Index(t => t.curso_codcurso);

//    //          CreateTable(
//    //              "dbo.Cursoes",
//    //              c => new
//    //                  {
//    //                      codcurso = c.Int(nullable: false, identity: true),
//    //                      nome = c.String(nullable: false),
//    //                  })
//    //              .PrimaryKey(t => t.codcurso);
//    //                CreateTable(
//    //                "dbo.CursosDisciplinas",
//    //                c => new
//    //                {
//    //                codcurso = c.Int(nullable: false),
//    //                coddisciplina = c.Int(nullable: false),
//    //                })
//    //                .PrimaryKey(t => new { t.coddisciplina, t.codcurso })
//    //                .ForeignKey("dbo.Disciplinas", t => t.coddisciplina, cascadeDelete: true)
//    //                .ForeignKey("dbo.Cursoes", t => t.codcurso, cascadeDelete: true)
//    //                .Index(t => t.coddisciplina)
//    //                .Index(t => t.codcurso);
//    //    CreateTable(
//    //              "dbo.Disciplinas",
//    //              c => new
//    //                  {
//    //                      coddisciplina = c.Int(nullable: false, identity: true),
//    //                      nome = c.String(nullable: false),
//    //                      Disciplina_coddisciplina = c.Int(),
//    //                      professor_codprofessor = c.Int(),
//    //                      Curso_codcurso = c.Int(),
//    //                  })
//    //              .PrimaryKey(t => t.coddisciplina)
//    //              .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina)
//    //              .ForeignKey("dbo.Professors", t => t.professor_codprofessor)
//    //              .ForeignKey("dbo.Cursoes", t => t.Curso_codcurso)
//    //              .Index(t => t.Disciplina_coddisciplina)
//    //              .Index(t => t.professor_codprofessor)
//    //              .Index(t => t.Curso_codcurso);

//    //          CreateTable(
//    //              "dbo.Professors",
//    //              c => new
//    //                  {
//    //                      codprofessor = c.Int(nullable: false, identity: true),
//    //                      matricula = c.String(),
//    //                      nome = c.String(nullable: false),
//    //                      cpf = c.String(nullable: false, maxLength: 11),
//    //                      email = c.String(nullable: false),
//    //                      dataNascimento = c.DateTime(nullable: false),
//    //                      password = c.String(nullable: false, maxLength: 100),
//    //                  })
//    //              .PrimaryKey(t => t.codprofessor);

//    //          CreateTable(
//    //              "dbo.Trabalhoes",
//    //              c => new
//    //                  {
//    //                      codtrabalho = c.Int(nullable: false, identity: true),
//    //                      nome = c.String(nullable: false),
//    //                      DataPublicacao = c.DateTime(nullable: false),
//    //                      DataLimite = c.DateTime(nullable: false),
//    //                      disciplina_coddisciplina = c.Int(),
//    //                  })
//    //              .PrimaryKey(t => t.codtrabalho)
//    //              .ForeignKey("dbo.Disciplinas", t => t.disciplina_coddisciplina)
//    //              .Index(t => t.disciplina_coddisciplina);

//    //          CreateTable(
//    //              "dbo.DisciplinaAlunoes",
//    //              c => new
//    //                  {
//    //                      Disciplina_coddisciplina = c.Int(nullable: false),
//    //                      Aluno_codaluno = c.Int(nullable: false),
//    //                  })
//    //              .PrimaryKey(t => new { t.Disciplina_coddisciplina, t.Aluno_codaluno })
//    //              .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina, cascadeDelete: true)
//    //              .ForeignKey("dbo.Alunoes", t => t.Aluno_codaluno, cascadeDelete: true)
//    //              .Index(t => t.Disciplina_coddisciplina)
//    //              .Index(t => t.Aluno_codaluno);
//    //         //CreateTable(
//    //         //   "dbo.CursosDisciplinas",
//    //         //   c => new
//    //         //   {
//    //         //   codcurso = c.Int(nullable: false),
//    //         //   coddisciplina = c.Int(nullable: false),
//    //         //   })
//    //         //   .PrimaryKey(t => new { t.coddisciplina, t.codcurso })
//    //         //   .ForeignKey("dbo.Disciplinas", t => t.coddisciplina, cascadeDelete: true)
//    //         //   .ForeignKey("dbo.Cursoes", t => t.codcurso, cascadeDelete: true)
//    //         //   .Index(t => t.coddisciplina)
//    //         //   .Index(t => t.codcurso);


//    //}

//    //      public override void Down()
//    //      {
//    //          DropForeignKey("dbo.Trabalhoes", "disciplina_coddisciplina", "dbo.Disciplinas");
//    //          DropForeignKey("dbo.Alunoes", "curso_codcurso", "dbo.Cursoes");
//    //          DropForeignKey("dbo.Disciplinas", "Curso_codcurso", "dbo.Cursoes");
//    //          DropForeignKey("dbo.Disciplinas", "professor_codprofessor", "dbo.Professors");
//    //          DropForeignKey("dbo.Disciplinas", "Disciplina_coddisciplina", "dbo.Disciplinas");
//    //          DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_codaluno", "dbo.Alunoes");
//    //          DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_coddisciplina", "dbo.Disciplinas");
//    //          DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_codaluno" });
//    //          DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_coddisciplina" });
//    //          DropIndex("dbo.Trabalhoes", new[] { "disciplina_coddisciplina" });
//    //          DropIndex("dbo.Disciplinas", new[] { "Curso_codcurso" });
//    //          DropIndex("dbo.Disciplinas", new[] { "professor_codprofessor" });
//    //          DropIndex("dbo.Disciplinas", new[] { "Disciplina_coddisciplina" });
//    //          DropIndex("dbo.Alunoes", new[] { "curso_codcurso" });
//    //          DropTable("dbo.DisciplinaAlunoes");
//    //          DropTable("dbo.Trabalhoes");
//    //          DropTable("dbo.Professors");
//    //          DropTable("dbo.Disciplinas");
//    //          DropTable("dbo.Cursoes");
//    //          DropTable("dbo.Alunoes");
//    //      }
//  }
//}
