using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisAdot.Data;
using SisAdot.Enums;
using SisAdot.Models.Pessoa;

namespace SisAdot.Controllers
{
    public class PessoaController : BaseController
    {

        // GET: Pessoa
        public override ActionResult Index()
        {
            return View(_sisAdotContext.Pessoas.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _sisAdotContext.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaID,UsuarioID,TipoPessoa,Documento,Descricao,Complemento,DataNascimento")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.PessoaID = Guid.NewGuid();
                _sisAdotContext.Pessoas.Add(pessoa);
                _sisAdotContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult EditJuridica()
        {
            var pessoaUsuario = LocalizaPessoaUsuario(TipoPessoa.Juridica).FirstOrDefault();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Pessoa pessoa = _sisAdotContext.Pessoas.Find(id);
            if (pessoaUsuario == null)
            {
                pessoaUsuario = new Pessoa();
            }
            ViewBag.TipoPessoa = TipoPessoa.Juridica;
            return View("Edit", pessoaUsuario);
        }

        public ActionResult EditFisica()
        {
            var pessoaUsuario = LocalizaPessoaUsuario(TipoPessoa.Fisica).FirstOrDefault();
            ViewBag.TipoPessoa = TipoPessoa.Fisica;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Pessoa pessoa = _sisAdotContext.Pessoas.Find(id);
            if (pessoaUsuario == null)
            {
                pessoaUsuario = new Pessoa();
            }
            return View("Edit", pessoaUsuario);
        }

        private List<Pessoa> LocalizaPessoaUsuario(TipoPessoa tipoPessoa)
        {
            return (from PessoaList in _sisAdotContext.Pessoas.ToList()
                    where PessoaList.UsuarioID == new Guid(Session["UsuarioID"].ToString())
                     && PessoaList.TipoPessoa == tipoPessoa
                    select new Pessoa
                    {
                        PessoaID = PessoaList.PessoaID,
                        Documento = PessoaList.Documento,
                        ComplementoDoc = PessoaList.ComplementoDoc,
                        DataNascimento = PessoaList.DataNascimento,
                        UsuarioID = PessoaList.UsuarioID,
                        Descricao = PessoaList.Descricao,
                        TipoPessoa = PessoaList.TipoPessoa
                    }).ToList();
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaID,UsuarioID,TipoPessoa,Documento,Descricao,Complemento,DataNascimento")] Pessoa pessoa)
        {
            pessoa.TipoPessoa = ViewBag.TipoPessoa;

            if (ModelState.IsValid)
            {
                _sisAdotContext.Entry(pessoa).State = EntityState.Modified;
                _sisAdotContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _sisAdotContext.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pessoa pessoa = _sisAdotContext.Pessoas.Find(id);
            _sisAdotContext.Pessoas.Remove(pessoa);
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
