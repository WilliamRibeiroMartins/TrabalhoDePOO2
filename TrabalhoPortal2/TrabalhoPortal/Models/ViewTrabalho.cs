using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class ViewTrabalho
  {
    public ViewTrabalho(){
      trabalhos = new List<Trabalho>();
      Existe = new List<bool>();
      }
    public List<Trabalho> trabalhos { get; set; }
    public List<bool> Existe { get; set; }
  }
}