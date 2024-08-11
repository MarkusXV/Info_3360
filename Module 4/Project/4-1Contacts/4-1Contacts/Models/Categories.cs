using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4_1Contacts.Models
{
  public class Categories
  {
    public string CategoriesId { get; set; }
    public string CategoriesName { get; set; } = string.Empty;

  }
}
