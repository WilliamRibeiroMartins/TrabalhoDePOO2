using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Portal.Models
{
	public class EscolaContext : DbContext
	{

		public DbSet<Aluno> alunos { get; set; }
		public DbSet<Professor> professores { get; set; }
		public DbSet<Disciplina> disciplinas { get; set; }
		public DbSet<Trabalho> trabalhos { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
			//  base.OnModelCreating(modelBuilder);
			
		//}
  }
}