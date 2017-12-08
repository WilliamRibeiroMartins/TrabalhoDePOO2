using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  [Table("Cursos")]
  public class Curso
  {
    [Required]
    [Key]
    public int codcurso { get; set; }
    [Required]
    [Display(Name = "Curso")]
    public string nome { get; set; }
    public ICollection<Disciplina> disciplinas { get; set; }


  }
}