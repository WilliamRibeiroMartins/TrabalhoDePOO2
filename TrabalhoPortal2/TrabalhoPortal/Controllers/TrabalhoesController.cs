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
  public class TrabalhoesController : ControllerMaster
  {

    // GET: Trabalhoes
    public ActionResult Trabalhos()
    {
      if (estaLogado().Equals("Professor"))
      {
        int id = (int)Session["id"];
        return View(db.trabalhos.Include(x => x.disciplina).Where(x => x.professor.codprofessor == id));
      }
      return RedirectToAction("Error", "Home");
    }
    public ActionResult Index()
    {
      if (estaLogado().Equals("Master"))
      {
        int id = (int)Session["id"];
        return View(db.trabalhos.Include(x=>x.disciplina).Include(x=>x.professor).ToList());
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Trabalhoes/Details/5
    public ActionResult Details(int? id)
    {
      if (estaLogado().Equals("Professor"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        ViewTrabalhosEntregues trabalho = new ViewTrabalhosEntregues();       
        trabalho.trabalho = db.trabalhos.Include(y => y.disciplina).Include(x => x.professor).Where(x=>x.codtrabalho == id).FirstOrDefault();
        string caminho = "C:\\PortalTrabalhos\\" + trabalho.trabalho.codtrabalho + "-" + trabalho.trabalho.professor.codprofessor + "-" + trabalho.trabalho.disciplina.coddisciplina;
        foreach(Aluno x in db.alunos.ToList())
        {
          if (System.IO.File.Exists(caminho + "\\" + trabalho.trabalho.nome + "-" + x.nome+".pdf"))
          {
            trabalho.Alunos.Add(x.nome+".pdf");
          }
        }
        if (trabalho == null)
        {
          return RedirectToAction("Error", "Home");
        }

        return View(trabalho);
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Trabalhoes/Create
    public ActionResult Create(int? id)
    {
      ViewCadastroTrabalho cadastro = new ViewCadastroTrabalho();
      cadastro.disciplina = db.disciplinas.Find(id);
      return View(cadastro);
    }

    // POST: Trabalhoes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "codtrabalho,nome,DataLimite")] Trabalho trabalho, 
      [Bind(Include ="coddisciplina")] Disciplina disciplina)
    {
      trabalho.DataPublicacao = DateTime.Now;
      trabalho.disciplina = db.disciplinas.Find(disciplina.coddisciplina);
      trabalho.professor = db.professores.Find(Convert.ToInt32(Session["id"]));

      db.trabalhos.Add(trabalho);

      db.SaveChanges();
      return RedirectToAction("Portal","Professor");
    }

    // GET: Trabalhoes/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Trabalho trabalho = db.trabalhos.Find(id);
      if (trabalho == null)
      {
        return RedirectToAction("Error", "Home");
      }
      return View(trabalho);
    }

    // POST: Trabalhoes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "codtrabalho,nome,DataLimite")] Trabalho trabalho)
    {
      if (estaLogado().Equals("Professor"))
      {
        Trabalho t = db.trabalhos.Find(trabalho.codtrabalho);
        t.DataLimite = trabalho.DataLimite;
        db.Entry(t).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(trabalho);
    }

    // GET: Trabalhoes/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Trabalho trabalho = db.trabalhos.Find(id);
      if (trabalho == null)
      {
        return RedirectToAction("Error", "Home");
      }
      return View(trabalho);
    }

    // POST: Trabalhoes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Trabalho trabalho = db.trabalhos.Find(id);
      db.trabalhos.Remove(trabalho);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
