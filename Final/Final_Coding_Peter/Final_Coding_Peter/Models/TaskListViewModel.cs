using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Final_Coding_Peter.Models
{
    public class TaskListViewModel
    {
        public List<Task> Tasks { get; set;}
    }
}
