using _4_1Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4_1Contacts.Controllers
{
  public class ContactController : Controller
  {
    private ContactContext context {  get; set; }
    public ContactController(ContactContext ctx)
    {
      context = ctx;
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      ViewBag.Categories = context.Categories.OrderBy(g => g.CategoriesName).ToList();
      return View("Edit", new Contacts());
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      ViewBag.Action = "Edit";
      ViewBag.Categories = context.Categories.OrderBy(g => g.CategoriesName).ToList();
      var contact = context.Contacts.Find(id);
      return View(contact);
    }
    [HttpPost]
    public IActionResult Edit(Contacts contacts)
    {
      if (ModelState.IsValid)
      {
        if (contacts.ContactId == 0)
        {
          context.Contacts.Add(contacts);
        }
        else
        {
          context.Contacts.Update(contacts);
        }
        context.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
      else
      {
        ViewBag.Action = (contacts.ContactId == 0) ? "Add" : "Edit";
        ViewBag.Genres = context.Contacts.OrderBy(g => g.FirstName).ToList();
        return View(contacts);
      }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      ViewBag.Action = "Delete";
      var movie = context.Contacts.Find(id);
      return View(movie);
    }

    [HttpPost]
    public IActionResult Delete(Contacts contacts)
    {
      context.Contacts.Remove(contacts);
      context.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}
