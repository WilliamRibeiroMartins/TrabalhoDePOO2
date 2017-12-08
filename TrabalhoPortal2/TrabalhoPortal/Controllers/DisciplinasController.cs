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
  public class DisciplinasController : ControllerMaster
  {

    // GET: Disciplinas
    public ActionResult Index()
    {
      if (estaLogado().Equals("Master"))
        return View(ListaDisciplina());

      return RedirectToAction("Error", "Home");
    }

    // GET: Disciplinas/Details/5
    public ActionResult Details(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Disciplina disciplina = DisciplinaEspecifica(id);
        var disciplinas = db.disciplinas
          .Include(x => x.professor)
          .Where(x => x.Alunos.Any(a => a.codaluno == id))
          .ToList();
        disciplina = DisciplinaEspecifica(id);
        if (disciplina == null)
        {
          return RedirectToAction("Error", "Home");
        }
        return View(disciplina);
      }
      return RedirectToAction("Error", "Home");
    }
    private Disciplina DisciplinaEspecifica(int? id)
    {
      Disciplina disciplina = db.disciplinas.Include(x => x.professor).Where(x => x.coddisciplina == id).First();
      disciplina.Alunos = db.alunos
        .Where(x => x.disciplinas.Any(a => a.coddisciplina == id))
        .ToList();
      return disciplina;
    }
    private ICollection<Disciplina> ListaDisciplina()
    {
      var disciplinas = db.disciplinas
         .Include(x => x.Alunos)
         .Include(x => x.professor)
         .ToList();

      return disciplinas;
    }
    // GET: Disciplinas/Create
    public ActionResult Create()
    {
      if (estaLogado().Equals("Master"))
        return View();
      return RedirectToAction("Error", "Home");
    }

    // POST: Disciplinas/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "coddisciplina,nome")] Disciplina disciplina)
    {
      if (estaLogado().Equals("Master"))
      {
        if (ModelState.IsValid)
        {
          db.disciplinas.Add(disciplina);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        return View(disciplina);
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Disciplinas/Edit/5
    public ActionResult Edit(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ViewEditDisciplina Modelo = new ViewEditDisciplina();
        Modelo.disciplina = db.disciplinas.Find(id);
        Modelo.professores = db.professores.ToList();
        if (Modelo.disciplina == null)
        {
          return HttpNotFound();
        }
        return View(Modelo);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Disciplinas/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "coddisciplina,nome")] Disciplina disciplina)
    {
      if (estaLogado().Equals("Master"))
      {
        var d = db.disciplinas.Find(disciplina.coddisciplina);
        d.professor = db.professores.Find(Convert.ToInt16(Request["Professor"]));

        db.Entry(d).State = EntityState.Modified;


        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error", "Home");
    }
    public ActionResult AssociarProf(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ViewEditDisciplina Modelo = new ViewEditDisciplina();
        Modelo.disciplina = db.disciplinas.Find(id);
        Modelo.professores = db.professores.ToList();
        if (Modelo.disciplina == null)
        {
          return HttpNotFound();
        }
        return View(Modelo);
      }
      return RedirectToAction("Error", "Home");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AssociarProf([Bind(Include = "coddisciplina,nome")] Disciplina disciplina,
		[Bind(Include = "codprofessor" )] Professor professor)
		{
      if (estaLogado().Equals("Master"))
      {
        var d = db.disciplinas.Find(disciplina.coddisciplina);
        d.professor = db.professores.Find(professor.codprofessor);

        db.Entry(d).State = EntityState.Modified;


        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Disciplinas/Delete/5
    public ActionResult Delete(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Disciplina disciplina = db.disciplinas.Find(id);
        if (disciplina == null)
        {
          return HttpNotFound();
        }
        return View(disciplina);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Disciplinas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (estaLogado().Equals("Master"))
      {
        Disciplina disciplina = db.disciplinas.Find(id);
        db.disciplinas.Remove(disciplina);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error", "Home");
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
