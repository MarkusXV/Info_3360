using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _4_1Contacts.Models
{
  public class Contacts
  {
    [Key]
    public int ContactId { get; set; }

    [Required(ErrorMessage = "Please enter a First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a Phone Number")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter an Email Address")]
    public string Email { get; set; } = string.Empty;

    public string Organization { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a Category")]
    public string CategoriesId { get; set; } = null!;

    public DateTime DateAdded { get; set; }   

    [ValidateNever]
    public virtual Categories Categories { get; set; } = null!;

    public string Slug =>
            FirstName?.ToLower() + '-' + LastName?.ToLower();

  }
}
