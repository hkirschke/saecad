using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisAdot.Data;
using SisAdot.Models;

namespace SisAdot.Controllers
{
    public class FichaCastracaoController : BaseController
    {
        private SisAdotContext db = new SisAdotContext();

        // GET: FichaCastracao
        public override ActionResult Index()
        {
            return View(db.FichaCastracaos.ToList());
        }

        // GET: FichaCastracao/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCastracao fichaCastracao = db.FichaCastracaos.Find(id);
            if (fichaCastracao == null)
            {
                return HttpNotFound();
            }
            return View(fichaCastracao);
        }

        // GET: FichaCastracao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FichaCastracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CastracaoID,DataEntrada,DataSaida")] FichaCastracao fichaCastracao)
        {
            if (ModelState.IsValid)
            {
                fichaCastracao.CastracaoID = Guid.NewGuid();
                db.FichaCastracaos.Add(fichaCastracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fichaCastracao);
        }

        // GET: FichaCastracao/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCastracao fichaCastracao = db.FichaCastracaos.Find(id);
            if (fichaCastracao == null)
            {
                return HttpNotFound();
            }
            return View(fichaCastracao);
        }

        // POST: FichaCastracao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CastracaoID,DataEntrada,DataSaida")] FichaCastracao fichaCastracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaCastracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fichaCastracao);
        }

        // GET: FichaCastracao/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCastracao fichaCastracao = db.FichaCastracaos.Find(id);
            if (fichaCastracao == null)
            {
                return HttpNotFound();
            }
            return View(fichaCastracao);
        }

        // POST: FichaCastracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FichaCastracao fichaCastracao = db.FichaCastracaos.Find(id);
            db.FichaCastracaos.Remove(fichaCastracao);
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
