namespace Portal.Migrations
{
  using Portal.Models;
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<Portal.Models.EscolaContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(Portal.Models.EscolaContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      context.cursos.AddOrUpdate(x => x.nome,
      new Curso { nome = "Sistemas de Informação" },
      new Curso { nome = "Ciências da Computação" },
      new Curso { nome = "Musica" },
      new Curso { nome = "Engenharia Mecanica" }
      );

      context.alunos.AddOrUpdate(p => p.matricula,
       new Aluno { nome = "Andrew Peters", matricula = "100000", cpf = "10000000000", dataNascimento = Convert.ToDateTime("11/11/1992"), email = "Peters@gmail.com", password = "123456789" },
       new Aluno { nome = "Brice Lambson", matricula = "100001", cpf = "65000000432", dataNascimento = Convert.ToDateTime("01/06/1987"), email = "Lambson@gmail.com", password = "123456789" },
       new Aluno { nome = "John  Bailey", matricula = "100002", cpf = "20302536930", dataNascimento = Convert.ToDateTime("14/01/1992"), email = "Bailey@gmail.com", password = "123456789" },
       new Aluno { nome = "Janet Boyd", matricula = "100003", cpf = "42958433340", dataNascimento = Convert.ToDateTime("21/11/1988"), email = "Boyd@gmail.com", password = "123456789" },
       new Aluno { nome = "Alex  Pereira ", matricula = "100004", cpf = "92534648698", dataNascimento = Convert.ToDateTime("17/06/1990"), email = "Pereira@gmail.com", password = "123456789" },
       new Aluno { nome = "Rowan Miller", matricula = "100005", cpf = "26374828182", dataNascimento = Convert.ToDateTime("30/01/1987"), email = "Miller@gmail.com", password = "123456789" },
       new Aluno { nome = "Paulo Jackson", matricula = "100006", cpf = "19384759293", dataNascimento = Convert.ToDateTime("12/03/1987"), email = "Jackson@gmail.com", password = "123456789" },
       new Aluno { nome = "Luan Ribeiro", matricula = "100007", cpf = "12200394855", dataNascimento = Convert.ToDateTime("28/03/1987"), email = "Ribeiro@gmail.com", password = "123456789" },
			 new Aluno { nome = "Gabriel Martins", matricula = "100008", cpf = "12200394966", dataNascimento = Convert.ToDateTime("21/03/1995"), email = "martins@gmail.com", password = "123456789" },
			 new Aluno { nome = "Son Goku", matricula = "100009", cpf = "12504394996", dataNascimento = Convert.ToDateTime("07/05/1985"), email = "son@gmail.com", password = "123456789" },
			 new Aluno { nome = "Vegeta", matricula = "100010", cpf = "12200394977", dataNascimento = Convert.ToDateTime("20/09/1985"), email = "principesaiajin@gmail.com", password = "123456789" },
			 new Aluno { nome = "Son Gohan", matricula = "100011", cpf = "12200394870", dataNascimento = Convert.ToDateTime("25/07/1995"), email = "gohan@gmail.com", password = "123456789" },
			 new Aluno { nome = "Trunks", matricula = "100012", cpf = "12247394874", dataNascimento = Convert.ToDateTime("03/03/1995"), email = "trunks@gmail.com", password = "123456789" }
				);

      context.professores.AddOrUpdate(x => x.matricula,
        new Professor { nome = "Marcus Luiz", matricula = "100000", cpf = "20304050698", dataNascimento = new DateTime(1958, 8, 3), email = "Marcus@gmail.com", password = "123456789" },
        new Professor { nome = "Jean Macedo", matricula = "100001", cpf = "98304050692", dataNascimento = new DateTime(1970, 7, 13), email = "Jean@gmail.com", password = "123456789" },
        new Professor { nome = "Manuel Waldir", matricula = "100002", cpf = "53303450698", dataNascimento = new DateTime(1969, 3, 22), email = "Manuel@gmail.com", password = "123456789" },
        new Professor { nome = "Lililam Gustava", matricula = "100003", cpf = "28914250698", dataNascimento = new DateTime(1982, 2, 19), email = "Lililam@gmail.com", password = "123456789" },
        new Professor { nome = "Alessandro Paulo", matricula = "100004", cpf = "60304150623", dataNascimento = new DateTime(1980, 8, 29), email = "Alessandro@gmail.com", password = "123456789" });

      context.disciplinas.AddOrUpdate(x => x.nome,
        new Disciplina { nome = "Projeto de Algoritmos" },
        new Disciplina { nome = "Algoritmos e estrutura de dados" },
        new Disciplina { nome = "Algebra Linear" },
        new Disciplina { nome = "Historia da Musica" },
        new Disciplina { nome = "Fisica" },
        new Disciplina { nome = "Grafos" },
        new Disciplina { nome = "Programação Orientada a Objetos" },
        new Disciplina { nome = "Sistemas Operacionais" },
        new Disciplina { nome = "Algoritmos e Técnicas de programação" }
        );
      context.trabalhos.AddOrUpdate(x => x.nome,
        new Trabalho { nome = "TP1", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 17) },
        new Trabalho { nome = "Grafos de Drogarias", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 28) },
        new Trabalho { nome = "Polimorfismo", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 25) },
        new Trabalho { nome = "Diagrama de atividades", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 30) },
        new Trabalho { nome = "TP2", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 10) },
        new Trabalho { nome = "TP3", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 25) },
        new Trabalho { nome = "TP4", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 30) },
        new Trabalho { nome = "TP5", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 10) },
        new Trabalho { nome = "TP Final", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 30) },
        new Trabalho { nome = "Matematica Discreta", DataPublicacao = DateTime.Now, DataLimite = new DateTime(2017, 12, 10) }
        );
      context.SaveChanges();

      var t = context.trabalhos.Include(x => x.disciplina).Include(x => x.professor).ToList();
      t[0].professor = context.disciplinas.Include(x=>x.professor).Where(x=>x.coddisciplina == 2).First().professor;
      t[0].disciplina = context.disciplinas.Find(2);
      t[1].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 6).First().professor;
      t[1].disciplina = context.disciplinas.Find(6);
      t[2].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 7).First().professor;
      t[2].disciplina = context.disciplinas.Find(7);
      t[3].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 1).First().professor;
      t[3].disciplina = context.disciplinas.Find(1);
      t[4].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 3).First().professor;
      t[4].disciplina = context.disciplinas.Find(3);
      t[5].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 2).First().professor;
      t[5].disciplina = context.disciplinas.Find(2);
      t[6].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 4).First().professor;
      t[6].disciplina = context.disciplinas.Find(4);
      t[7].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 5).First().professor;
      t[7].disciplina = context.disciplinas.Find(5);
      t[8].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 2).First().professor;
      t[8].disciplina = context.disciplinas.Find(2);
      t[9].professor = context.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == 1).First().professor;
      t[9].disciplina = context.disciplinas.Find(1);


      var d = context.disciplinas.Include(x => x.Alunos).Include(x => x.cursos).ToList();

      d[0].professor = context.professores.Find(2);
      d[0].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };
      d[0].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };

      d[1].professor = context.professores.Find(2);
      d[1].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };
      d[1].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };

      d[2].professor = context.professores.Find(4);
      d[2].Alunos = new List<Aluno> { context.alunos.Find(2), context.alunos.Find(4), context.alunos.Find(8), context.alunos.Find(7) };
      d[2].cursos = new List<Curso> { context.cursos.Find(2), context.cursos.Find(4) };

      d[3].professor = context.professores.Find(1);
      d[3].Alunos = new List<Aluno> { context.alunos.Find(3) };
      d[3].cursos = new List<Curso> { context.cursos.Find(3) };

      d[4].professor = context.professores.Find(3);
      d[4].Alunos = new List<Aluno> { context.alunos.Find(2), context.alunos.Find(4), context.alunos.Find(8), context.alunos.Find(7) };
      d[4].cursos = new List<Curso> { context.cursos.Find(2), context.cursos.Find(4) };

      d[5].professor = context.professores.Find(1);
      d[5].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };
      d[5].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };

      d[6].professor = context.professores.Find(3);
      d[6].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };
      d[6].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };

      d[7].professor = context.professores.Find(4);
      d[7].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };
      d[7].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };

      d[8].professor = context.professores.Find(2);
      d[8].Alunos = new List<Aluno> { context.alunos.Find(1), context.alunos.Find(2), context.alunos.Find(5), context.alunos.Find(6), context.alunos.Find(7) };
      d[8].cursos = new List<Curso> { context.cursos.Find(1), context.cursos.Find(2) };

      var al = context.alunos.ToList();
      al[0].curso = context.cursos.Find(1);
      al[1].curso = context.cursos.Find(2);
      al[2].curso = context.cursos.Find(3);
      al[3].curso = context.cursos.Find(4);
      al[4].curso = context.cursos.Find(1);
      al[5].curso = context.cursos.Find(1);
      al[6].curso = context.cursos.Find(2);
      al[7].curso = context.cursos.Find(4);
			al[8].curso = context.cursos.Find(4);
			al[9].curso = context.cursos.Find(3);
			al[10].curso = context.cursos.Find(2);
			al[11].curso = context.cursos.Find(1);
			al[12].curso = context.cursos.Find(4);

			foreach (var x in t)
        context.Entry(x).State = EntityState.Modified;
      foreach (var x in d)
        context.Entry(x).State = EntityState.Modified;
      foreach (var x in al)
        context.Entry(x).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}
