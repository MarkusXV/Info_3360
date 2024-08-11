using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieList.Models
{
  public class Movie
  {
    // EntityFramework will instruct the database to automatically generate this value
    public int MovieId { get; set; }

    // Requires a value Name for the movie (default empty string)
    [Required(ErrorMessage = "Please enter a name.")]
    public string Name { get; set; } = string.Empty;

    // Requires a value Year for the movie from 1889 to 2050
    [Required(ErrorMessage = "Please enter a year.")]
    [Range(1889, 2050, ErrorMessage = "Year must be between 1889 and now.")]
    public int? Year { get; set; }

    // Requires a value Rating for the movie from 1 to 5
    [Required(ErrorMessage = "Please enter a rating.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int? Rating { get; set; }

    // Requires a value Genre ID for the movie, default empty string
    [Required(ErrorMessage = "Please enter a genre.")]
    public string GenreId { get; set; } = string.Empty;

    // Creates a new property of the Genre type that's default null
    [ValidateNever]
    public Genre Genre { get; set; } = null!;

    // Makes the URL a more user friendly format
    public string Slug =>
        Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString(); // Format Name-Name-Year URL
  }
}