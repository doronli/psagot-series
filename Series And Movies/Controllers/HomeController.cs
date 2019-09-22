using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Series_And_Movies.Models;

namespace Series_And_Movies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return View();
        }

        public IActionResult SeriesDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SeriesChoose(string movie)
        {
            Movie curentMovie = JsonConvert.DeserializeObject<Movie>(movie);
            TempData["currentMovie"] = curentMovie;
            return RedirectToAction("SeriesDetails");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (StreamReader r = new StreamReader("../Series And Movies/data/moviesAndSeries.json"))
            {
                string json = r.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            //var sortesd = movies.OrderBy(mo => mo.Title).ToList();

            return movies;
        }
    }
}
