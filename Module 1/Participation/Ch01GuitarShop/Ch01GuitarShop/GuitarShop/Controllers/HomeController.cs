using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
  public class HomeController : Controller
  {

    /// <summary>
    /// Action method to display the Index page
    /// </summary>
    /// <returns>Returns the Index View</returns>
    public IActionResult Index()
    {
      return View(); //Returns the Index View
    }

    //Action method to display the Index page
    //Returns the About View
    public IActionResult About()
    {
      return View(); //Returns the About View
    }
  }
}