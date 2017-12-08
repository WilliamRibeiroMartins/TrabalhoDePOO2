namespace TrabalhoPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class William : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        codaluno = c.Int(nullable: false, identity: true),
                        matricula = c.String(),
                        nome = c.String(nullable: false),
                        cpf = c.String(nullable: false, maxLength: 11),
                        email = c.String(nullable: false),
                        dataNascimento = c.DateTime(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        curso_codcurso = c.Int(),
                    })
                .PrimaryKey(t => t.codaluno)
                .ForeignKey("dbo.Cursos", t => t.curso_codcurso)
                .Index(t => t.curso_codcurso);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        codcurso = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.codcurso);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        coddisciplina = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        professor_codprofessor = c.Int(),
                    })
                .PrimaryKey(t => t.coddisciplina)
                .ForeignKey("dbo.Professores", t => t.professor_codprofessor)
                .Index(t => t.professor_codprofessor);
            
            CreateTable(
                "dbo.Professores",
                c => new
                    {
                        codprofessor = c.Int(nullable: false, identity: true),
                        matricula = c.String(),
                        nome = c.String(nullable: false),
                        cpf = c.String(nullable: false, maxLength: 11),
                        email = c.String(nullable: false),
                        dataNascimento = c.DateTime(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.codprofessor);
            
            CreateTable(
                "dbo.Trabalhos",
                c => new
                    {
                        codtrabalho = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        DataLimite = c.DateTime(nullable: false),
                        disciplina_coddisciplina = c.Int(),
                        professor_codprofessor = c.Int(),
                    })
                .PrimaryKey(t => t.codtrabalho)
                .ForeignKey("dbo.Disciplinas", t => t.disciplina_coddisciplina)
                .ForeignKey("dbo.Professores", t => t.professor_codprofessor)
                .Index(t => t.disciplina_coddisciplina)
                .Index(t => t.professor_codprofessor);
            
            CreateTable(
                "dbo.DisciplinaAlunoes",
                c => new
                    {
                        Disciplina_coddisciplina = c.Int(nullable: false),
                        Aluno_codaluno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_coddisciplina, t.Aluno_codaluno })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina, cascadeDelete: true)
                .ForeignKey("dbo.Alunos", t => t.Aluno_codaluno, cascadeDelete: true)
                .Index(t => t.Disciplina_coddisciplina)
                .Index(t => t.Aluno_codaluno);
            
            CreateTable(
                "dbo.DisciplinaCursoes",
                c => new
                    {
                        Disciplina_coddisciplina = c.Int(nullable: false),
                        Curso_codcurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_coddisciplina, t.Curso_codcurso })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Curso_codcurso, cascadeDelete: true)
                .Index(t => t.Disciplina_coddisciplina)
                .Index(t => t.Curso_codcurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trabalhos", "professor_codprofessor", "dbo.Professores");
            DropForeignKey("dbo.Trabalhos", "disciplina_coddisciplina", "dbo.Disciplinas");
            DropForeignKey("dbo.Alunos", "curso_codcurso", "dbo.Cursos");
            DropForeignKey("dbo.Disciplinas", "professor_codprofessor", "dbo.Professores");
            DropForeignKey("dbo.DisciplinaCursoes", "Curso_codcurso", "dbo.Cursos");
            DropForeignKey("dbo.DisciplinaCursoes", "Disciplina_coddisciplina", "dbo.Disciplinas");
            DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_codaluno", "dbo.Alunos");
            DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_coddisciplina", "dbo.Disciplinas");
            DropIndex("dbo.DisciplinaCursoes", new[] { "Curso_codcurso" });
            DropIndex("dbo.DisciplinaCursoes", new[] { "Disciplina_coddisciplina" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_codaluno" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_coddisciplina" });
            DropIndex("dbo.Trabalhos", new[] { "professor_codprofessor" });
            DropIndex("dbo.Trabalhos", new[] { "disciplina_coddisciplina" });
            DropIndex("dbo.Disciplinas", new[] { "professor_codprofessor" });
            DropIndex("dbo.Alunos", new[] { "curso_codcurso" });
            DropTable("dbo.DisciplinaCursoes");
            DropTable("dbo.DisciplinaAlunoes");
            DropTable("dbo.Trabalhos");
            DropTable("dbo.Professores");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Cursos");
            DropTable("dbo.Alunos");
        }
    }
}
