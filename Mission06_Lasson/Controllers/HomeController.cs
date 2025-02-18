using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Lasson.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Lasson.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _movieContext;
        
        public HomeController(MoviesContext temp) // Constructor  
        { 
            _movieContext = temp;
        }

        //Testing

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(Movies response)
        {
            _movieContext.Movies.Add(response); // Add record to the database
            _movieContext.SaveChanges();

            return View("Confirmation", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
