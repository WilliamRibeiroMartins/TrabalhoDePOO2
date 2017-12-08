using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Portal.Models
{
  public class AlunoMap : EntityTypeConfiguration<Disciplina>
  {
    public AlunoMap()
    {
      ToTable("Disciplina");
      HasKey(x => x.coddisciplina);

      //1:N - 1 Disciplina DEVE ter 1 Professor e 1 turma pode ter muitos alunos
      HasRequired(x => x.professor);

      //1:1 - 1 aluno deve ter apenas 1 usuário
    }
  }
  public class EscolaContext : DbContext
	{
    public EscolaContext() : base("name=EscolaContext") { }
    public DbSet<Aluno> alunos { get; set; }
		public DbSet<Professor> professores { get; set; }
		public DbSet<Disciplina> disciplinas { get; set; }
		public DbSet<Trabalho> trabalhos { get; set; }
    public DbSet<Curso> cursos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
     // modelBuilder.Entity<Disciplina>()
     //      .HasMany<Aluno>(s => s.Alunos)
     //      .WithMany(c => c.disciplinas)
     //       .Map(cs =>
     //       {
     //         cs.MapLeftKey("Disciplina_codDisciplina");
     //         cs.MapRightKey("Aluno_codAluno");
     //         cs.ToTable("DisciplinaAlunoes");
     //       });
     // modelBuilder.Entity<Aluno>()
     //.HasMany<Disciplina>(s => s.disciplinas)
     //.WithMany(c => c.Alunos)
     // .Map(cs =>
     // {
     //   cs.MapLeftKey("Disciplina_codDisciplina");
     //   cs.MapRightKey("Aluno_codAluno");
     //   cs.ToTable("DisciplinaAlunoes");
     // });
     // modelBuilder.Entity<Disciplina>().HasRequired(x => x.professor);



    }
  }
}