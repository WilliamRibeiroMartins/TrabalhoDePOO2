namespace TrabalhoPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        codaluno = c.Int(nullable: false, identity: true),
                        matricula = c.String(),
                        nome = c.String(nullable: false),
                        cpf = c.String(nullable: false, maxLength: 11),
                        email = c.String(nullable: false),
                        dataNascimento = c.DateTime(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.codaluno);

            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        coddisciplina = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        professor_codprofessor = c.Int(),
                    })
                .PrimaryKey(t => t.coddisciplina)
                .ForeignKey("dbo.Professors", t => t.professor_codprofessor)
                .Index(t => t.professor_codprofessor);
            
            CreateTable(
                "dbo.Professors",
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
                "dbo.Trabalhoes",
                c => new
                    {
                        codtrabalho = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        DataLimite = c.DateTime(nullable: false),
                        disciplina_coddisciplina = c.Int(),
                    })
                .PrimaryKey(t => t.codtrabalho)
                .ForeignKey("dbo.Disciplinas", t => t.disciplina_coddisciplina)
                .Index(t => t.disciplina_coddisciplina);
            
            CreateTable(
                "dbo.DisciplinaAlunoes",
                c => new
                    {
                        Disciplina_coddisciplina = c.Int(nullable: false),
                        Aluno_codaluno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_coddisciplina, t.Aluno_codaluno })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_coddisciplina, cascadeDelete: true)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_codaluno, cascadeDelete: true)
                .Index(t => t.Disciplina_coddisciplina)
                .Index(t => t.Aluno_codaluno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trabalhoes", "disciplina_coddisciplina", "dbo.Disciplinas");
            DropForeignKey("dbo.Disciplinas", "professor_codprofessor", "dbo.Professors");
            DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_codaluno", "dbo.Alunoes");
            DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_coddisciplina", "dbo.Disciplinas");
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_codaluno" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_coddisciplina" });
            DropIndex("dbo.Trabalhoes", new[] { "disciplina_coddisciplina" });
            DropIndex("dbo.Disciplinas", new[] { "professor_codprofessor" });
            DropTable("dbo.DisciplinaAlunoes");
            DropTable("dbo.Trabalhoes");
            DropTable("dbo.Professors");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Alunoes");
        }
    }
}
