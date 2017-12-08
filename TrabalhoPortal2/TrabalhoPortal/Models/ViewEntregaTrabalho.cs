using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewEntregaTrabalho
  {
    public ICollection<Trabalho> trabalhos { get; set; }
    public Disciplina disciplina { get; set; }
  }
}