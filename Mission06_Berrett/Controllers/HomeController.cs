using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Berrett.Models;

namespace Mission06_Berrett.Controllers;

public class HomeController : Controller
{
    // Database context injected by dependency injection — used for all DB queries
    private MovieCollectionContext _context;

    // Constructor receives the context from the DI container registered in Program.cs
    public HomeController(MovieCollectionContext context)
    {
        _context = context;
    }

    // Loads the home page
    public IActionResult Index()
    {
        return View();
    }

    // Loads the page describing Joel Hilton
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    // Loads the blank Add Movie form
    // Passes categories to ViewBag so the dropdown is populated before the view renders
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View(new Movie());
    }

    // Receives the submitted form data and saves the new movie to the database
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
            // Validation failed — reload categories before returning the form
            // (ViewBag is lost on postback, so it must be repopulated)
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }
    }

    // Queries all movies (with their category names) and passes them to the list view
    // .Include() performs a SQL JOIN so Category.CategoryName is available in the view
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();

        return View(movies);
    }

    // Looks up the movie by ID and loads the AddMovie form pre-filled with its data
    // Reuses the AddMovie view — the hidden MovieId field tells EF which record to update
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

        // Categories must be reloaded so the dropdown renders correctly
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

        return View("AddMovie", recordToEdit);
    }

    // Saves the edited movie back to the database using the posted MovieId as the key
    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Movies.Update(updatedMovie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    // Looks up the movie by ID and displays a confirmation page before deletion
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

        return View(recordToDelete);
    }

    // Removes the movie from the database — only the MovieId from the hidden field is needed
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}
