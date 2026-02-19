using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Berrett.Models;

namespace Mission06_Berrett.Controllers;

public class HomeController : Controller
{
    // Holds the database context for use throughout the controller
    private MovieCollectionContext _context;

    // Constructor - injects the database context
    public HomeController(MovieCollectionContext context)
    {
        _context = context;
    }

    // Loads the home page
    public IActionResult Index()
    {
        return View();
    }

    // Loads the GetToKnowJoel page
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    // Loads the Add Movie form
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View(new Movie());
    }

    // Receives form data and saves the new movie to the database
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else
        {
            // If validation fails, reload categories and return the form
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }
    }

    // Loads the movie list page showing all movies
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();

        return View(movies);
    }

    // Loads the edit form pre-populated with the existing movie data
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

        return View("AddMovie", recordToEdit);
    }

    // Saves the updated movie data to the database
    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Movies.Update(updatedMovie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    // Shows the delete confirmation page
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

        return View(recordToDelete);
    }

    // Removes the movie from the database
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}
