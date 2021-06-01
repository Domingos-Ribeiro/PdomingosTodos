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
    public class TempoGastoesController : Controller
    {
        private PdomingosTodosContext db = new PdomingosTodosContext();

        // GET: TempoGastoes
        public ActionResult Index()
        {
            return View(db.TemposGastos.ToList());
        }

        // GET: TempoGastoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempoGasto tempoGasto = db.TemposGastos.Find(id);
            if (tempoGasto == null)
            {
                return HttpNotFound();
            }
            return View(tempoGasto);
        }

        // GET: TempoGastoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempoGastoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,TempoUsado,Minutos")] TempoGasto tempoGasto)
        {
            if (ModelState.IsValid)
            {
                db.TemposGastos.Add(tempoGasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempoGasto);
        }

        // GET: TempoGastoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempoGasto tempoGasto = db.TemposGastos.Find(id);
            if (tempoGasto == null)
            {
                return HttpNotFound();
            }
            return View(tempoGasto);
        }

        // POST: TempoGastoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,TempoUsado,Minutos")] TempoGasto tempoGasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempoGasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempoGasto);
        }

        // GET: TempoGastoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempoGasto tempoGasto = db.TemposGastos.Find(id);
            if (tempoGasto == null)
            {
                return HttpNotFound();
            }
            return View(tempoGasto);
        }

        // POST: TempoGastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TempoGasto tempoGasto = db.TemposGastos.Find(id);
            db.TemposGastos.Remove(tempoGasto);
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
