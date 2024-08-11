using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
  public class HomeController : Controller
  {
    private Repository<Book> data { get; set; }
    public HomeController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

    public ViewResult Index()
    {
      int bookCount = data.Count;
      Random rand = new Random();
      var random = data.Get(rand.Next(1,bookCount + 1));

      return View(random);
    }

    public ContentResult Register()
    {
      return Content("Registration has not been implemented yet. It is implemented in chapter 16.");
    }

  }
}