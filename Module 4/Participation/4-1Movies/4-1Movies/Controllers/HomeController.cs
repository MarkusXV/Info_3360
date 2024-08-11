using _4_1Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _4_1Movies.Controllers
{
  /// <summary>
  /// Home Controller based on the MVC controller class
  /// </summary>
  public class HomeController : Controller
  {
    private MovieContext context {  get; set; } //Creates a local instance of the MovieContext class

    public HomeController(MovieContext ctx) //Constructs the class and passes in the context class
    {
      context = ctx; //Sets the local context value to the passed in context
    }

    /// <summary>
    /// Index action method
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
      var movies = context.Movies.Include(m => m.Genre)
                .OrderBy(m => m.Name).ToList(); //puts all of the movies with the Genres into a movies list
      return View(movies); //Returns the Index view with the movies list passed to it
    }

  }
}
