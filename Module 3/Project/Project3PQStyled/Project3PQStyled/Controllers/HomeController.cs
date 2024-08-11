using Microsoft.AspNetCore.Mvc;
using Project3PQStyled.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace Project3PQStyled.Controllers
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
      ViewBag.TP = 0;
      ViewBag.DA = 0;
      ViewBag.ST = 0;
      ViewBag.DP = 0;
      ViewBag.TS = 0;
      return View(); // Returns the default view to the client
    }

    /// <summary>
    /// Using the Model code, action method that calculates the Discount Amount and Total if the inputted values are valid.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>If Valid, returns the view with new Calculated values. If not, returns the errors that occured</returns>
    [HttpPost]
    public IActionResult Index(PriceQuotationModel model)
    {
      // Checks if the inputs were valid
      if (ModelState.IsValid)
      {
        (ViewBag.TP, ViewBag.DA) = model.CalculatePriceQuotation();
        ViewBag.DP = model.DiscountPercent;
        ViewBag.ST = model.Subtotal;// Calculates the Future Value from the Model code and sets the Future Value label to it
      }
      else // If their inputs weren't valid
      {
        // Sets the view inputs back to 0
        ViewBag.TP = 0;
        ViewBag.DA = 0;
        ViewBag.DP = 0;
        ViewBag.ST = 0;

      }
      return View(model); // Returns the blank form including the errors that were generated in the Model code
    }
  }
}
