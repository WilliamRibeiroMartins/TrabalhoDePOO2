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
	public class CursosController : ControllerMaster
	{

		// GET: Cursos
		public ActionResult Index()
		{
			return View(db.cursos.ToList());
		}

		// GET: Cursos/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Curso curso = db.cursos.Include(x => x.disciplinas).Where(x => x.codcurso == id).FirstOrDefault();
			if (curso == null)
			{
        return RedirectToAction("Error", "Home");
      }
			return View(curso);
		}

		// GET: Cursos/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Cursos/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "codcurso,nome")] Curso curso)
		{
			if (ModelState.IsValid)
			{
				db.cursos.Add(curso);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(curso);
		}

		public ActionResult AssociarDisc(int? id)
		{
			if (estaLogado().Equals("Master"))
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				ViewCursoDisciplina Modelo = new ViewCursoDisciplina();
				Modelo.curso = db.cursos.Find(id);
				Modelo.disciplinas = db.disciplinas.ToList();
				var disciplinasdocurso = db.cursos.Include(x => x.disciplinas).Where(x => x.codcurso == id).FirstOrDefault<Curso>().disciplinas;
				if (disciplinasdocurso != null)
					foreach (var x in db.disciplinas.ToList())
					{
						foreach (var y in disciplinasdocurso)
						{
							if (x.coddisciplina == y.coddisciplina)
							{
								Modelo.disciplinas.Remove(x);
							}
						}
					}
				if (Modelo.disciplinas == null)
				{
					Modelo.disciplinas = new List<Disciplina>();
				}
				if (Modelo.curso == null)
				{
					return HttpNotFound();
				}
				return View(Modelo);
			}
      return RedirectToAction("Error", "Home");
    }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AssociarDisc([Bind(Include = "codcurso,nome")] Curso curso,
			[Bind(Include = "coddisciplina")] Disciplina disciplina)
		{
			if (estaLogado().Equals("Master"))
			{
				var d = db.cursos.Find(curso.codcurso);
				d.disciplinas = new List<Disciplina>();
				d.disciplinas.Add(db.disciplinas.Find(disciplina.coddisciplina));
				db.Entry(d).State = EntityState.Modified;


				db.SaveChanges();
				return RedirectToAction("Index");
			}
      return RedirectToAction("Error", "Home");
    }
		public ActionResult Desassociar(int? codcurso, int? coddisciplina)
		{
			if (estaLogado().Equals("Master"))
			{
				var d = db.cursos.Include(x => x.disciplinas).Where(x => x.codcurso == codcurso).FirstOrDefault<Curso>();
				Disciplina disc = db.disciplinas.Find(coddisciplina);
				d.disciplinas.Remove(disc);


				db.SaveChanges();
				return RedirectToAction("Details/" + codcurso);
			}
      return RedirectToAction("Error", "Home");
    }

		// GET: Cursos/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Curso curso = db.cursos.Find(id);
			if (curso == null)
			{
        return RedirectToAction("Error", "Home");
      }
			return View(curso);
		}

		// POST: Cursos/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "codcurso,nome")] Curso curso)
		{
			if (ModelState.IsValid)
			{
				db.Entry(curso).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(curso);
		}

		// GET: Cursos/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Curso curso = db.cursos.Find(id);
			if (curso == null)
			{
        return RedirectToAction("Error", "Home");
      }
			return View(curso);
		}

		// POST: Cursos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Curso curso = db.cursos.Find(id);
			db.cursos.Remove(curso);
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
