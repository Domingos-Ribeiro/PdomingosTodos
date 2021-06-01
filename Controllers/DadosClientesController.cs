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
    public class DadosClientesController : Controller
    {
        private PdomingosTodosContext db = new PdomingosTodosContext();

        // GET: DadosClientes
        public ActionResult Index()
        {
            return View(db.DadosClientes.ToList());
        }

        // GET: DadosClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadosCliente dadosCliente = db.DadosClientes.Find(id);
            if (dadosCliente == null)
            {
                return HttpNotFound();
            }
            return View(dadosCliente);
        }

        // GET: DadosClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DadosClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DNomeCliente,SenhaTipo,MoradaCliente,TelefoneCliente,EmailCliente,ClienteId")] DadosCliente dadosCliente)
        {
            if (ModelState.IsValid)
            {
                db.DadosClientes.Add(dadosCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dadosCliente);
        }

        // GET: DadosClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadosCliente dadosCliente = db.DadosClientes.Find(id);
            if (dadosCliente == null)
            {
                return HttpNotFound();
            }
            return View(dadosCliente);
        }

        // POST: DadosClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DNomeCliente,SenhaTipo,MoradaCliente,TelefoneCliente,EmailCliente,ClienteId")] DadosCliente dadosCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dadosCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dadosCliente);
        }

        // GET: DadosClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadosCliente dadosCliente = db.DadosClientes.Find(id);
            if (dadosCliente == null)
            {
                return HttpNotFound();
            }
            return View(dadosCliente);
        }

        // POST: DadosClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DadosCliente dadosCliente = db.DadosClientes.Find(id);
            db.DadosClientes.Remove(dadosCliente);
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
