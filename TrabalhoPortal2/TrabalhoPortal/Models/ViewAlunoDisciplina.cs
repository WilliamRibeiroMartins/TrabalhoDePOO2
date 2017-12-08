using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewAlunoDisciplina
  {
    public ICollection<Disciplina> disciplinas { get; set; }
    public Aluno aluno { get; set; }
  }
}