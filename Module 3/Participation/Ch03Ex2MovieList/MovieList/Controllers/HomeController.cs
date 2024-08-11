using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList.Controllers
{
  public class HomeController : Controller
  {
    //Creates a local context parameter for the DB
    private MovieContext context { get; set; }

    /// <summary>
    /// Sets the parameter context to the context passed when the homecontroller is initialized
    /// </summary>
    /// <param name="ctx"></param>
    public HomeController(MovieContext ctx)
    {
      context = ctx; //Sets the parameter ctx that's passed in to the context.
    }

    /// <summary>
    /// Pulls the movies by the genre and name from the Database
    /// </summary>
    /// <returns>Returns the home view to the user with the movies included</returns>
    public IActionResult Index()
    {
      var movies = context.Movies
          .Include(m => m.Genre)
          .OrderBy(m => m.Name)
          .ToList(); // sets a local movies variable that takes the movies database stored in the context variable to include everything by genre and ordered by name
      return View(movies); // Returns the view to the user
    }
  }
}