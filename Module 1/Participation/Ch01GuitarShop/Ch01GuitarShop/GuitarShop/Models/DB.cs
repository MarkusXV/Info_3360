namespace GuitarShop.Models
{
  public class DB
  {
    /// <summary>
    /// Method to create the list of products
    /// </summary>
    /// <returns>List of products</returns>
    public static List<Product> GetProducts()
    {
      List<Product> products = new List<Product> // List to hold all static products
          {
              new Product
              {
                  ProductID = 1,
                  Name = "Fender Stratocaster",
                  Price = (decimal)699.00
              },
              new Product
              {
                  ProductID = 2,
                  Name = "Gibson Les Paul",
                  Price = (decimal)1199.00
              },
              new Product
              {
                  ProductID = 3,
                  Name = "Gibson SG",
                  Price = (decimal)2517.00
              },
              new Product
              {
                  ProductID = 4,
                  Name = "Yamaha FG700S",
                  Price = (decimal)489.99
              },
              new Product
              {
                  ProductID = 5,
                  Name = "Washburn D10S",
                  Price = (decimal)299.00
              },
              new Product
              {
                  ProductID = 6,
                  Name = "Rodriguez Caballero 11",
                  Price = (decimal)415.00
              },
              new Product
              {
                  ProductID = 7,
                  Name = "Fender Precision",
                  Price = (decimal)799.99
              },
              new Product
              {
                  ProductID = 8,
                  Name = "Hofner Icon",
                  Price = (decimal)499.99
              },
              new Product
              {
                  ProductID = 9,
                  Name = "Ludwig 5-piece Drum Set with Cymbals",
                  Price = (decimal)699.99
              },
              new Product
              {
                  ProductID = 10,
                  Name = "Tama 5-Piece Drum Set with Cymbals",
                  Price = (decimal)799.99
              }
          };
      return products;
    }

    /// <summary>
    /// Gets a single product's information based on the passed id number
    /// </summary>
    /// <param name="id">Id of the product requested</param>
    /// <returns>The Product information (empty product if not found)</returns>
    public static Product GetProduct(int id)
    {
      List<Product> products = DB.GetProducts(); // Gets the static list of products from the database method
      foreach (Product p in products) // Loops through every product in the list
      {
        if (p.ProductID == id) // If id was found:
        {
          return p; // Returns the product's information if found
        }
      }
      return new Product(); // return empty Product if not in list
    }
  }
}
