using Livres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Livres.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            // crée une instance vide du modèle : email = null
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            //ValidationLoginCustom(form, ModelState);
            ValidationPasswordCustom(form, ModelState);
            if (!ModelState.IsValid) return View();
            // Si le form est valide on appelle nos fonctions (par exemple enregistrer nos infos dans la DB)
            return RedirectToAction("Index");
        }

        private static void ValidationPasswordCustom(LoginForm form, ModelStateDictionary modelstate)
        {        
            // vérification précise du mot de passe, pour qu'il y ait un msg d'erreur précis par erreur
            if (!Regex.IsMatch(form.Passwd, "[0-9]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir un chiffre.");

            if (!Regex.IsMatch(form.Passwd, "[a-z]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir une minuscule.");

            if (!Regex.IsMatch(form.Passwd, "[A-Z]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir une majuscule.");

            if (!Regex.IsMatch(form.Passwd, "[=+/-/_//?*]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir un caractère spécial.");
        }
        private static void ValidationLoginCustom(LoginForm form, ModelStateDictionary modelstate)
        {
            if (form.Email is null || form.Email.Trim() == "")
                modelstate.AddModelError(nameof(form.Email), "L'email est obligatoire.");
            if (string.IsNullOrWhiteSpace(form.Passwd))
            {
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe est obligatoire.");
                // ca ne sert à rien de continuer plus loin si on a pas le mdp
                return;
            }

            // vérification précise du mot de passe, pour qu'il y ait un msg d'erreur précis par erreur
            if (!Regex.IsMatch(form.Passwd, "[0-9]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir un chiffre.");

            if (!Regex.IsMatch(form.Passwd, "[a-z]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir une minuscule.");

            if (!Regex.IsMatch(form.Passwd, "[A-Z]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir une majuscule.");

            if (!Regex.IsMatch(form.Passwd, "[=+/-/_//?*]"))
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe doit contenir un caractère spécial.");

            if (form.Passwd.Length < 4)
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe est trop court");

            if (form.Passwd.Length > 32)
                modelstate.AddModelError(nameof(form.Passwd), "Le mot de passe est trop long");




        }
    
    }
}
