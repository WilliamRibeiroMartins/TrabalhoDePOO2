using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace TrabalhoPortal.Controllers
{
  public class ControllerMaster : Controller
  {
    public EscolaContext db = new EscolaContext();
    public void resetSession()
    {
      Session["logado"] = false;
      Session["nome"] = string.Empty;
      Session["id"] = 0;
      Session["tipo"] = string.Empty;
      Session["valid"] = true;
    }

    public string estaLogado()
    {
      if (Session.Contents.Keys.Count > 4)
      {
        if ((bool)Session["logado"])
        {
          if (Convert.ToDateTime(Session["date"]).Subtract(DateTime.Now).Minutes < 20)
            return Session["tipo"].ToString();
        }
      }
      //retorna session vazia
      return "";
    }
    public void loginSessions(string cpf, string password)
    {
      if (cpf == "12345678900" && password == "123456789")
      {
        Session["logado"] = true;
        Session["nome"] = "Master";
        Session["id"] = 9999;
        Session["tipo"] = "Master";
        Session["date"] = DateTime.Now;
        return;
      }
      foreach (Aluno aluno in db.alunos.ToList())
      {
        if (aluno.cpf == cpf && aluno.password == password)
        {
          Session["logado"] = true;
          Session["nome"] = aluno.nome;
          Session["id"] = aluno.codaluno;
          Session["tipo"] = "Aluno";
          Session["date"] = DateTime.Now;
          return;
        }
      }
      foreach (Professor professor in db.professores.ToList())
      {
        if (professor.cpf == cpf && professor.password == password)
        {
          Session["logado"] = true;
          Session["nome"] = professor.nome;
          Session["id"] = professor.codprofessor;
          Session["tipo"] = "Professor";
          Session["date"] = DateTime.Now;
          return;
        }
      }
      Session["valid"] = false;

    }
  }
}