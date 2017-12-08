using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  [Table("Alunos")]
  public class Aluno : Pessoa
	{
		[Key]
		public int codaluno { get; set; }

    public Curso curso { get; set; }
		public ICollection<Disciplina> disciplinas { get; set; }
	}
}