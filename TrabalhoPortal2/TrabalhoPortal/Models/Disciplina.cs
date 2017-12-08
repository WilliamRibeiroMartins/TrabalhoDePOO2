using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  [Table("Disciplinas")]
  public class Disciplina
	{
    [Required]
    [Key]
		public int coddisciplina { get; set; }
    [Required]
    [Display(Name = "Nome")]
    public string nome { get; set; }


		public Professor professor { get; set; }
		public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Curso> cursos { get; set; }

  }
}