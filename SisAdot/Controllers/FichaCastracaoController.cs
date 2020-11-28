using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisAdot.Data;
using SisAdot.Extensions;
using SisAdot.Models;
using SisAdot.Models.Animal;

namespace SisAdot.Controllers
{
    public class FichaCastracaoController : BaseController
    {
        private const string MensagemConflitoAgenda = "Conflito de agenda da equipe,  as consultas devem possuir ao menos 20 minutos entre elas!\n Consulta agendada para as {0}";
         
        // GET: FichaCastracao
        public override ActionResult Index()
        {
            List<FichaCastracaoViewModel> agendamentosUsuario = (from agendamentosList in _sisAdotContext.FichaCastracaos.ToList()
                                                                 join animalList in _sisAdotContext.Animals.ToList()
                                                                 on agendamentosList.AnimalID equals animalList.AnimalID
                                                                 join equipeVetList in _sisAdotContext.EquipeVeterinarios.ToList()
                                                                 on agendamentosList.EquipeVeterinarioID equals equipeVetList.EquipeVeterinarioID
                                                                 where agendamentosList.UsuarioID == new Guid(Session["UsuarioID"].ToString())
                                                                 select new FichaCastracaoViewModel
                                                                 {
                                                                     NomeAnimal = animalList.Nome,
                                                                     CastracaoID = agendamentosList.CastracaoID,
                                                                     DataEntrada = agendamentosList.DataEntrada?.ToString("g", CultureInfo),
                                                                     DataSaida = agendamentosList.DataSaida?.ToString("g", CultureInfo),
                                                                     NomeEquipe = equipeVetList.Nome
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
            ViewBag.Animais = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));
            ViewBag.EquipeVet = _sisAdotContext.EquipeVeterinarios.ToList();
            return View();
        }

        // POST: FichaCastracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CastracaoID,DataEntrada,DataSaida,AnimalID, EquipeVeterinarioID")] FichaCastracao fichaCastracao)
        {
            var listConsultas = _sisAdotContextFichaUtil.ValidaAgenda(fichaCastracao.DataEntrada, fichaCastracao.EquipeVeterinarioID);
            if (!listConsultas.Any())
            {
                if (ModelState.IsValid)
                {
                    fichaCastracao.UsuarioID = new Guid(Session["UsuarioID"].ToString());
                    fichaCastracao.CastracaoID = Guid.NewGuid();
                    _sisAdotContext.FichaCastracaos.Add(fichaCastracao);
                    _sisAdotContext.SaveChanges();
                    AddNotificacaoSucesso("Consulta Agendada");
                    return RedirectToAction("Index");
                }
                return View(fichaCastracao);
            }
            AddNotificacaoAviso(string.Format(MensagemConflitoAgenda, listConsultas.FirstOrDefault().DataEntrada?.ToString("g", CultureInfo)));
            return View("Edit", fichaCastracao);
        }

        // GET: FichaCastracao/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Animais = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));
            ViewBag.EquipeVet = _sisAdotContext.EquipeVeterinarios.ToList();
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
        public ActionResult Edit([Bind(Include = "CastracaoID,DataEntrada,DataSaida,AnimalID, EquipeVeterinarioID")] FichaCastracao fichaCastracao)
        {
            var listConsultas = _sisAdotContextFichaUtil.ValidaAgenda(fichaCastracao.DataEntrada, fichaCastracao.EquipeVeterinarioID);
            if (!listConsultas.Any())
            {
                ViewBag.Animais = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));
                ViewBag.EquipeVet = _sisAdotContext.EquipeVeterinarios.ToList();
                if (ModelState.IsValid)
                {
                    fichaCastracao.UsuarioID = new Guid(Session["UsuarioID"].ToString());
                    _sisAdotContext.Entry(fichaCastracao).State = EntityState.Modified;
                    _sisAdotContext.SaveChanges();
                    AddNotificacaoSucesso("Consulta Alterada");
                    return RedirectToAction("Index");
                }
                return View(fichaCastracao);
            }
            ViewBag.Animais = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));
            ViewBag.EquipeVet = _sisAdotContext.EquipeVeterinarios.ToList();
            fichaCastracao = _sisAdotContext.FichaCastracaos.Find(fichaCastracao.CastracaoID);
            AddNotificacaoAviso(string.Format(MensagemConflitoAgenda, listConsultas.FirstOrDefault().DataEntrada?.ToString("g", CultureInfo)));
            return View("Edit", fichaCastracao);
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
            AddNotificacaoSucesso("Consulta desmarcada");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Desmarcar(Guid id)
        {
            FichaCastracao fichaCastracao = _sisAdotContext.FichaCastracaos.Find(id);
            fichaCastracao.DataEntrada = null;
            fichaCastracao.DataSaida = null;
            _sisAdotContext.SaveChanges();
            AddNotificacaoSucesso("Consulta disponibilzada para reagendamento");
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
