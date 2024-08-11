namespace GuitarShop.Models
{
    // Class for creating the Products for the database
    public class Product
    {
        // Adds values for ProductID, Name, and Price for every product created
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
