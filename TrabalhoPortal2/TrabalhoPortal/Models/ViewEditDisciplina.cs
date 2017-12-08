using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewEditDisciplina
  {
    public ICollection<Professor> professores { get; set; }
    public Disciplina disciplina { get; set; }
  }
}