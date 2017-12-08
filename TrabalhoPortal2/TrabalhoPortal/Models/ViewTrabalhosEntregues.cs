using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewTrabalhosEntregues
  {
    public Trabalho trabalho { get; set; }
    public List<String> Alunos { get; set; }
    public ViewTrabalhosEntregues()
    {
      Alunos = new List<string>();
    }
  }
}