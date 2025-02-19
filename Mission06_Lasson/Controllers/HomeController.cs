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

            ViewBag.Categories = _movieContext.Categories
                .ToList();

            return View("AddMovies", new Movie());
        }

        [HttpPost]
        public IActionResult AddMovies(Movie response)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Add(response); // Add record to the database
                _movieContext.SaveChanges();

                return View("Confirmation", response);
            }
            else // Invalid data
            {
                ViewBag.Categories = _movieContext.Categories
                .ToList();

                return View(response);
            }
        }

        public IActionResult ViewMovies()
        {
            // Linq query (SQL-like language)
            var movies = _movieContext.Movies
                .Include(x => x.Categories)
                .ToList();

            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Edit(int movieID)
        {
            var movieToEdit = _movieContext.Movies
                .Single(x => x.MovieId == movieID);

            ViewBag.Categories = _movieContext.Categories
                .ToList();

            return View("AddMovies", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _movieContext.Update(updatedInfo);
            _movieContext.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int movieId)
        {
            var movieToDelete = _movieContext.Movies
                .Single(x => x.MovieId == movieId);
            
            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movieToDelete)
        {
            _movieContext.Movies.Remove(movieToDelete);
            _movieContext.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }
    }
}
