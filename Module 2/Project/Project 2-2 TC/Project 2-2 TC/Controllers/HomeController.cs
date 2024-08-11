using Microsoft.AspNetCore.Mvc;
using Project_2_2_TC.Models;
using System.Diagnostics;

namespace Project_2_1_Price_Quotation.Controllers
{
  public class HomeController : Controller
  {
    /// <summary>
    /// Action method for when the client requests the information from the server (httpget). Returns a view and sets the text boxes with default zeros
    /// </summary>
    /// <returns>A view with text boxes containing default zeros</returns>
    [HttpGet]
    public IActionResult Index()
    {
      // Sets the view inputs to 0
      ViewBag.cost = 0;
      ViewBag.firsttip = 0;
      ViewBag.secondtip = 0;
      ViewBag.thirdtip = 0;
      return View(); // Returns the default view to the client
    }

    /// <summary>
    /// Using the Model code, action method that calculates the Tip Amounts if the inputted values are valid.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>If Valid, returns the view with new Calculated values. If not, returns the errors that occured</returns>
    [HttpPost]
    public IActionResult Index(TipCalculatorModel model)
    {
      // Checks if the inputs were valid
      if (ModelState.IsValid)
      {
        model.CalculateTips();
        ViewBag.cost = model.Cost;
        ViewBag.firsttip = model.firsttip;
        ViewBag.secondtip = model.secondtip;
        ViewBag.thirdtip = model.thirdtip;

      }
      else // If their inputs weren't valid
      {
        // Sets the view inputs back to 0
        ViewBag.cost = 0;
        ViewBag.firsttip = 0;
        ViewBag.secondtip = 0;
        ViewBag.thirdtip = 0;
      }
      return View(model); // Returns the new form to the viewer, either calculated values or error messages
    }
  }
}

