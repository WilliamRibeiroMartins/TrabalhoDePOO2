using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
using System.IO;

namespace TrabalhoPortal.Controllers
{
  public class AlunoController : ControllerMaster
  {
    public ActionResult Entrega()
    {
      string nomeAluno = Session["nome"].ToString();
      int codaluno = Convert.ToInt32(Session["id"]);
      int codtrab = int.Parse(Request["Trabalho"]);
      Trabalho trabalho = db.trabalhos.Include(x => x.professor).Include(x => x.disciplina).Where(x => x.codtrabalho == codtrab).FirstOrDefault();
      HttpPostedFileBase file = Request.Files["entrega"];
      String caminho = "C:\\PortalTrabalhos\\" + trabalho.codtrabalho + "-" + trabalho.professor.codprofessor + "-" + trabalho.disciplina.coddisciplina;
      if (!Directory.Exists(caminho))
      {
        Directory.CreateDirectory(caminho);
      }
      foreach (string arquivo in Directory.EnumerateFiles(caminho))
      {
        if (arquivo.Equals(caminho + "\\" + trabalho.nome + "-" + nomeAluno + ".pdf"))
        {
          System.IO.File.Delete(arquivo);
        }
      }
      file.SaveAs(caminho + "\\" + trabalho.nome + "-" + nomeAluno + ".pdf");
      Session["valid"] = true;
      return RedirectToAction("Portal");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Portal(int id)
    {

      if (estaLogado().Equals("Aluno"))
      {
        string nomeAluno = Session["nome"].ToString();
        int codaluno = Convert.ToInt32(Session["id"]);
        Trabalho trabalho = db.trabalhos.Find(id);

        return View();
      }
      return RedirectToAction("Error", "Home");
    }



    public ActionResult Trabalhos(int cod)
    {
      if (estaLogado().Equals("Aluno"))
      {
        int id = (int)Session["id"];
        return View(db.trabalhos.Include(x => x.disciplina).Where(x => x.disciplina.coddisciplina == cod));
      }
      return RedirectToAction("Index", "Home");
    }
    // GET: Aluno
    public ActionResult Index()
    {
      if (estaLogado().Equals("Master"))
      {
        return View(db.alunos.Include(x => x.curso).Include(x => x.disciplinas).ToList());
      }
      return RedirectToAction("Error", "Home");
    }
    public ActionResult Portal()
    {

      if (estaLogado().Equals("Aluno"))
      {
        ViewTrabalho trabalhos = new ViewTrabalho();
        string nomeAluno = Session["nome"].ToString();
        string caminho = string.Empty;
        int id = (int)Session["id"];
        var disc = db.alunos.Include(x => x.disciplinas).Where(x => x.codaluno == id).First(); ;
        var d = db.trabalhos.Include(y => y.disciplina).Include(x=>x.professor).ToList();
        var e = d;
        foreach (var x in disc.disciplinas)
          foreach (var y in e)
            if (y.disciplina.coddisciplina == x.coddisciplina)
            {
              trabalhos.trabalhos.Add(y);
              caminho = "C:\\PortalTrabalhos\\" + y.codtrabalho + "-" + y.professor.codprofessor + "-" + y.disciplina.coddisciplina;
              if (!System.IO.File.Exists(caminho + "\\" + y.nome + "-" + nomeAluno + ".pdf"))
                trabalhos.Existe.Add(true);
              else
                trabalhos.Existe.Add(false);
            }
        return View(trabalhos);
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Aluno/Details/5
    public ActionResult Details(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        //var disciplinas = db.alunos
        //  .Include(x => x.disciplinas.Select(y => y.professor))
        //  .Where(x => x.codaluno == id).ToList();
        //Recupera as disciplinas do aluno por id
        Aluno aluno = AlunoEspecifico(id);
        if (aluno == null)
        {
          return HttpNotFound();
        }
        return View(aluno);
      }
      return RedirectToAction("Error", "Home");
    }
    public ActionResult AssociarDisc(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ViewAlunoDisciplina Modelo = new ViewAlunoDisciplina();
        Modelo.aluno = db.alunos.Include(x => x.curso.disciplinas).Where(x => x.codaluno == id).First();
        Modelo.disciplinas = Modelo.aluno.curso.disciplinas;
        var disciplinasdoaluno = db.alunos.Include(x => x.disciplinas).Where(x => x.codaluno == id).FirstOrDefault<Aluno>().disciplinas;
        if (disciplinasdoaluno != null)
          foreach (var x in db.disciplinas.ToList())
          {
            foreach (var y in disciplinasdoaluno)
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

        if (Modelo.aluno == null)
        {
          return HttpNotFound();
        }
        return View(Modelo);
      }
      return RedirectToAction("Error", "Home");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AssociarDisc([Bind(Include = "CodAluno,nome")] Aluno aluno,
      [Bind(Include = "coddisciplina")] Disciplina disciplina)
    {
      if (estaLogado().Equals("Master"))
      {
        var d = db.alunos.Find(aluno.codaluno);
        d.disciplinas = new List<Disciplina>();
        d.disciplinas.Add(db.disciplinas.Find(disciplina.coddisciplina));
        db.Entry(d).State = EntityState.Modified;


        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error", "Home");
    }

    public ActionResult Desassociar(int? codaluno, int? coddisciplina)
    {
      if (estaLogado().Equals("Master"))
      {
        var d = db.alunos.Include(x => x.disciplinas).Where(x => x.codaluno == codaluno).FirstOrDefault<Aluno>();
        Disciplina disc = db.disciplinas.Find(coddisciplina);
        d.disciplinas.Remove(disc);


        db.SaveChanges();
        return RedirectToAction("Details/" + codaluno);
      }
      return RedirectToAction("Index", "Home");
    }

    private Aluno AlunoEspecifico(int? id)
    {
      var aluno = db.alunos.Include(X => X.curso).Include(x => x.disciplinas).Where(x => x.codaluno == id).Single();
      return aluno;
    }
    private ICollection<Aluno> ListaAlunos()
    {
      var alunos = db.alunos
         .Include(x => x.disciplinas.Select(y => y.professor))
         .ToList();
      return alunos;
    }

    // GET: Aluno/Create
    public ActionResult Create()
    {
      if (estaLogado().Equals("Master"))
      {
        if (Session["tipo"].ToString().Equals("Master"))
        {
          ViewCadastroAluno cadastro = new ViewCadastroAluno();
          cadastro.cursos = db.cursos.ToList();
          return View(cadastro);
        }
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Aluno/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(
      [Bind(Include = "codaluno,matricula,nome,cpf,email,dataNascimento,password, id")]
    Aluno aluno, [Bind(Include = "codcurso")]
    Curso curso)
    {
      if (estaLogado().Equals("Master"))
      {
        aluno.matricula = (db.alunos.ToList().Count + 100000).ToString();
        aluno.curso = db.cursos.Find(curso.codcurso);
        db.alunos.Add(aluno);
        db.SaveChanges();

        return RedirectToAction("Index");
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Aluno/Edit/5
    public ActionResult Edit(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Aluno aluno = db.alunos.Find(id);
        if (aluno == null)
        {
          return RedirectToAction("Error", "Home");
        }
        return View(aluno);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Aluno/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "codaluno,matricula,nome,cpf,email,dataNascimento,password")] Aluno aluno)
    {
      if (estaLogado().Equals("Master"))
      {
        if (ModelState.IsValid)
        {
          db.Entry(aluno).State = EntityState.Modified;
          db.SaveChanges();
          return View(aluno);
        }
      }
      return RedirectToAction("Error", "Home");
    }

    // GET: Aluno/Delete/5
    public ActionResult Delete(int? id)
    {
      if (estaLogado().Equals("Master"))
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Aluno aluno = db.alunos.Find(id);
        if (aluno == null)
        {
          return RedirectToAction("Error", "Home");
        }
        return View(aluno);
      }
      return RedirectToAction("Error", "Home");
    }

    // POST: Aluno/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (estaLogado().Equals("Master"))
      {
        Aluno aluno = db.alunos.Find(id);
        db.alunos.Remove(aluno);
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
