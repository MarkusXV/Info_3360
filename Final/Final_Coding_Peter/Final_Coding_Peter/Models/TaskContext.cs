using Microsoft.EntityFrameworkCore;
using Final_Coding_Peter.Models;
using System.Threading.Tasks;

namespace Final_Coding_Peter.Models
{
  public class TaskContext : DbContext
  {
    public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
    { }

    public DbSet<Final_Coding_Peter.Models.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Final_Coding_Peter.Models.Task>().HasData(
          new Final_Coding_Peter.Models.Task
          {
            TaskId = 1,
            Title = "Hire new personnel",
            Description = "We need to hire 3 new people for our support staff.",
            DueDate = Convert.ToDateTime("5/1/2024"),
            Status = "Pending",
            WorkerName = "Ester"
          },
          new Final_Coding_Peter.Models.Task
          {
            TaskId = 2,
            Title = "Finish Taxes",
            Description = "File Taxes for last year",
            DueDate = Convert.ToDateTime("4/15/2024"),
            Status = "Past Due",
            WorkerName = "Fred"
          },
          new Final_Coding_Peter.Models.Task
          {
            TaskId = 3,
            Title = "Have a Board Meeting",
            Description = "Board Meeting needs to be conducted at the end of the Quarter",
            DueDate = Convert.ToDateTime("6/30/2024"),
            Status = "Upcoming",
            WorkerName = "Bruce"
          }
      );
    }
  }
}
