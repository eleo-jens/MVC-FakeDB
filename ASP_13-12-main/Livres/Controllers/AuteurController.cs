using Livres.FakeDB;
using Livres.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livres.Controllers
{
    public class AuteurController : Controller
    {
        public IActionResult Index()
        {
            return View(AuteurDB.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Auteur form)
        {
            if (ModelState.IsValid)
            {
                Auteur newAuteur = new Auteur
                {
                    Prenom = form.Prenom,
                    Nom = form.Nom,
                    DateNaissance = form.DateNaissance
                    //DateNaissance = new DateTime(form.DateNaissance)
                };
                AuteurDB.Add(newAuteur);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            AuteurDB.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(AuteurDB.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Auteur form, int id)
        {
            Auteur newAuteur = new Auteur
            {
                Prenom = form.Prenom,
                Nom = form.Nom,
                DateNaissance = form.DateNaissance

            };
            AuteurDB.Update(id, newAuteur);
            return RedirectToAction("Index");
        }
    }}
