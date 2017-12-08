using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewCadastroAluno
  {
    public ICollection<Curso> cursos { get; set; }
    public Aluno aluno { get; set; }
  }
}