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
        // GET: FichaCastracao
        public override ActionResult Index()
        {
            var agendamentosUsuario = (from agendamentosList in _sisAdotContext.FichaCastracaos.ToList()
                                where agendamentosList.UsuarioID == new Guid(Session["UsuarioID"].ToString())
                        select new
                        {
                            agendamentosList.CastracaoID,
                            agendamentosList.DataEntrada,
                            agendamentosList.DataSaida,
                        }).ToList(); 

            return View(agendamentosUsuario);
        }

        // GET: FichaCastracao/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCastracao fichaCastracao = _sisAdotContext.FichaCastracaos.Find(id);
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
                fichaCastracao.UsuarioID = new Guid(Session["UsuarioID"].ToString());
                fichaCastracao.CastracaoID = Guid.NewGuid();
                _sisAdotContext.FichaCastracaos.Add(fichaCastracao);
                _sisAdotContext.SaveChanges();
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
            FichaCastracao fichaCastracao = _sisAdotContext.FichaCastracaos.Find(id);
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
                _sisAdotContext.Entry(fichaCastracao).State = EntityState.Modified;
                _sisAdotContext.SaveChanges();
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
            FichaCastracao fichaCastracao = _sisAdotContext.FichaCastracaos.Find(id);
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
            FichaCastracao fichaCastracao = _sisAdotContext.FichaCastracaos.Find(id);
            _sisAdotContext.FichaCastracaos.Remove(fichaCastracao);
            _sisAdotContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sisAdotContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
