using System.ComponentModel.DataAnnotations;

namespace Project3PQStyled.Models
{
  public class PriceQuotationModel
  {
    [Required(ErrorMessage = "Please enter a Subtotal")] // Requires the Subtotal variable to be entered
    [Range(0, 9999999999999999999, ErrorMessage = "Subtotal amount must be greater than 0")] // Requires the value to be greater than zero
    public decimal? Subtotal { get; set; } // Sets the public variable Subtotal

    [Required(ErrorMessage = "Please enter a Discount Percent")] // Requires the Discount Percent variable to be entered
    [Range(0, 100, ErrorMessage = "Discount Percent must be between 1 and 100")] // Requires the value to be between 0 and 100
    public decimal? DiscountPercent { get; set; } // Sets the public variable DiscountPercent

    /// <summary>
    /// Method to Calculate the Price Discount and Total based on the user's input
    /// </summary>
    /// <returns>TotalPrice, DiscountAmount</returns>
    public (decimal? TotalPrice, decimal? DiscountAmount) CalculatePriceQuotation()
    {
      decimal? DiscountAmount = 0; // Sets a local DiscountAmount variable

      decimal? TotalPrice = 0; // Sets a local TotalPrice variable

      decimal? adjusteddiscpercent = DiscountPercent / 100; // Divides the DiscountPercent by 100 so the percent is a decimal value and puts it into new adjusteddiscpercent variable

      DiscountAmount = Subtotal * adjusteddiscpercent; // Calculates the Discount Amount with the adjusted disccount percent

      TotalPrice = Subtotal - DiscountAmount; // Calculates the total price by subtracting the amount discounted from the subtotal entered

      return (TotalPrice, DiscountAmount); // Returns both the Total price and the Discount Amount
    }
  }
}
