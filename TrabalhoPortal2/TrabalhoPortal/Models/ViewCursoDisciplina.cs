using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewCursoDisciplina
  {
    public ICollection<Disciplina> disciplinas { get; set; }
    public Curso curso { get; set; }
  }
}