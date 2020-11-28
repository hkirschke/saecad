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
            List<AnimalViewModel> animaisUsuario = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));
            ViewBag.Title = "Meus Animais";
            return View(animaisUsuario);
        }

        public ActionResult AnimaisDoacoes()
        {
            List<AnimalViewModel> animaisDoacao = _sisAdotContextAnimalUtil.AnimaisDoacoes();
            ViewBag.Title = "Animais para doação";
            return View("Index", animaisDoacao);
        }

        public ActionResult AnimaisDesaparecidos()
        {
            List<AnimalViewModel> animaisDesaparecidos = _sisAdotContextAnimalUtil.AnimaisDesaparecidos();
            ViewBag.Title = "Animais Desaparecidos";
            return View("Index", animaisDesaparecidos);
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
            return View(new AnimalViewModel());
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,TamanhoAnimal,RacaAnimal,Nome,Idade,Situacao,Resenha,ByteFoto,Imagem")] AnimalViewModel animalVM)
        {
            ValidaImagemModel(animalVM.Imagem);
            Animal animal = new Animal();

            if (ModelState.IsValid)
            {
                if (animalVM.Imagem != null)
                {
                    using (var binaryReader = new System.IO.BinaryReader(animalVM.Imagem.InputStream))
                        animal.Foto = binaryReader.ReadBytes(animalVM.Imagem.ContentLength);
                }

                animal.AnimalID = Guid.NewGuid();
                animal.Nome = animalVM.Nome;
                animal.RacaAnimal = animalVM.RacaAnimal;
                animal.Situacao = animalVM.Situacao;
                animal.TamanhoAnimal = animalVM.TamanhoAnimal;
                animal.Resenha = animalVM.Resenha;
                animal.Idade = animalVM.Idade;

                if (animal.Situacao == Enums.Situacao.DonoProprio) animal.UsuarioID = new Guid(Session["UsuarioID"].ToString());

                _sisAdotContext.Animals.Add(animal);
                _sisAdotContext.SaveChanges();

                AddNotificacaoSucesso("Registro criado");
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
            AnimalViewModel animalViewModel = new AnimalViewModel()
            {
                AnimalID = animal.AnimalID,
                Nome = animal.Nome,
                RacaAnimal = animal.RacaAnimal,
                Situacao = animal.Situacao,
                TamanhoAnimal = animal.TamanhoAnimal,
                Resenha = animal.Resenha,
                Idade = animal.Idade,
                ByteFoto = animal.Foto,
                UsuarioID = animal.UsuarioID
            };
            return View(animalViewModel);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,TamanhoAnimal,RacaAnimal,Nome,Idade,Situacao,Resenha,ByteFoto,Imagem, UsuarioID")] AnimalViewModel animalVM)
        {
            ValidaImagemModel(animalVM.Imagem);
            if (ModelState.IsValid)
            {
                Animal animal = new Animal
                {
                    AnimalID = animalVM.AnimalID,
                    Nome = animalVM.Nome,
                    RacaAnimal = animalVM.RacaAnimal,
                    Situacao = animalVM.Situacao,
                    TamanhoAnimal = animalVM.TamanhoAnimal,
                    Resenha = animalVM.Resenha,
                    Idade = animalVM.Idade,
                    Foto = animalVM.ByteFoto
                };

                if (animalVM.UsuarioID != null)
                    animal.UsuarioID = new Guid(animalVM.UsuarioID.ToString());

                if (animalVM.Imagem != null)
                {
                    using (var binaryReader = new System.IO.BinaryReader(animalVM.Imagem.InputStream))
                        animal.Foto = binaryReader.ReadBytes(animalVM.Imagem.ContentLength);
                }

                _sisAdotContext.Entry(animal).State = EntityState.Modified;
                _sisAdotContext.SaveChanges();

                AddNotificacaoSucesso("Registro editado");
                return RedirectToAction("Index");
            }
            return View(animalVM);
        }

        private void ValidaImagemModel(HttpPostedFileBase imagem)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                    ,"image/x-icon"
                };
            if (imagem != null)
            {
                if (imagem.ContentLength > 0)
                {
                    if (!imageTypes.Contains(imagem.ContentType))
                        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
                }
            }
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
            AddNotificacaoSucesso("Registro excluído");
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

        public ActionResult Adotar(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _sisAdotContext.Animals.Find(id);
            animal.UsuarioID = new Guid(Session["UsuarioID"].ToString());
            animal.Situacao = Enums.Situacao.Adotado;

            _sisAdotContext.Entry(animal).State = EntityState.Modified;
            _sisAdotContext.SaveChanges();
            List<AnimalViewModel> animaisUsuario = _sisAdotContextAnimalUtil.GetAnimaisUsuario(new Guid(Session["UsuarioID"].ToString()));

            AddNotificacaoSucesso("Adoção realizada");
            return View("Index", animaisUsuario);
        }
    }
}