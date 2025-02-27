using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Stanford.Models;
using System.Linq;

namespace Mission6_Stanford.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // Display all movies
        public IActionResult Index()
        {
            var movies = _context.Movies
                .Select(m => new Movie
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    CategoryID = m.CategoryID,
                    Year = m.Year,
                    Director = m.Director ?? "Unknown",
                    Rating = m.Rating ?? "Unrated",
                    Edited = m.Edited,
                    LentTo = m.LentTo,
                    Notes = m.Notes,
                    CopiedToPlex = m.CopiedToPlex
                }).ToList();

            return View(movies);
        }

        // Display Edit Form
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // Process Edit Submission
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // Display Delete Confirmation
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // Process Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}