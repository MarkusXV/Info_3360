using Final_Coding_Peter.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Final_Coding_Peter.Controllers
{
  public class TaskController : Controller
  {
    private TaskContext context;

    public TaskController(TaskContext ctx)
    {
      context = ctx;
    }
    public IActionResult Index()
    {
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Add(Models.Task task)
    {
      if (ModelState.IsValid)
      {
        context.Tasks.Add(task);
        context.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }
  }
}
