using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoPortal.Controllers
{
  public class HomeController : ControllerMaster
  {
    public ActionResult Index()
    {
      resetSession();
      return View();
    }
    public ActionResult Error()
    {
      return View();
    }


    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }
    public ActionResult Login()
    {
      resetSession();
      return View(new Aluno());
    }
    public ActionResult PortalMaster()
    {

      return View(new Aluno());
    }
    public ActionResult Portal()
    {

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login([Bind(Include = "codaluno,matricula,nome,cpf,email,dataNascimento,password")] Aluno aluno)
    {
      loginSessions(aluno.cpf, aluno.password);
      if (estaLogado().Equals("Aluno"))
      {
          return RedirectToAction("Portal", "Aluno");
      }
      else if (estaLogado().Equals("Professor"))
      {

          return RedirectToAction("Portal", "Professor");

      }
      else if (estaLogado().Equals("Master"))
      {
          return RedirectToAction("PortalMaster");
      }
      return View();
  }


  public ActionResult Contact()
  {
    ViewBag.Message = "Your contact page.";

    return View();
  }
}
}