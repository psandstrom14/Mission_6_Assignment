using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission_6_Assignment.Models;
using System.Diagnostics;


namespace Mission_6_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public HomeController(MovieDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .ToList();
            return View(movies);
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(response);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie); _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
