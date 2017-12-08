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
  public class ProfessorController : ControllerMaster
  {

    // GET: Professor
    public ActionResult Index()
    {
      if (estaLogado().Equals("Master"))
        return View(db.professores.ToList());
      return RedirectToAction("Error", "Home");
    }
		public ActionResult Disciplinas()
		{
			if (estaLogado().Equals("Professor"))
			{
        int id = Convert.ToInt32(Session["id"]);
        var d = db.disciplinas.Include(x => x.professor).Where(x => x.professor.codprofessor == id).ToList();
				return View(d);
			}
      return RedirectToAction("Error", "Home");
    }
    public ActionResult Portal()
    {

      return View();
    }

    // GET: Professor/Details/5
    public ActionResult Details(int? id)
    {
      if (estaLogado().Equals("Master"))
      {

        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Professor professor = db.professores.Find(id);
        if (professor == null)
        {
          return RedirectToAction("Error", "Home");
        }
        return View(professor);
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Professor/Create
    public ActionResult Create()
    {
      if (estaLogado().Equals("Master"))
        return View();
      return RedirectToAction("Error", "Home");
    }

    // POST: Professor/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "codprofessor,matricula,nome,cpf,email,dataNascimento,password")] Professor professor)
    {
      if (estaLogado().Equals("Master"))
      {
        professor.matricula = (db.professores.ToList().Count + 100000).ToString();
        if (ModelState.IsValid)
        {
          db.professores.Add(professor);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        return View(professor);
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Professor/Edit/5
    public ActionResult Edit(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Professor professor = db.professores.Find(id);
        if (professor == null)
        {
          return RedirectToAction("Error", "Home");
        }
        return View(professor);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Professor/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "codprofessor,matricula,nome,cpf,email,dataNascimento,password")] Professor professor)
    {
      if (estaLogado().Equals("Master"))
      {
        if (ModelState.IsValid)
        {
          db.Entry(professor).State = EntityState.Modified;
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        return View(professor);
      }
      return RedirectToAction("Error", "Home");

    }

    // GET: Professor/Delete/5
    public ActionResult Delete(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Professor professor = db.professores.Find(id);
        if (professor == null)
        {
          return HttpNotFound();
        }
        return View(professor);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Professor/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (estaLogado().Equals("Master"))
      {
        Professor professor = db.professores.Find(id);
        db.professores.Remove(professor);
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
