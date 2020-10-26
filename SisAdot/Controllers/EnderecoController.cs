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
    public class EnderecoController : BaseController
    { 
        // GET: Endereco
        public override ActionResult Index()
        {
            return View(_sisAdotContext.Enderecoes.ToList());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = _sisAdotContext.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Bairro,Rua,CEP,Numero,Telefone,Celular,complemento")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                //endereco.UsuarioID = Guid.NewGuid();
                _sisAdotContext.Enderecoes.Add(endereco);
                _sisAdotContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // GET: Endereco/Edit/
        public ActionResult Edit()
        {
            var id = TempData["UsuarioID"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = _sisAdotContext.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Bairro,Rua,CEP,Numero,Telefone,Celular,complemento")] Endereco endereco)
        {
            var id = TempData["UsuarioID"];

            Endereco enderecoEncontrado = _sisAdotContext.Enderecoes.Find(id);
            if (ModelState.IsValid)
            {
                if (enderecoEncontrado == null)
                {
                    _sisAdotContext.Enderecoes.Add(endereco);
                    _sisAdotContext.SaveChanges();
                    return RedirectToAction("Edit");
                }
                else
                {
                    _sisAdotContext.Entry(endereco).State = EntityState.Modified;
                    _sisAdotContext.SaveChanges();
                    return RedirectToAction("Edit");
                }
            }

            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = _sisAdotContext.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Endereco endereco = _sisAdotContext.Enderecoes.Find(id);
            _sisAdotContext.Enderecoes.Remove(endereco);
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
