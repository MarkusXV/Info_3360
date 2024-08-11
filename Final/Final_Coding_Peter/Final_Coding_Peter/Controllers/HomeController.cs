using Final_Coding_Peter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Final_Coding_Peter.Controllers
{
  public class HomeController : Controller
  {
    private TaskContext context { get; set; }
    public HomeController(TaskContext ctx) => context = ctx;

    [HttpGet]
    public ViewResult Index(int id)
    {
      IQueryable<Final_Coding_Peter.Models.Task> query = context.Tasks;

      var vm = new TaskListViewModel
      {
        Tasks = query.ToList(),
      };

      return View(vm);
    }

  }

}

