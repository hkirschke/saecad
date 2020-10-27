﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Win32;
using SisAdot.Data;
using SisAdot.Models;
using SisAdot.Models.Animal;

namespace SisAdot.Controllers
{
    public class AnimalController : BaseController
    {
        // GET: Animal
        public override ActionResult Index()
        {
            List<Animal> animaisUsuario = (from animalList in _sisAdotContext.Animals.ToList()
                                  where animalList.UsuarioID == new Guid(Session["UsuarioID"].ToString())
                                  select new Animal
                                  {
                                      AnimalID = animalList.AnimalID,
                                      Nome = animalList.Nome,
                                      Idade = animalList.Idade,
                                      Situacao = animalList.Situacao,
                                      RacaAnimal = animalList.RacaAnimal,
                                      TamanhoAnimal = animalList.TamanhoAnimal,
                                      UsuarioID = animalList.UsuarioID
                                  }).ToList();

            return View(animaisUsuario);
        }

        public ActionResult AnimaisDoacoes()
        {
            List<Animal> animaisDoacao = (from animalList in _sisAdotContext.Animals.ToList()
                                  where animalList.Situacao == Enums.Situacao.Disponível
                                  select new Animal
                                  {
                                      AnimalID = animalList.AnimalID,
                                      Nome = animalList.Nome,
                                      Idade = animalList.Idade,
                                      Situacao = animalList.Situacao,
                                      RacaAnimal = animalList.RacaAnimal,
                                      TamanhoAnimal = animalList.TamanhoAnimal,
                                      UsuarioID = animalList.UsuarioID
                                  }).ToList();

            return View("Index", animaisDoacao);
        }

        // GET: Animal/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _sisAdotContext.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,TamanhoAnimal,RacaAnimal,Nome,Idade,Situacao,Resenha,Foto")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                animal.AnimalID = Guid.NewGuid();
                if (animal.Situacao == Enums.Situacao.DonoProprio) animal.UsuarioID = new Guid(Session["UsuarioID"].ToString());
                _sisAdotContext.Animals.Add(animal);
                _sisAdotContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _sisAdotContext.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,TamanhoAnimal,RacaAnimal,Nome,Idade,Situacao,Resenha,Foto")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _sisAdotContext.Entry(animal).State = EntityState.Modified;
                _sisAdotContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _sisAdotContext.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Animal animal = _sisAdotContext.Animals.Find(id);
            _sisAdotContext.Animals.Remove(animal);
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

        // GET: Animal/Adotar/5
        [ActionName("Adotar")]
        public ActionResult Adotar(Guid? animalID)
        {
            if (animalID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _sisAdotContext.Animals.Find(animalID);
            animal.UsuarioID = new Guid(Session["UsuarioID"].ToString());
            animal.Situacao = Enums.Situacao.Adotado;

            _sisAdotContext.Entry(animal).State = EntityState.Modified;
            _sisAdotContext.SaveChanges();
            return View(animal);
        }
    }
}
