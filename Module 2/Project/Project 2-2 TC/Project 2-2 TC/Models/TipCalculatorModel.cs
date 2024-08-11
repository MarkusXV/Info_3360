using System.ComponentModel.DataAnnotations;

namespace Project_2_2_TC.Models
{
  public class TipCalculatorModel
  {
    [Required(ErrorMessage = "Please enter a Cost")] // Requires the Cost variable to be entered
    [Range(0, 9999999999999999999, ErrorMessage = "Cost amount must be greater than 0")] // Requires the value to be greater than zero
    public decimal? Cost { get; set; } // Sets the public variable Cost

    public decimal? firsttip { get; set; } // Sets the public variable firsttip

    public decimal? secondtip { get; set; } // Sets the public variable secondtip

    public decimal? thirdtip { get; set; } // Sets the public variable thirdtip

    /// <summary>
    /// Method to Calculate the Tips based on the user's input
    /// </summary>
    /// <returns></returns>
    public void CalculateTips()
    {           
      firsttip = Cost * (decimal?)0.15; // Calculates the first tip by multiplying it by .15, or 15%

      secondtip = Cost * (decimal?)0.20; // Calculates the second tip by multiplying it by .20, or 20%

      thirdtip = Cost * (decimal?)0.25; // Calculates the third tip by multiplying it by .25, or 25%
    }
  }
}
