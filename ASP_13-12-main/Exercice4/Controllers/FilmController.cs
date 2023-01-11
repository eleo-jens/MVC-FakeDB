using Exercice4.Models;
using Exercice4.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercice4.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            FilmIndexViewModel model = new FilmIndexViewModel();
            model.Films = new List<Film>()
            {
                new Film("Drop", "/img/drop.jpg"),
                new Film("Dungeons and Dragons: Honor Among Thieves", "/img/dungeons_and_dragons_honor_among_thieves_ver3.jpg"),
                new Film("80", "/img/eighty_for_brady.jpg"),
                new Film("Infinity Pool", "/img/infinity_pool.jpg"),
                new Film("La Brigade", "/img/la_brigade_ver2.jpg"),
                new Film("Night At The Museum: Kahmunrah Rises Again", "/img/night_at_the_museum_kahmunrah_rises_again_ver2.jpg"),
                new Film("Snow Day", "/img/snow_day.jpg"),
                new Film("This Place Rules", "/img/this_place_rules.jpg")
            };
            return View(model);
        }
    }
}
