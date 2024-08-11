using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
  public class ProductController : Controller
  {
    /// <summary>
    /// Action method to display the details page based on the id given
    /// </summary>
    /// <param name="id">Id of the product</param>
    /// <returns>View specific to the product id</returns>
    public IActionResult Detail(int id)
    {
      Product product = DB.GetProduct(id); // Get the product based on the product id
      return View(product); // Returns the view with the product found
    }
    /// <summary>
    /// Action method to display the list of all products
    /// </summary>
    /// <returns>View of all products</returns>
    public IActionResult List()
    {
      List<Product> products = DB.GetProducts(); // Gets all products from the database and puts them in a list
      return View(products); // Returns the view with all products listed
    }
  }
}
