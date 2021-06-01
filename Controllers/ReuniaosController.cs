using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PdomingosTodos.DAL;
using PdomingosTodos.Models;

namespace PdomingosTodos.Controllers
{
    public class ReuniaosController : Controller
    {
        private PdomingosTodosContext db = new PdomingosTodosContext();

        // GET: Reuniaos
        public ActionResult Index()
        {
            var reunioes = db.Reunioes.Include(r => r.Funcionario);
            return View(reunioes.ToList());
        }

        // GET: Reuniaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reunioes.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // GET: Reuniaos/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "NomeFuncionario");
            return View();
        }

        // POST: Reuniaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataReuniao,Tema,Minutos,FuncionarioId")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Reunioes.Add(reuniao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reuniaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reunioes.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // POST: Reuniaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataReuniao,Tema,Minutos,FuncionarioId")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reuniao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reuniaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reunioes.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reuniaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reuniao reuniao = db.Reunioes.Find(id);
            db.Reunioes.Remove(reuniao);
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
