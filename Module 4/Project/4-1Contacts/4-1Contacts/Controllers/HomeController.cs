using _4_1Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _4_1Contacts.Controllers
{
  public class HomeController : Controller
  {
    private ContactContext context {  get; set; }
    public HomeController(ContactContext ctx)
    {
      context = ctx;
    }
    public IActionResult Index()
    {
      var contacts = context.Contacts
                .Include(c => c.Categories)
                .OrderBy(c => c.FirstName).ToList();
      return View(contacts);
      
    }

  }
}
