using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    // Receives form data and saves the new movie to the database
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
}