using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _4_1Movies.Models
{
  public class Movie
  {
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Please enter a name.")]
    public string? Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a genre.")]
    public string GenreId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a year.")]
    [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
    public int? Year { get; set; }

    [Required(ErrorMessage = "Please enter a rating.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int? Rating { get; set; }

    [ValidateNever]
    public virtual Genre Genre { get; set; } = null!;

    public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString(); //Slug property that takes the name of the movie and the year with dashes in it for the URL


  }
}
