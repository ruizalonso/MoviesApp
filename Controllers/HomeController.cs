using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Services;

namespace MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private IAPIService APIService;

        public HomeController(IAPIService _APIVervice)
        {
            APIService = _APIVervice;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            try
            {
                ViewBag.SearchResults = name;
                List<Movie> movies = new List<Movie>();
                movies = await APIService.GetMovieByName(name);
                return View(movies);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                Movie movie = await APIService.GetMovieById(id);
                return View(movie);
            }
            catch (Exception e)
            {
                throw;
            }
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
    }
}
