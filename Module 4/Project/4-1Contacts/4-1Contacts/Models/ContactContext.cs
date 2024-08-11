using Microsoft.EntityFrameworkCore;

namespace _4_1Contacts.Models
{
  public class ContactContext : DbContext
  {
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {}
    public DbSet<Contacts> Contacts { get; set; } = null!;
    public DbSet<Categories> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categories>().HasData(
        new Categories { CategoriesId = "Fr", CategoriesName = "Friend" },
        new Categories { CategoriesId = "Fa", CategoriesName = "Family" },
        new Categories { CategoriesId = "W", CategoriesName = "Work" },
        new Categories { CategoriesId = "S", CategoriesName = "School" },
        new Categories { CategoriesId = "C", CategoriesName = "Church" }
        );

      modelBuilder.Entity<Contacts>().HasData(
        new Contacts {
          ContactId = 1,
          FirstName = "Peter",
          LastName = "Sanford",
          Phone = "801-953-3509",
          Email = "10934984@uvu.edu",
          CategoriesId = "S",
          Organization = "UVU",
          DateAdded = DateTime.UtcNow
        },
        new Contacts
        {
          ContactId = 2,
          FirstName = "Billy",
          LastName = "Bob",
          Phone = "801-953-3508",
          Email = "billy.bob@madeup.com",
          CategoriesId = "Fr",
          Organization = "Billy's Boats",
          DateAdded = DateTime.UtcNow
        }
        );
    }
  }
}
