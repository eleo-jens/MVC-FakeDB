using Livres.FakeDB;
using Livres.Models;
using Livres.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Livres.Controllers
{
    public class LivreController : Controller
    {
        public IActionResult Index()
        {
            return View(LivreDB.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Livre form)
        {
            //System.Console.WriteLine(form);
            //if (ModelState.IsValid)
            //{
                Livre newLivre = new Livre
                {
                    Titre = form.Titre,
                    AuteurId = form.AuteurId,
                    ISBN = form.ISBN
                };
                LivreDB.Add(newLivre);
            return RedirectToAction("Index");
            //}
            //return View(form);
        }

        //[Route("Livre/{id:int}")]
        public IActionResult Delete(int id)
        {
            System.Console.WriteLine(id);
            LivreDB.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeForm(int id)
        {
            return View(LivreDB.GetById(id));
        }
        
        [HttpPost]
        public IActionResult ChangeForm(Livre form, int id)
        {
            System.Console.WriteLine("The received id to ChangeForm" + id);
            Livre newLivre = new Livre
            {
                Titre = form.Titre,
                AuteurId = form.AuteurId,
                ISBN = form.ISBN
            };
            LivreDB.Update(id, newLivre); 
            return RedirectToAction("Index");
        }
    }
}
